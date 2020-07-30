using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace cinema_ahmetTumis_2017280064
{

    public interface IFile
    {
        void CheckFile();
        void ScanFileIntegrity();
        void TaramaYap();
    }

    public interface IDataBaseMaker 
    {
        void ProcessFileData();
        void ConvertToInt();
        void MovieForSalon();
    }

    public class Koltuk : MainFrame
    {   
        public int Sira { get; set; }
        public int Sayi { get; set; }
        public int Occupency { get; set; }
        public string durum;

        public void DurumGoster() {

            if(Occupency == 0){durum = "Boş";}
            else{durum = "Dolu";}

            Console.WriteLine("Sıra No: " + Sira + "Koltuk Sayısı: " + Sayi + "Koltuk durumu: " + durum);

        }

        public void YerAyir(){          //current koltuk occupency

            if(Occupency == 0)
            {
                Occupency = 1;
                Console.WriteLine("Sıra No: " + Sira + "Koltuk Sayısı: " + Sayi + " olan koltukta yer ayrılmıştır.");
            }
            else
            {
                Console.WriteLine("Seçmiş olduğunuz koltuk doludur, lütfen başka bir koltuk seçiniz.");
            }

        }
        
    }

    public class Gosterim : MainFrame
    {   
        public string FilmAdi { get; set; }
        public string Seans { get; set; }
        public string Tarih { get; set; }
        public int SalonNo { get; set; }

        public List<Koltuk> koltuklar = new List<Koltuk>();

        public void SalonIcinKoltukListesi()
        {

            int length = dataBaseContents.Count;

            for (int i = 0; i < (length - 3); i++)
            {
                Console.WriteLine("yep");
                if (i % 4 == 0)
                {
                    Console.WriteLine("yeyep\n");
                    int salonNoFromDB = Convert.ToInt32(dataBaseContents[i]);
                    int siraNo = Convert.ToInt32(dataBaseContents[i+1]);
                    int sayiNo = Convert.ToInt32(dataBaseContents[i+2]);
                    int occupency = Convert.ToInt32(dataBaseContents[i+3]);

                    if (salonNoFromDB == SalonNo)
                    {
                       koltuklar.Add(new Koltuk { Sira = siraNo, Sayi = sayiNo, Occupency = occupency});
                    }
                    else
                    {
                        Console.WriteLine("nope");
                    }
                    koltuklar[i].DurumGoster();
                }
            }
            
        }

        public void SalonDurumGoster()          //spesifik salon çağırıldığı zaman koltuklarla beraber durum basan fonksiyon
        {
            Console.Write("Film adi: " + FilmAdi + " Seans: " + Seans + " Film tarihi: " + Tarih + " Salon No:" + SalonNo + "\n");
            
        }

        public void SalonIcinKoltukListesiBastir()
        {
            int length = koltuklar.Count();

            for (int i = 0; i < length; i++)
            {
                koltuklar[i].DurumGoster();   
            }
        }

    }

    public class MainFrame : IDataBaseMaker, IFile
    {

        internal bool isFileExists = File.Exists(@"sinema.txt");
        internal ArrayList dataBaseContents = new ArrayList();
        internal List<int> salonlarRaw = new List<int>();
        internal List<int> salonlar;
        public List<Gosterim> gosterimler = new List<Gosterim>();
        Random random = new Random();

        public string[] movies =
        {
            "Captain America: The First Avenger",
            "Iron Man",
            "The Incredible Hulk",
            "Iron Man 2",
            "Thor",
            "The Avengers",
            "Iron Man 3",
            "Thor: The Dark World",
            "Captain America: The Winter Soldier",
            "Guardians of the Galaxy",
            "Guardians of the Galaxy Vol. 2",
            "Avengers: Age of Ultron",
            "Ant - Man",
            "Captain America: Civil War",
            "Spider - Man: Homecoming",
            "Doctor Strange",
            "Thor: Ragnarok",
            "Black Panther",
            "Avengers: Infinity War",
            "Ant - Man and the Wasp",
            "Captain Marvel"};

        public string[] tarih =
        {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma",
            "Cumartesi",
            "Pazar"
        };

        public string[] seans =
        {
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00"
        };


        public void CheckFile()
        {
            Console.WriteLine("Accesing database file.");
            Thread.Sleep(2500);

            if(isFileExists == true)
            {
                Console.WriteLine("Accessing database file succeeded...");
                
            }

            else
            {
                Console.WriteLine("Database file doesnt exist under current directory");
            }

        }

        public void ScanFileIntegrity()  //boş mu dolu mu taraması
        {
            throw new NotImplementedException();
        }

        public void TaramaYap()
        {
            throw new NotImplementedException();
        }



        public void ProcessFileData()
        {
            
            string raw = File.ReadAllText(@"sinema.txt");

            raw = raw.Replace("boş", "0");
            raw = raw.Replace("dolu", "1");
            raw = raw.Replace(Environment.NewLine,",");
            
            dataBaseContents.AddRange(raw.Split(','));
           
        }

        public void ConvertToInt()
        {
            int length = dataBaseContents.Count;

            for(int i=0; i <length; i++)
            {
               
                dataBaseContents[i] = Convert.ToInt32(dataBaseContents[i]);
               
            }
        }

        public void MovieForSalon()
        {

            int length = dataBaseContents.Count;
                                                            
            for(int i = 0; i < length; i++)       //bütün salonları ekler
            {

                if (i % 4 == 0)
                {
                    salonlarRaw.Add(Convert.ToInt32(dataBaseContents[i]));
                }

            }

            salonlar = salonlarRaw.Distinct().ToList();   //sadece salon numaralarını bulunduran liste

        }

        public void GosterimListesi()
        {

            int length = salonlar.Count();
            int moviesLength = movies.Count();
            int tarihLength = tarih.Count();
            int seansLength = seans.Count();

            for (int i = 0; i < length; i++)
            {
                int randomNumber = random.Next(100,200);

                gosterimler.Add(new Gosterim
                {
                    FilmAdi = movies[(randomNumber % moviesLength)],
                    Seans = seans[(randomNumber % seansLength)],
                    Tarih = tarih[(randomNumber % tarihLength)],
                    SalonNo = salonlar[i]
                });
            }
            for (int i = 0; i < length; i++){
                gosterimler[i].SalonIcinKoltukListesi();
            }

        }

        public void GosterimListesiBastir()
        {                                           //Sadece gösterimdeki filmleri gösteren, koltuk göstermeyen fonksiyon

            int count = gosterimler.Count();

            for(int i=0; i< count; i++)
            {
                Thread.Sleep(500);
                gosterimler[i].SalonDurumGoster();
                gosterimler[i].SalonIcinKoltukListesi();
                gosterimler[i].koltuklar[2].DurumGoster();
                gosterimler[i].SalonIcinKoltukListesiBastir();
            }

        }

        
    }


}

/*
 *
 * 
 Koltuk nesnesi dizisi şeklinde bir özellik
 Gösterime ait özellikler (film adı, seans, tarih, salon no)
*/


/*
 *  public void DBGoster()
    {
        foreach(var i in dataBaseContents)
        {

            Console.WriteLine(i);

        }

        //int length = dataBaseContents.Count;
       // Console.WriteLine(length);

    }
*/

/*
 *    public void SalonGoster()
    {
        MovieForSalon();
        Console.WriteLine("salonlar");
        foreach(int i in salonlar){
            Console.WriteLine(i);
        }
    }
*/