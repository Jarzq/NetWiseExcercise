using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            var check = 1;

            while (check != 0)
            {
                Console.WriteLine("Wpisz 1 aby wyslac request, 0 aby zakonczyc");

                check = int.Parse(Console.ReadLine());

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string json = new WebClient().DownloadString("https://catfact.ninja/fact");

                string path = @"testowy.txt";
                StreamWriter sw;

                if (!File.Exists(path))
                {
                    sw = File.CreateText(path);
                    Console.WriteLine("created new file");
                }
                else
                {
                    sw = new StreamWriter(path, true);
                }
                sw.WriteLine(json);
                sw.Close();

                Console.WriteLine(json);
            }



        }
    }
}
