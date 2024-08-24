using ConflictsSearch.Data.Providers;
using ConflictsSearch.Dtos;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ConflictsSearch
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, User!");

            JsonFileInputProvider inputProvider = new JsonFileInputProvider();
            List<DeviceInfo>? DeviceInfos = inputProvider.LoadData();
            if(DeviceInfos != null)
            {
                List<Conflict>? conflicts = ConflictsSeeker.FindAllConflicts(DeviceInfos);
                JsonFileOutputProvider outputProvider = new JsonFileOutputProvider();
                outputProvider.WriteData(conflicts);
            }

            Console.WriteLine("Program finished");
            Console.ReadKey();

        }

    }
}