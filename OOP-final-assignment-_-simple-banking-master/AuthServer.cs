using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace final_project_oop
{
    public class AuthServer : MainFrame
    {                                   //buraya hashlenmiş şifre yollanıp kontrol edilecek
                                        //limited time ban ve giriş tokeni buradan verilecek

        internal ArrayList dataBaseContents = new ArrayList();
        public Dictionary<int, int> accessPerm = new Dictionary<int, int>();


        public AuthServer(int os = 0)
        {
            string path = string.Empty;
         
            if (os == 0)         //for osx or linux
            {
                path = @"/Users/ahmettumis/final";
            }
            else if (os == 1)    //for windows
            {
                path = @"c:\final";
            }

            Directory.SetCurrentDirectory(path);

            CheckAuthIntegrity();

        }

        public void CheckAuthIntegrity()
        {
            FileStream abc = new FileStream(@"auth.txt", FileMode.Open);

            try
            {
                FileInfo info = new FileInfo(@"auth.txt");
                long size = info.Length;
                Console.WriteLine("\nFile Size in Bytes: {0}\n", size);

                if (size == 0)
                {
                    throw new FileSizeZeroException();
                }

                ParseAuthFile();
            }

            catch (FileSizeZeroException e)
            {
                e.FileSizeException();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            finally
            {
                abc.Close();
            }
        }

        public class FileSizeZeroException : Exception
        {
            public void FileSizeException()
            {
                Console.WriteLine("File cant be empty!");
            }
        }

        public void ParseAuthFile()
        {

            string authFile = @"auth.txt";

            string raw = File.ReadAllText(authFile);

            
            raw = raw.Replace(Environment.NewLine, ",");

            dataBaseContents.AddRange(raw.Split(','));


            for(int i=0; i<dataBaseContents.Count; i++)         //adds to dictionary 
            {
                if (i % 2 == 0)
                {
                    accessPerm.Add(Convert.ToInt32(dataBaseContents[i]),0);
                   
                }
            }

        }

        public void RequestLogin(int id , byte[] passwordHash)
        {


            string sendHashToComp = string.Empty;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < passwordHash.Length; i++)
            {
                result.Append(passwordHash[i].ToString("X2"));
            }

            //Console.WriteLine("{0}", (result.ToString()).ToLower());
            sendHashToComp = (result.ToString()).ToLower();

            ProcessRequest(id, sendHashToComp);

        }


        public void ProcessRequest(int id, string hashToComp)
        {

            bool accessPermission = false;

            for (int i = 0; i < dataBaseContents.Count; i++)
            {
                if (i % 2 == 0 && id == Convert.ToInt32(dataBaseContents[i]))
                {
                    accessPermission = string.Equals(hashToComp, dataBaseContents[i+1].ToString());
                }
            }

            CheckAccessLimitation(id, accessPermission);
          

        }

        public void CheckAccessLimitation(int id, bool accessPermision)          //user id int, access denied flag
        {

            //Console.WriteLine("Giriş izni: {0}", accessPermision);

            if (accessPerm.ContainsKey(id) == true)  //şimdi şifre doğru mu yanlış mı
            {
                int value;
                //int temp = accessPerm[id];
                accessPerm.TryGetValue(id, out value);
                //accessPermision == false || accessPermision == true && 
                if (value >= 3)
                {
                    ResponseLogin(id, false, true);
                }
                else if(accessPermision == false && value!=3)
                {
                    accessPerm[id] = value + 1;
                    ResponseLogin(id, false, false);
                }
                else
                {

                    ResponseLogin(id, true, false);
                    accessPerm[id] = value - value;
                }
            }
            else
            {       //just send this user does not exist or password is incorrect (its just the user that doesnt exist but still, you know how it works)    
                ResponseLogin(id);
            }

        }


        public void ResponseLogin(int id, bool decision = false, bool isBanned = false)    //kullanıcı adı veya parola yanlış / erişim izni var
        {
            
            if(decision == false && isBanned == true)
            {
                ListenAuth(false, 1);
            }
            else if (decision == false && isBanned == false)
            {
                ListenAuth(false, 2);
            }
            else
            {

                ListenAuth(true, 0, id);

            }

        }
       
    }
}
