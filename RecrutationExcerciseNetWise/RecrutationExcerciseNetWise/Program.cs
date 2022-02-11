using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using RestSharp;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = (new WebClient()).DownloadString("https://catfact.ninja/fact");

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
