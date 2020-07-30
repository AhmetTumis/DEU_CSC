using System;

namespace final_project_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            
         
            Menus session = new Menus();
            session.Init();

            //201005,TR610032455466661200201005,666.66
            //201005,TR300032455410080003201005,10000.00
            //326785,TR610003200013900000326785,350.00
            //326785,TR300003200016420000326785,8000.00
            //388000,TR610007222250001200388000,19150.00
            //388000,TR300007222249000001388000,52.93
            //388000,TR300008222266600002388000,2850.00
            //400129,TR610008324560000000400129,2980.45

            session.AddUser(201005, "Naz Gül Uçan", "TR610032455466661200201005", 666.66, 0);
            session.AddUser(201005, "Naz Gül Uçan", "TR300032455410080003201005", 10000.00, 2);
            session.AddUser(326785, "İsmail Borazan", "TR610003200013900000326785", 350.00, 0);
            session.AddUser(326785, "İsmail Borazan", "TR300003200016420000326785", 8000.00, 1);
            session.AddUser(388000,"Zebercet Bak", "TR610007222250001200388000", 19150.00, 0);
            session.AddUser(388000, "Zebercet Bak","TR300007222249000001388000", 52.93, 1);
            session.AddUser(388000, "Zebercet BAk", "TR300008222266600002388000", 2850.00, 2);
            session.AddUser(400129, "Naz Gül Uçan", "TR610008324560000000400129", 2980.45, 0);

            session.FinallizeAccount();
            session.ClientLogin();


        }
    }
}
