using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace ThirdPartyLibraries
{
    public class JSonCSV
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\Gharat\source\repos\ThirdPartyLibraries\ThirdPartyLibraries\Utility\Address.csv";
            string exportFilePath = @"C:\Users\Gharat\source\repos\ThirdPartyLibraries\ThirdPartyLibraries\AddressDetails.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data reading done successfully");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.Write("\n");

                }
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, records);
                }
            }
        }
        public static void JsonToCSV()
        {
            string importFile = @"C:\Users\Gharat\source\repos\ThirdPartyLibraries\ThirdPartyLibraries\AddressDetails.json";
            string exortFile = @"C:\Users\Gharat\source\repos\ThirdPartyLibraries\ThirdPartyLibraries\JsonToCSV.csv";
            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFile));

            using (var writer = new StreamWriter(exortFile))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressData);
            }

        }
    }
}
