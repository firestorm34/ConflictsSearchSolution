using System.Collections;
using ConflictsSearch.Dtos;

namespace ConflictsSearchTests
{
    public class DeviceInfosAndConflictsTestData : IEnumerable<object[]>
    {
        private IEnumerable<object[]> testData = new List<object[]> { 
                new object[] {
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

                },

                new object[] {
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

                },

                new object[] {
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

                },

                new object[] {
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

                }
            
            };
      
        public IEnumerator<object[]> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return testData.GetEnumerator();
        }
    }
}