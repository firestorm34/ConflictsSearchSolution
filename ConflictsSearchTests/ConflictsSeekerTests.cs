using ConflictsSearch;
using ConflictsSearch.Dtos;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ConflictsSearchTests
{
    public class ConflictsSeekerTests
    {
        [Fact]
        public void FindAllConflicts_DeviceInfoIsNull_ReturnNull()
        {
            List<Conflict> conflicts = ConflictsSeeker.FindAllConflicts(null);

            Assert.Null(conflicts);
        }


        [Theory, MemberData(nameof(GetDeviceInfosAndConflicts))]
        
        public void FindAllConflicts_TheoryMemberDataTest(List<DeviceInfo> deviceInfos, List<Conflict>? expectedConflicts)
        {
            List<Conflict>? conflicts = ConflictsSeeker.FindAllConflicts(deviceInfos);
            ConflictsListsComparer comparer = new();

            Assert.Equal(expectedConflicts, conflicts, comparer);

        }

        [Fact]
        public void FindAllConflicts_DeviceIsNull_ReturnsCorrectConflicts()
        {

           List<DeviceInfo> deviceInfosWithNullDevice =  new List<DeviceInfo>{
                    // DeviceInfo with Device 
                    new DeviceInfo() {
                        Device = null,
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    //1 group 
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "1077782570e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },

                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1269986626e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    //end of 1 group 
               };

           List<Conflict> expectedConflicts = new List<Conflict>{
                   new Conflict{
                        BrigadeCode="1623608074",
                        DevicesSerials= new string[]{ "1077782570e13", "1269986626e13" }
                   }
               };

           List<Conflict>? conflicts = ConflictsSeeker.FindAllConflicts(deviceInfosWithNullDevice);
           ConflictsListsComparer comparer = new();

           Assert.Equal(expectedConflicts, conflicts, comparer);


        }

        [Fact]
        public void FindAllConflicts_BrigadeIsNull_ReturnsCorrectConflicts()
        {

            List<DeviceInfo> deviceInfosWithNullBrigade = new List<DeviceInfo>{
                    // DeviceInfo with Device 
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "1277782570e13" },
                        Brigade = null
                    },
                    //1 group 
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "1077782570e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },

                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1269986626e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    //end of 1 group 
               };

            List<Conflict> expectedConflicts = new List<Conflict>{
                   new Conflict{
                        BrigadeCode="1623608074",
                        DevicesSerials= new string[]{ "1077782570e13", "1269986626e13" }
                   }
               };

            List<Conflict>? conflicts = ConflictsSeeker.FindAllConflicts(deviceInfosWithNullBrigade);
            ConflictsListsComparer comparer = new();

            Assert.Equal(expectedConflicts, conflicts, comparer);


        }


        public static IEnumerable<object[]> GetDeviceInfosAndConflicts()
        {
            yield return new object[] { 
                new List<DeviceInfo>{
                    // 1 group
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "834187674e13" },   
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1553078574e13" },
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    //end of 1 group
                    //2 group 
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "1077782570e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1269986626e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    //end of 2 group 
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "814187674e13" },
                        Brigade = new Brigade(){ Code ="791859686" }
                    } 
               },
               new List<Conflict>{
                   new Conflict{ 
                       BrigadeCode="701859686",
                       DevicesSerials= new string[]{ "834187674e13", "1553078574e13" }
                   },
                   new Conflict{
                        BrigadeCode="1623608074",
                        DevicesSerials= new string[]{ "1077782570e13", "1269986626e13" }
                   }
               }

            };

            yield return new object[] {
                new List<DeviceInfo>{
                    // 1 group
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "834187674e13" },
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1553078574e13" },
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    //end of 1 group
                    
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1077782570e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },

                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1269986626e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "834187674e13" },
                        Brigade = new Brigade(){ Code ="791859686" }
                    }
               },
               new List<Conflict>{
                   new Conflict{
                       BrigadeCode="701859686",
                       DevicesSerials= new string[]{ "834187674e13", "1553078574e13" }
                   }
               }

            };

            yield return new object[] {
                new List<DeviceInfo>{
                    // 1 group
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "834187674e13" },
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1553078574e13" },
                        Brigade = new Brigade(){ Code ="701859686" }
                    },
                    //end of 1 group
                    //2 group 
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "1077782570e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1269986626e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "814187674e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    }
                    //end of 2 group 
               },
               new List<Conflict>{
                   new Conflict{
                       BrigadeCode="701859686",
                       DevicesSerials= new string[]{ "834187674e13", "1553078574e13" }
                   },
                   new Conflict{
                        BrigadeCode="1623608074",
                        DevicesSerials= new string[]{ "1077782570e13", "1269986626e13", "814187674e13" }
                   }
               }

            };

            yield return new object[] {
                new List<DeviceInfo>{
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "834187674e13" },
                        Brigade = new Brigade(){ Code ="711859686" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1553078574e13" },
                        Brigade = new Brigade(){ Code ="721859686" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "1077782570e13" },
                        Brigade = new Brigade(){ Code ="1623608074" }
                    },

                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= false, SerialNumber = "1269986626e13" },
                        Brigade = new Brigade(){ Code ="1633608074" }
                    },
                    new DeviceInfo() {
                        Device = new Device(){ IsOnline= true, SerialNumber = "814187674e13" },
                        Brigade = new Brigade(){ Code ="731859686" }
                    }
               },
               new List<Conflict>{
               }

            };

          

        }
    }
}