using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace cinema_ahmetTumis_2017280064
{
    public class Initializer
    {
        MainFrame firstRun = new MainFrame();

        public void BootUp(int runTest = 0)   //runtest, if you want a verbose explanation
        {
            Console.WriteLine("Initialising startup sequence");
            Thread.Sleep(2000);
            firstRun.CheckFile();
            Thread.Sleep(1000);
            //firstRun.ScanFileIntegrity();
            Thread.Sleep(100);
            //firstRun.TaramaYap();
            Thread.Sleep(100);
            firstRun.ProcessFileData();
            Thread.Sleep(1000);
            firstRun.ConvertToInt();
            firstRun.MovieForSalon();
            firstRun.GosterimListesi();
            Thread.Sleep(100);

            if (runTest == 0)
            {
                Console.WriteLine("Çalışan bilgilendirmesi: ");
                Thread.Sleep(200);
                firstRun.GosterimListesiBastir();
            }
        }
    }

    public class Bilet
    {

        private string name;
        private string surname;
        private string IDNumber;

        public string CustomerName
        {
            get { return name; }
            set { name = value; }
        }

        public string CustomerSurname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string CustomerIDNumber
        {
            get { return IDNumber; }
            set { IDNumber = value; }
        }

       public void Vizyondakiler()
        {
            Console.WriteLine("Sinemamızda sunulan filmler şöyledir: ");
            
            
        }

       public void BiletBastir()
        {
            Console.WriteLine("ad soyad: {0} {1} kimlik numarasi: {2}", name, surname, IDNumber);
        }

      
        
        
    } 

    public class IndirimliBilet : Bilet
    {
        
    }
}


/*
 *
 * Koltuk nesnesi dizisi şeklinde bir özellik
 Bilet sahibine ait özellikler (ad, soyad, TC kimlik no)
 Gösterim nesnesi şeklinde bir özellik
 Fiyat özelliği
 Bilgi yazdır/gönder metodu
*/

/*
 *
 *İndirimli Bilet sınıfı
 Bilet sınıfından kalıtımla türetilir
 Ek olarak indirim kodu özelliği
 İndirim miktarı özelliği
 */
