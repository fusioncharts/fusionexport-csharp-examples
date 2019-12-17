using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FusionCharts.FusionExport.Client; // Import sdk

namespace Examples
{
   public static class example_5_set_header_footer
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
            exportConfig.Set("headerEnabled", "true");
            exportConfig.Set("footerEnabled", "true");
            exportConfig.Set("headerComponents", "{ \"title\": { \"style\": \"color:blue;\" } }");
            exportConfig.Set("footerComponents", "{ \"pageNumber\": { \"style\": \"color:green;\" } }");

            // Call the Export() method with the export config
            results.AddRange(exportManager.Export(exportConfig));
         }

         foreach (string path in results)
         {
            Console.WriteLine(path);
         }

         Console.Read();

      }
   }
}
