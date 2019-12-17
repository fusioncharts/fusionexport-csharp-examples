using System;
using System.Collections.Generic;
using FusionCharts.FusionExport.Client; // Import sdk

namespace Examples
{
   public static class GoogleCharts_Exp
   {
      public static void Run(string host = Constants.DEFAULT_HOST, int port = Constants.DEFAULT_PORT)
      {
         // Instantiate the ExportConfig class and add the required configurations
         ExportConfig exportConfig = new ExportConfig();
         List<string> results = new List<string>();

         // Instantiate the ExportManager class
         using (ExportManager exportManager = new ExportManager())
         {
            string templateFilePath = System.Environment.CurrentDirectory + "\\..\\..\\resources\\template_googlecharts.html";

            exportConfig.Set("templateFilePath", templateFilePath);
            exportConfig.Set("type", "pdf");
            exportConfig.Set("templateFormat", "A4");
            exportConfig.Set("asyncCapture", true);

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
