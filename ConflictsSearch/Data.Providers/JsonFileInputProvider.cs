
using ConflictsSearch.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictsSearch.Data.Providers
{
    public class JsonFileInputProvider : IInputProvider
    {
        // в случае исключение/ошибки возвращает null, иначе - List<Device>?
        public List<DeviceInfo>? LoadData()
        {
            string? filePath = GetPathFromConsole();
            if (filePath == null)
            {
                return null;
            }

            string jsonData = "";
            try { 
                jsonData = ReadFromFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reading file! Message: {0}", e.Message);
                return null;
            }

            try
            {
                List<DeviceInfo>? deviceInfos = JsonConvert.DeserializeObject<List<DeviceInfo>>(jsonData);
                Console.WriteLine("Data was successfully read from file");
                return deviceInfos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while deserializing file! Message: {0}", e.Message);
                return null;
            }

        }
        


        private string ReadFromFile(string filePath)
        {
            string json = "";

            using (StreamReader stream = new StreamReader(filePath))
            {
                json = stream.ReadToEnd();
            }
            return json;

        }

        private string? GetPathFromConsole()
        {
            int inputAttempts = 0;
            string? filePath = null;
            while (inputAttempts < 4) { 
                Console.WriteLine("Enter devices infos file path:");
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
