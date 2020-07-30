using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace cinema_ahmetTumis_2017280064
{
    class Program
    {
        static void Main(string[] args)
        {

            Initializer testrun = new Initializer();
            testrun.BootUp();

            Thread.Sleep(200);
            Bilet musteri1 = new Bilet
            {
                CustomerName = "ahmet",
                CustomerSurname = "tümiş",
                CustomerIDNumber = "23482793847"

            };
            musteri1.Vizyondakiler();

            Console.WriteLine("Hello World!");
        }
    }
}
