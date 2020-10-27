using System;

namespace ThirdPartyLibraries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CSV Reader");
            CSVHandler.ImplementCSVDataHandling();
            JSonCSV.ImplementCSVToJSON();
            JSonCSV.JsonToCSV();
        }
    }
}
