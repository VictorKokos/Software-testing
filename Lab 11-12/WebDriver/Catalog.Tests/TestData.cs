// File: TestData.cs
using System.IO;

namespace WebDriver
{
    public class TestData
    {
        private static string _filePath = @"D:\Work\3k2s\testirovanie\1.txt";

        public static string[] GetLoginData()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}