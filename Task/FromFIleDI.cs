using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.IO;
using System.Net;

namespace Task
{
    class FromFIleDI : IFromDI
    {
        public void GetAllCityFrom(string filepath, ref List<City> allcity)
        {
            Console.WriteLine("Чтение из файла " + filepath);
            Compares.Update(new StreamReader(filepath, Encoding.Default), ref allcity);
        }
    }

   
}
