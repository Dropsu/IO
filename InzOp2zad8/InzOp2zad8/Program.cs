using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InzOp2zad8
{
    class Program
    {
        delegate int DelegateType(int liczba);
        static DelegateType f1;
        static DelegateType f2;
        static DelegateType f3;
        static DelegateType f4;


        static void Main(string[] args)
        {
            f1 = new DelegateType(FibIter);
            f2 = new DelegateType(FibRec);
            f3 = new DelegateType(FacIter);
            f4 = new DelegateType(FacRec);

            IAsyncResult ar1 = f1.BeginInvoke(5, null, null);
            IAsyncResult ar2 = f2.BeginInvoke(5, null, null);
            IAsyncResult ar3 = f3.BeginInvoke(5, null, null);
            IAsyncResult ar4 = f4.BeginInvoke(5, null, null);

            int result1 = f1.EndInvoke(ar1);
            int result2 = f2.EndInvoke(ar2);
            int result3 = f3.EndInvoke(ar3);
            int result4 = f4.EndInvoke(ar4);


            Stopwatch sw = new Stopwatch();
            sw.Start();
            f1 = new DelegateType(FacIter);
            ar1 = f1.BeginInvoke(5, null, null);
            f2 = new DelegateType(FacRec);
            ar2 = f2.BeginInvoke(5, null, null);
            f3 = new DelegateType(FibIter);
            ar3 = f3.BeginInvoke(5, null, null);
            f4 = new DelegateType(FibRec);
            ar4 = f4.BeginInvoke(5, null, null);
            int najszybsze = WaitHandle.WaitAny(new WaitHandle[] { ar1.AsyncWaitHandle, ar2.AsyncWaitHandle, ar3.AsyncWaitHandle, ar4.AsyncWaitHandle });
            sw.Stop();
            Console.WriteLine("Najszybciej wykonalo sie:");
            switch (najszybsze)
            {
                case 0:
                    Console.WriteLine("Fibbonaci Iteracyjnie");
                    break;
                case 1:
                    Console.WriteLine("Fibbonaci Rekurencyjnie");
                    break;
                case 2:
                    Console.WriteLine("Silnia Iteracyjnie");
                    break;
                case 3:
                    Console.WriteLine("Silnia Rekurencyjnie");
                    break;
                
            }
            Console.WriteLine("W czasie: {0:00}:{1:00}:{2:000}", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            
            Console.ReadKey();

        }

        static int FibRec (int n)
        {
            if (n < 3)
                return 1;

            return FibRec(n - 2) + FibRec(n - 1);
        }
        static int FibIter(int n)
        {
            int a = 0;
            int b = 1;
            int wynik = 0;
            for (int i = 0; i < n; i++)
            {
                wynik = b += a;
                a = b - a;
            }
            return wynik;
        }
        static int FacRec(int n)
        {
            if (n == 0) return 1;
            else return n * FacRec(n - 1);
        }
        static int FacIter(int n)
        {
            int wynik = 1;
            for (int i = 0; i < n; i++)
            {
                wynik *= i;
            }
            return wynik;
        }

    }
}
