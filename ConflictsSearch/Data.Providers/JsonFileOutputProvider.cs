using ConflictsSearch.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConflictsSearch;
using Newtonsoft.Json;
namespace ConflictsSearch.Data.Providers
{
    public class JsonFileOutputProvider : IOutputProvider
    {

        public void WriteData(List<Conflict> conflicts)
        {
            string? outputFilePath = GetOutputPathFromConsole();
            if (conflicts == null || outputFilePath==null)
            {
                return;
            }
            try
            {
                string conflictsJson = JsonConvert.SerializeObject(conflicts);
                WriteToFile(conflictsJson, outputFilePath);
                Console.WriteLine("Conflicts were successfully writed in file");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while writing conflicts to output file! Message: {0}", e.Message);
                return;
            }

        }



        private void WriteToFile(string conflictsJson, string outputFilePath)
        {
                using (StreamWriter stream = new StreamWriter(outputFilePath))
                {
                    stream.Write(conflictsJson);
                }   
        }

        private string? GetOutputPathFromConsole()
        {
            int inputAttempts = 0;
            string? filePath = null;
            while (inputAttempts < 4)
            {
                Console.WriteLine("Enter file path to write conflicts output:");
                filePath = Console.ReadLine();
                if (filePath == null)
                {
                    Console.WriteLine("You must enter file path!");
                    inputAttempts++;
                    continue;
                }
                filePath = filePath.Trim();
                if (!filePath.EndsWith(".json"))
                {
                    Console.WriteLine("Incorrect type of file! You can enter only files with .json ending!");
                    inputAttempts++;
                    continue;
                }
                return filePath;

            }
            Console.WriteLine("All path input attempts were used!");

            return null;
        }
    }
}
