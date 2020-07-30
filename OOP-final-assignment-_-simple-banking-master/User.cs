using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Threading;


namespace final_project_oop
{

    public abstract class UserTR : IUserEU, IUserUSD
    {

        public int AccountNo { get; set; }
        public string NameSurname { get; set; }
        public string IBANTR { get; set; }
        public double GetBalanceIBANTR { get; set; }


        public abstract void CreateEuroAccount(string IBAN, double balance);
        public abstract void CreateUSDAccount(string IBAN, double balance);
    }

    public interface IUserEU
    {
        void CreateEuroAccount(string IBAN, double balance);
 
    }
    public interface IUserUSD
    {

        void CreateUSDAccount(string IBAN, double balance);
        
    }


    public class Customer : UserTR
    {

        public string EUIBAN;
        public double EUBalance;
        public string USDIBAN;
        public double USDBalance;

        internal ArrayList dataBaseContents = new ArrayList();
        internal Dictionary<string, double> ExchangeRate = new Dictionary<string, double>();
        internal ArrayList otherUserDetails = new ArrayList();

        public override void CreateEuroAccount(string IBAN, double balance)
        {
            EUIBAN = IBAN;
            EUBalance = balance;
        }

        public override void CreateUSDAccount(string IBAN, double balance)
        {
            USDIBAN = IBAN;
            USDBalance = balance;
        }


        public void ParseClientFile()
        {
            string userFile = @"client.txt";

            string raw = File.ReadAllText(userFile);


            raw = raw.Replace(Environment.NewLine, ",");

            dataBaseContents.AddRange(raw.Split(','));
        
        }

        public void SetExchangeRate()
        {
            if(ExchangeRate == null)
            {
                ExchangeRate.Add("USD", 7.1094);
                ExchangeRate.Add("EUR", 7.9283);
            }
            
        }

        public void ParseOtherUserDetails(ArrayList content)
        {
            foreach(var i in content)
            {
                otherUserDetails.Add(i);
            }
        }


        public void UserMenu(ArrayList content)
        {
            SetExchangeRate();
            ParseClientFile();
            ParseOtherUserDetails(content);

            //foreach(var i in dataBaseContents)
            //{
            //    Console.WriteLine(i);
            //}

            while (true)
            {
                
                Thread.Sleep(1000);

                string secim;
                Console.WriteLine("Welcome back {0}", NameSurname);
                Console.WriteLine("***********************************\n");
                Console.WriteLine("1.Show my accounts");
                Console.WriteLine("2.Make a money transfer");
                Console.WriteLine("3.Secure log out\n");


                Console.WriteLine("Please choose an option: ");
                secim = Console.ReadLine();

                if(secim == "1")
                {
                    ShowMyAccounts();

                }
                else if(secim== "2")
                {
                    MakeMoneyTransfer();
                }

                else if(secim == "3")
                {

                    Console.Clear();

                    Console.WriteLine("Thanks for using our system.\n");
                    Console.WriteLine("We hope you have a pleasent day\n");
                    Console.WriteLine("Logging out\n");
                    Thread.Sleep(2000);
                    break;

                }

                else
                {
                    Console.WriteLine("You have chosen a wrong option, please try again...\n");
                }



            }

        }

        private void ShowMyAccounts()
        {
            Console.Clear();
            Console.WriteLine("Your account number is: {0}\n", AccountNo);
            Console.WriteLine("Your main account's IBAN is {0}  Balance: {1} TRY\n\n",IBANTR, GetBalanceIBANTR);


            if(String.IsNullOrEmpty(EUIBAN)==false)
            {
                Console.WriteLine("IBAN of your Euro account: {0}   Balance: {1} EURO\n\n", EUIBAN, EUBalance);
                
            }
            if(String.IsNullOrEmpty(USDIBAN) == false)
            {
                Console.WriteLine("IBAN of your USD account: {0}   Balance: {1} USD\n\n", USDIBAN, USDBalance);
            }


        }


        private void MakeMoneyTransfer()
        {
            string choice;
            ShowMyAccounts();
            Console.WriteLine("Please choose an account to transfer from: (try/eur/usd)");
            choice = Console.ReadLine();


            if(choice.ToLower() == "try")
            {
                ChooseRecipient(1);
            }

            else if(choice.ToLower() == "eur" && String.IsNullOrEmpty(EUIBAN) == false)
            {
                ChooseRecipient(2);
            } 

            else if(choice.ToLower() == "usd" && String.IsNullOrEmpty(USDIBAN) == false)
            {
                ChooseRecipient(3);
            }

            else
            {
                Console.WriteLine("Wrong input, please try again.\n");

                Thread.Sleep(2000);

                MakeMoneyTransfer();
            }

        }


        public void ChooseRecipient(int accountType)   //1 try 2 euro 3 usd
        {
            int recipient = 0, i = 0, counter = 0;
            string IBAN = string.Empty;
            bool IBANIntegrity = false;

            Console.WriteLine("Please enter the account number of the recipient you want to send the money to: \n");

            recipient = Convert.ToInt32(Console.ReadLine());

            if (recipient == AccountNo)
            {
                Console.WriteLine("HAHA so funny! You can't send money too yourself genius!\n");
                ChooseRecipient(accountType); //recursion to save the day

            }

            for (i = 0; i < dataBaseContents.Count; i++)
            {

                if (recipient.ToString() == dataBaseContents[i].ToString() && recipient != AccountNo)
                {
                    counter++;
                    Console.WriteLine("User No: {0} User IBAN {1}", dataBaseContents[i], dataBaseContents[i+1]);

                }
            }


            if(counter == 0)
            {
                Console.WriteLine("Couldn't find the user, please try again");
                ChooseRecipient(accountType);
            }

            else
            {
                Console.WriteLine("Please enter the IBAN of the recipient: \n");
                IBAN = Console.ReadLine();
            }


            for (i = 0; i < dataBaseContents.Count; i++)
            {

                if (IBAN == dataBaseContents[i].ToString())
                {

                    IBANIntegrity = true;
                }
            }


            if(IBANIntegrity == true)
            {
                EnterAmountToSend(accountType, IBAN);
            }

            else
            {
                Console.WriteLine("IBAN not found please try again...\n");
                Thread.Sleep(2000);
                ChooseRecipient(accountType);
            }



        }

        public void EnterAmountToSend(int accountType, string IBANToSendMoneyToSomehow)
        {
            //Console.WriteLine("I guess this is working. this is the iban {0}, this is your type {1}", IBANToSendMoneyToSomehow, accountType);
            Thread.Sleep(1000);
            Console.Clear();

            double money = 0;
            double tempBalance = 0;
            string ibanToSend = "";

            if(accountType == 1)
            {
                ibanToSend = IBANTR;
                tempBalance = GetBalanceIBANTR;
                Console.WriteLine("Your Balance: {0} TRY\n", GetBalanceIBANTR);
            }
            else if(accountType == 2)
            {
                ibanToSend = EUIBAN;
                tempBalance = EUBalance;
                Console.WriteLine("Your Balance: {0} EUR\n", EUBalance);
            }
            else if(accountType == 3)
            {
                ibanToSend = USDIBAN;
                tempBalance = USDBalance;
                Console.WriteLine("Your Balance: {0} USD\n",  USDBalance);
            }

            else
            {
                Console.WriteLine("This is so impossible! If you are seeing this something went very, VERY WRONG!");
            }


            Console.WriteLine("Target IBAN: {0}\n", IBANToSendMoneyToSomehow);

            Console.WriteLine("Please enter the amount you want to send: ");
            money = Convert.ToDouble(Console.ReadLine());

            if(tempBalance - money < 0)
            {
                Console.WriteLine("Unable to make the transaction.\n");
                Console.WriteLine("Returning to main menu, you may try with another account");
                Thread.Sleep(1000);
            }
            else
            {
                MakeTransaction(accountType, money, ibanToSend, IBANToSendMoneyToSomehow);
            }
            
            
        }

        public void MakeTransaction(int currencyType, double amount, string senderIBAN, string targetIBAN)
        {
            int i = 0;
            int targetIBANtype = 0;
            double temp = 0;
            

            for (i = 0; i < otherUserDetails.Count; i++)
            {
                if (targetIBAN == otherUserDetails[i].ToString())
                {
                    targetIBANtype = Convert.ToInt32(otherUserDetails[i+1]);
                }
            }

            temp = CurrencyConverterToTRY(amount, currencyType, targetIBANtype);

            for(i = 0; i< dataBaseContents.Count; i++)
            {
                if(senderIBAN == dataBaseContents[i].ToString())
                {
                    double buffer = Convert.ToDouble(dataBaseContents[i+1]) - amount;
                    dataBaseContents[i + 1] = buffer;
                }
            }

            for (i = 0; i < dataBaseContents.Count; i++)
            {
                if (targetIBAN == dataBaseContents[i].ToString())
                {
                    double buffer = Convert.ToDouble(dataBaseContents[i + 1]) + temp;
                    dataBaseContents[i + 1] = buffer;
                }
            }


            Console.WriteLine("Transaction completed with success!");
            Thread.Sleep(1000);
            Console.WriteLine("Please log out then log in to see changes");
            Thread.Sleep(1000);


            SaveTransaction();

        }

        public double CurrencyConverterToTRY(double amount, int currencyType, int targetCurrencyType)  //2 euro 3 usd
        {
            
            double value;
            double returnvalue = 0;
            double temp;

            if(currencyType == 1)
            {
                returnvalue = CurrencyConverterFromTRY(amount, targetCurrencyType);
            }

            else if (currencyType == 2)
            {
                ExchangeRate.TryGetValue("EUR", out value);
                temp = amount * value;
                returnvalue = CurrencyConverterFromTRY(temp, targetCurrencyType);

            }
            else if(currencyType == 3)
            {
                ExchangeRate.TryGetValue("USD", out value);
                temp = amount - value;
                returnvalue = CurrencyConverterFromTRY(temp, targetCurrencyType);
            }

            return returnvalue;
        }

        public double CurrencyConverterFromTRY(double amount, int targetCurrencyType)  //2 euro 3 usd
        {

            double value;
            if(targetCurrencyType == 1)
            {
                return amount;
            }

            else if (targetCurrencyType == 2)
            {
                ExchangeRate.TryGetValue("EUR", out value);
                return amount / value;

            }
            else if (targetCurrencyType == 3)
            {
                ExchangeRate.TryGetValue("USD", out value);
                return amount / value;
            }
            return 0;
        }



        public void SaveTransaction()
        {

            int i;

            try
            {
                FileStream fs = File.Open("client.txt", FileMode.Open);
                fs.SetLength(0);


                StreamWriter sw = new StreamWriter(fs);

                for (i = 0; i < dataBaseContents.Count; i++)
                {
                    if (i % 3 == 0)
                    {

                        sw.Write(dataBaseContents[i]);
                        sw.Write(",");
                    }
                    else if (i % 3 == 1)
                    {
                        sw.Write(dataBaseContents[i]);
                        sw.Write(",");
                    }
                    else
                    {
                        sw.Write(dataBaseContents[i]);

                        if (i != dataBaseContents.Count - 1)
                        {
                            sw.Write("\n");
                        }

                    }
                }
                sw.Close();
                fs.Close();
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Couldn't access to the file!");
            }
            
        }

    }
}
