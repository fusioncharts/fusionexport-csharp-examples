using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using FusionCharts.FusionExport.Client; // Import sdk

namespace Examples
{
   public static class example_3_export_dashboard
   {
      public static void Run(string host = Constants.DEFAULT_HOST, int port = Constants.DEFAULT_PORT)
      {
         // Instantiate the ExportConfig class and add the required configurations
         ExportConfig exportConfig = new ExportConfig();
         List<string> results = new List<string>();

         // Instantiate the ExportManager class
         using (ExportManager exportManager = new ExportManager())
         {
            string chartConfigFile = System.Environment.CurrentDirectory + "\\..\\..\\resources\\multiple.json";
            string templateFilePath = System.Environment.CurrentDirectory + "\\..\\..\\resources\\template.html";

            exportConfig.Set("chartConfig", chartConfigFile);
            exportConfig.Set("templateFilePath", templateFilePath);
            exportConfig.Set("type", "pdf");
            exportConfig.Set("templateFormat", "A4");

            // Call the Export() method with the export config
            results.AddRange(exportManager.Export(exportConfig));
            //Dictionary<string, Stream> files = exportManager.ExportAsStream(exportConfig);


         }

         foreach (string path in results)
         {
            Console.WriteLine(path);
         }

         Console.Read();

      }
   }
}
