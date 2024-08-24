using ConflictsSearch.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictsSearch
{
    public static class ConflictsSeeker
    {
        static public List<Conflict>? FindAllConflicts(List<DeviceInfo>? DeviceInfos)
        {

            if (DeviceInfos != null && DeviceInfos.Count() > 1)
            {

                IEnumerable<IGrouping<string, DeviceInfo>> conflictDeviceGroups = DeviceInfos
                    .Where(deviceInfo => deviceInfo.Device != null && deviceInfo.Brigade != null)
                    .GroupBy(deviceInfo => deviceInfo.Brigade.Code)
                    .Where(deviceGroup => deviceGroup.Count() > 1
                    && deviceGroup.Any(deviceInfo => deviceInfo.Device.IsOnline));


                List<Conflict> conflicts = conflictDeviceGroups.Select(
                    group => new Conflict
                    {
                        BrigadeCode = group.Key,
                        DevicesSerials = group.Select(deviceInfo => deviceInfo.Device.SerialNumber).ToArray()
                    }).ToList();
                return conflicts;

            }
            else
            {
                return null;
            }
        }

    }
}
