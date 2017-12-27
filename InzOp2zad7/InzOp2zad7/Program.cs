using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzOp2zad7
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.OpenRead("file.txt");
            byte [] buffer = new byte[1000];
            var IAsync = fs.BeginRead(buffer, 0, buffer.Length, null, "argument, ktory nie jest nigdzie wykorzystywany");
            //tu moga być wykonywane operacje asynchronicznie do czytania
            //np.
            for (int i = 0; i < 1000000; i++)
                i = i + 1;
            int l = fs.EndRead(IAsync);
            string tresc = Encoding.UTF8.GetString(buffer, 0, l);
            fs.Close();
            Console.WriteLine(tresc);
            Console.ReadKey();
        }

     
    }
}
