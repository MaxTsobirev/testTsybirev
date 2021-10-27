using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kordamine
{
    class Program
    {
        static int Saali_suurus()
        {
            Console.WriteLine("Viberi razmer zala"); //выбор размера зала
            int suurus = int.Parse(Console.ReadLine());
            return suurus;
        }
        static int[,] saal = new int[,] { }; // пишет запятую между размерами залов
        static int[] ost = new int[] { };
        static int kohad, read, mitu, mitu_veel;
        static void Saali_taitmine(int suurus)
        {
            Random rnd = new Random();//создание залов:маленький(20 на 10), средний(20 на 20), большой(30 на 20)
            if (suurus == 1)
            { kohad = 20; read = 10; }
            else if (suurus == 2)
            { kohad = 20; read = 20; }
            else
            { kohad = 30; read = 20; }
            saal = new int[read, kohad];
            for (int rida = 0; rida < read; rida++) // заполнение
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);
                }
            }
        }
        static void Saal_ekraanile()
        {
            Console.Write("     "); // выписывает нумерование мест
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length == 2)   
                { Console.Write(" {0}", koht + 1); }
                else //к каждому номеру добавляется +1 тем самым увеличивает число до тех пор пока не кончатся места в зале
                { Console.Write("  {0}", koht + 1); }
            }

            Console.WriteLine();
            for (int rida = 0; rida < read; rida++)
            {
                Console.Write("Rjad " + (rida + 1).ToString() + ":"); // выписывает нумерование рядов
                for (int koht = 0; koht < kohad; koht++)
                {

                    Console.Write(saal[rida, koht] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void Muuk() // покупка нескольких билетов
        {
            Console.WriteLine("Rjad:");
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.WriteLine("Skolko biletov:");
            mitu = int.Parse(Console.ReadLine());
            ost = new int[mitu];
            int p = (kohad - mitu) / 2; //пользователь выбирает место и от него по-очередно слева и справа выбирает еще свободные места до тех пор пока мест не будет столько сколько выбрал человек либо если не будет занятых мест
            bool t = false;
            int k = 0;
            do
            {
                if (saal[pileti_rida, p] == 0)// если в зале на каком либо месте стоит 0 то оно свободно
                {
                    ost[k] = p;
                    Console.WriteLine("mesto {0} svobodno", p); // если место свободно
                    t = true;
                }
                else
                {
                    Console.WriteLine("mesto {0} zanjato", p); //если место занято то программа ищет свободные места от другого места
                    t = false;
                    ost = new int[mitu];
                    k = 0;
                    p = (kohad - mitu) / 2;
                    break;
                }
                p = p + 1;// + к месту
                k++;
            } while (mitu != k);
            if (t == true)
            {
                Console.WriteLine("Vashi mesta:"); // показывает места которые выбрал пользователь
                foreach (var koh in ost)
                {
                    Console.WriteLine("{0}\n", koh);
                }
            }
            else
            {
                Console.WriteLine("V etom rjadu net mest, hotite iskatj v sledujushem rjadu?");//если среди выбранных мест есть занятое
            }
        }
        
    }
}
