using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Task.Test
{
    [TestClass]
    public class TaskUnitTest
    {
        string path = @"datafortes\";
        string filename = @"fortest.txt";
        [TestInitialize]
        public void TestInitialize()
        {
            string[] _data = new string[] { "Санкт-Петербург,100", "Минск,99", "минск,1", "Молодечно,40", "Березинское,56", "圣彼得堡,5666", "מינסק,7777" };
            Directory.CreateDirectory(path);
            File.WriteAllLines(path + filename, _data, System.Text.Encoding.UTF8);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(path + filename);
            Directory.Delete(path);
            File.Delete("output.txt");
        }

        [TestMethod]
        public void ProgramMainTestForInManyLanguagesBinarySearch()
        {
            //arrange
            string[] expectedmas = new string[] { "Санкт-Петербург,100", "Минск,100","Молодечно,40", "Березинское,56", "圣彼得堡,5666", "מינסק,7777" };
            string expected = String.Join(Environment.NewLine, expectedmas);
            // act
            Program.Main(new string[] { path });
            string[] actualmas = File.ReadAllLines("output.txt", System.Text.Encoding.Default);
            string actual = String.Join(Environment.NewLine, actualmas);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
