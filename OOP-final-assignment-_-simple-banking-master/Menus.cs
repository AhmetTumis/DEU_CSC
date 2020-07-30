using System;
using System.Threading;
using System.Security.Cryptography;
using System.Text;


namespace final_project_oop
{
    public class Menus : AuthServer
    {

        //AuthServer session = new AuthServer();

        public void Init()
        {
            //SetExchangeRate();
            CheckDir();
            InitFiles();
        }

        public void ClientLogin()           //user credentials burada alınır
        {

            Thread.Sleep(3000);
            Console.Clear();

            while (true)
            {
                Console.WriteLine("LOGIN PAGE");

                string userID = string.Empty;
                string userPass = string.Empty;
                int IDToSend = 0;
                int userAck = 0;
                int passAck = 0;

                Console.WriteLine("Please enter your User ID: ");
                userID = Console.ReadLine();
                userAck = LoginIntegrityChecker(userID, 1);

                if (userAck != 1)
                {
                    ClientLogin();
                }

                IDToSend = Convert.ToInt32(userID);

                Console.WriteLine("Enter password: ");
                userPass = Console.ReadLine();
                passAck = LoginIntegrityChecker(userPass, 2);

                if (passAck != 1)
                {
                    ClientLogin();
                }

                AskAuth(IDToSend, userPass);

                //you may know hash it and send to auth server for a token
            }


        }

        public void AskAuth(int id, string password)  //hashes and sends to auth server
        {
            
                                                    //Auth classına yollar
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            //Console.WriteLine("your password is: {0}, and the hash is {1}", password, Encoding.Default.GetString(hash));

            RequestLogin(id, hash);
            
        }

        
    }
}
