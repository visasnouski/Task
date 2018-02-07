using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Task
{
    class FromWebDI : IFromDI
    {
        public void GetAllCityFrom(string url, ref List<City> allcity)
        {
            Console.WriteLine("Чтение веб-страницы " + url);
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
                Compares.Update(new StreamReader(stream, Encoding.Default), ref allcity);
        }
    }
}
