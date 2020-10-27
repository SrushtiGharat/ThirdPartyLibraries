using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;

namespace ThirdPartyLibraries
{
    public class CSVHandler
    {
        
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\Gharat\source\repos\ThirdPartyLibraries\ThirdPartyLibraries\Utility\Address.csv";
            string exportFilePath = @"C:\Users\Gharat\source\repos\ThirdPartyLibraries\ThirdPartyLibraries\Utility\export.csv";
            using(var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data reading done successfully");
                foreach(AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.Write("\n");

                }
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }


            }
            
        }
    }
}
