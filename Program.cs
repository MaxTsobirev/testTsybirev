﻿using System;

namespace pokupka_biletov
{
    class Program
    {

        static int Saali_suurs()
        {
            Console.WriteLine("Vali saali suurus: 1, 2, 3");
            int suurus = int.Parse(Console.ReadLine());
            return suurus;
        }
        static int[,] saal = new int[,] { };
        static int kohad, read;
        static void Saali_taitmine(int suurus/*int[,] saal, Random rnd*/)
        {
            Random rnd = new Random();
            if (suurus == 1)
            {
                kohad = 20;
                read = 10;
            }
            else if (suurus == 2)
            {
                kohad = 20;
                read = 20;
            }
            else
            {
                kohad = 30;
                read = 20;
            }
            saal = new int[read, kohad];
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);

                }
            }

        }
        static void Saal_ekraanile()
        {
            Console.Write("    ");
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length == 2)
                { Console.Write("{0}", koht + 1); }
                else
                {Console.Write("{0}", koht + 1);}
                
            }
            /*for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    Console.Write(saal[rida, koht]);

                }
                Console.WriteLine();
            }

        }*/
        static bool Muuk()
        {
            Console.WriteLine("Sisesta rida");
            int rida = int.Parse(Console.ReadLine());
            Console.WriteLine("Sisesta koht");
            int pileti_koht = 0;
            int koht = int.Parse(Console.ReadLine());



            if (saal[rida - 1, koht - 1] == 0)
            {
                saal[rida - 1, koht - 1] = 1;
                return true;
            }
            else
            {
                return false;
            }

        }
        static void Main(string[] args)
        {
            int suurus = Saali_suurs();
            Saali_taitmine(suurus);
            while (true)
            {
                Saal_ekraanile();
                bool ost = Muuk();
                Console.WriteLine(ost);
            }


            Console.ReadLine();
        }
    } 
}
