using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace CalculateOrder {
    class Program {
        private static Dictionary<string, object> data;
        static void Main(string[] args) {
            decimal totPrice =0;
            GetDataFromFile(args[0]);
            for(int i = 1; i < args.Length; ) {
                var value = data[args[i]].ToString();
                if(Convert.ToInt32(value.Split('-')[0]) >= Convert.ToInt32(args[i + 1])) {
                    totPrice = totPrice + (Convert.ToDecimal(value.Split('-')[1]) * Convert.ToInt32(args[i + 1]));
                }
                i = i + 2;
            }
            totPrice = totPrice + (totPrice * 23/100);
            Console.WriteLine("Total price: " + totPrice);
        }

        private static void GetDataFromFile(string inputFile) {
            using (TextFieldParser parser = new TextFieldParser(inputFile)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                data = new Dictionary<string, object>();
                while(!parser.EndOfData) {
                    string[] vals = parser.ReadFields();
                    data.Add(vals[0], vals[1].ToString() + "-" + vals[2].ToString());
                }
            }
        }
    }
}
