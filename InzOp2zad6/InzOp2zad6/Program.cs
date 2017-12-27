using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzOp2zad6
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.OpenRead("plik.txt");
            byte[] buffer = new byte[1000];
            fs.BeginRead(buffer, 0, buffer.Length, myAsyncCallback, new object[]{ fs, buffer});
            Console.ReadKey();
        }

        static void myAsyncCallback (IAsyncResult state) {
            object[] fsAndBuffer = (object[]) state.AsyncState;
            FileStream fs = (FileStream)fsAndBuffer[0];
            byte[] buffer = (byte[])fsAndBuffer[1];
            int l = fs.EndRead(state);
            string tresc = Encoding.UTF8.GetString(buffer, 0, l);
            Console.Out.WriteLine(tresc);
        }

    }
}
