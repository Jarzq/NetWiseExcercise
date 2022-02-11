using System;
using System.IO;
using System.Net;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            var check = 1;
            string fileName = @"test.txt";
            StreamWriter streamWriter;

            while (check != 0)
            {
                Console.WriteLine("\nwrite '1' to send request, write '0' to exit");
                check = int.Parse(Console.ReadLine());
                if (check==1)
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    string json = new WebClient().DownloadString("https://catfact.ninja/fact");



                    if (!File.Exists(fileName))
                    {
                        streamWriter = File.CreateText(fileName);
                        Console.WriteLine($"created new file: {fileName}");
                    }
                    else
                    {
                        streamWriter = new StreamWriter(fileName, true);
                    }
                    streamWriter.WriteLine(json);
                    streamWriter.Close();

                    Console.WriteLine($"\nnew line: {json}");

                }
                

            }
        }
    }
}
