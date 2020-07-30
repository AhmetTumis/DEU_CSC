using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Threading;


namespace final_project_oop
{
    public class MainFrame
    {

        internal string path = " ";
        internal List<Customer> Customers = new List<Customer>();
        internal ArrayList Accounts = new ArrayList();
        internal ArrayList AccountDetails = new ArrayList();

        public void CheckDir(int os = 0)        //checks and creates directory
        {
            

            if(os == 0)         //for osx or linux
            {
                path = @"/Users/ahmettumis/final";
            }
            else if(os == 1)    //for windows
            {   
                path = @"c:\final";
            }

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path already exists, creation time was {0}", Directory.GetCreationTime(path));
                    Directory.SetCurrentDirectory(path);

                    return;
                }

                // Try to create the directory.
                DirectoryInfo final = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                Directory.SetCurrentDirectory(path);

            }

            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                Console.WriteLine("Checking the integrity under the directory.");
            }

        }

        public void InitFiles()
        {
            //client txt auth txt
            string clientFile = @"client.txt";
            string authFile = @"auth.txt";
      
            try
            {  
                if (File.Exists(clientFile))
                {
                    Console.WriteLine("Clients file exists");
                    Thread.Sleep(1000);

                    if (File.Exists(authFile))
                    {
                        Console.WriteLine("Authentication file exists");
                        Thread.Sleep(1000);

           
                    }
                    else
                    {
                        Console.WriteLine("auth.txt file not found, please add it manually before proceeding any further.");
                        Environment.Exit(1);
                    }

                }
                else
                {
                    Console.WriteLine("Clients file doesn't exist, creating one...");
                    FileStream fs = File.Create(clientFile);
                    fs.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        
        public void AddUser(int accountNo, string nameSurname, string IBAN, double balance, int type = 0) //type == 0 first time type == 1 euro type == 2 usd
        {
            int i;

            switch (type)
            {
                case 0:

                    Customers.Add(new Customer
                    {
                        AccountNo = accountNo,
                        NameSurname = nameSurname,
                        IBANTR = IBAN,
                        GetBalanceIBANTR = balance
                        
                    });

                    Accounts.Add(accountNo);
                    Accounts.Add(IBAN);
                    Accounts.Add(balance);

                    GetDetails(accountNo, nameSurname, IBAN, 1);

                    break;

                case 1:   //make sure the account is inited

                    for(i = 0; i< Customers.Count; i++)
                    {
                        if((Customers[i] as Customer).AccountNo == accountNo)
                        {
                            (Customers[i] as Customer).CreateEuroAccount(IBAN, balance);
                        }
                    }

                    Accounts.Add(accountNo);
                    Accounts.Add(IBAN);
                    Accounts.Add(balance);

                    GetDetails(accountNo, nameSurname, IBAN, 2);

                    break;

                case 2:

                    for (i = 0; i < Customers.Count; i++)
                    {
                        if ((Customers[i] as Customer).AccountNo == accountNo)
                        {
                            (Customers[i] as Customer).CreateUSDAccount(IBAN, balance);
                        }
                    }

                    Accounts.Add(accountNo);
                    Accounts.Add(IBAN);
                    Accounts.Add(balance);

                    GetDetails(accountNo, nameSurname, IBAN, 3);

                    break;

                default:
                    break;
            }

        }

        public void FinallizeAccount()
        {

            int i;

            try
            {
                FileStream fs = File.Open("client.txt", FileMode.Open);
                fs.SetLength(0);


                StreamWriter sw = new StreamWriter(fs);
                
           

                for (i=0; i<Accounts.Count; i++)
                {
                    if(i%3 == 0)
                    {
                        
                        sw.Write(Accounts[i]);
                        sw.Write(",");
                    }
                    else if(i%3 == 1)
                    {
                        sw.Write(Accounts[i]);
                        sw.Write(",");
                    }
                    else
                    {
                        sw.Write(Accounts[i]);

                        if(i!= Accounts.Count - 1)
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
                Console.WriteLine("Couldnt access to the file!");
            }
           /* finally
            {
                for (i = 0; i < Accounts.Count; i++)
                {
                    Console.WriteLine(Accounts[i]);
                }

                foreach (var j in Customers) {
                    Console.WriteLine(j);
                }
            }*/
        }

        public int LoginIntegrityChecker(string input, int type)  //type 1 = id, 2 = password 
        {

            int val = 0;

            switch (type)
            {
                case 1:

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (Char.IsDigit(input[i]))
                        {
                            val++;
                        }
                    }
                    if (input.Length == 6 && val == input.Length) //altı karakter uzunluğunda ise ve bütün karakterler sayi ise
                    {
                        return 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nYour id should be 6 characters long and should only contain numbers.\n");
                        Thread.Sleep(1000);
                        return 0;
                    }

                case 2:

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (Char.IsLetterOrDigit(input[i]))
                        {
                            val++;
                        }
                    }

                    if (input.Length == 8 && val == input.Length)
                    {
                        return 1;
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nYour password should be 8 characters long and should only contain UPPER/lower case characters or numbers.\n");
                        Thread.Sleep(1000);
                        return 0;
                    }

            }
            
            return -1;
        }


        public void ListenAuth(bool permission, int flag = 0, int id = 0) //flag 1: banned  flag 2:wrong password
        {
            if(permission == false && flag == 1)
            {
                Console.WriteLine("Due to failed attempts your account has been disabled for 24 hours");
                
            }
            else if(permission == false && flag == 2)
            {
                Console.WriteLine("Wrong username or password");
            }

            else if(permission == true)
            {
                //Console.WriteLine("{0} Your credentials are correct, logging in...", id);
                //Thread.Sleep(1000);
                LetThemAccessMan(id);
            }

        }


        public void LetThemAccessMan(int id)
        {

            int i = 0;
            Console.Clear();
            for(i= 0; i< Customers.Count; i++)
            {
                //Console.WriteLine("i= {0}",  i);
                if(id == (Customers[i] as Customer).AccountNo)
                {
                    (Customers[i] as Customer).UserMenu(AccountDetails);  //at this point the user is officially logged in
                    UpdateMainFrame();
                }

            }

        }

        
        public void GetDetails(int accountNo, string userName, string IBAN, int type) //1 == try 2 == eur 3 == usd
        {
            AccountDetails.Add(accountNo);
            AccountDetails.Add(userName);
            AccountDetails.Add(IBAN);
            AccountDetails.Add(type);
        }


        public ArrayList tempAccountFlush = new ArrayList();

        public void UpdateMainFrame()
        {
            try
            {

                string userFile = @"client.txt";

                string raw = File.ReadAllText(userFile);

                raw = raw.Replace(Environment.NewLine, ",");

                tempAccountFlush.AddRange(raw.Split(','));

                //Customers.Clear();

                for(int i = 0; i < tempAccountFlush.Count; i++)
                {
                    if (i % 3 == 1)
                    {

                        for(int j = 0; j < Customers.Count; j++)
                        {
                            if (tempAccountFlush[i].ToString() == (Customers[j] as Customer).IBANTR)
                            {
                                (Customers[j] as Customer).GetBalanceIBANTR = Convert.ToDouble(tempAccountFlush[i + 1]);
                            }
                        }
                        for (int j = 0; j < Customers.Count; j++)
                        {
                            if (tempAccountFlush[i].ToString() == (Customers[j] as Customer).EUIBAN)
                            {
                                (Customers[j] as Customer).EUBalance = Convert.ToDouble(tempAccountFlush[i + 1]);
                            }
                        }
                        for (int j = 0; j < Customers.Count; j++)
                        {
                            if (tempAccountFlush[i].ToString() == (Customers[j] as Customer).USDIBAN)
                            {
                                (Customers[j] as Customer).USDBalance = Convert.ToDouble(tempAccountFlush[i + 1]);
                            }
                        }
                    }
                }

                Console.WriteLine("Mainframe update completed!");

            }
            catch(IOException e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
