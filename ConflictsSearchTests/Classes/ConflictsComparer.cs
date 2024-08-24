using ConflictsSearch.Dtos;
using ConflictsSearchTests.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictsSearchTests.Classes
{
    public class ConflictsComparer : IEqualityComparer<Conflict>
    {
        public bool Equals(Conflict? x, Conflict? y)
        {
            
            if (x == null || y == null)
            {
                if (x != y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


            if (x.BrigadeCode == null || y.BrigadeCode ==null)
            {
                if (y.BrigadeCode != y.BrigadeCode)
                {
                    return false;
                }
            }
            else
            {
                if (!x.BrigadeCode.Equals(y.BrigadeCode))
                {
                    return false;
                }
              
            }


            if (x.DevicesSerials == null || y.DevicesSerials == null)
            {
                if (y.DevicesSerials != x.DevicesSerials)
                {
                    return false;
                }
            }
            else 
            { 
                foreach( ( string firstDeviceSerials, string secondDeviceSerials) in x.DevicesSerials.Zip(y.DevicesSerials) )
                {
                    if (!firstDeviceSerials.Equals(secondDeviceSerials))
                    {
                        return false;
                    }
                }
            }

           
            
            return true;

        }

       

        public int GetHashCode([DisallowNull] Conflict obj)
        {
             return obj.GetHashCode();
        }
    }

   
}
public class ConflictsListsComparer : IEqualityComparer<List<Conflict>>
{
    ConflictsComparer conflictsComparer = new ConflictsComparer();
    public bool Equals(List<Conflict>? x, List<Conflict>? y)
    {
        if (x == null || y == null)
        {
            if (x != y)
            {
                return false;
            }
            else { return true; }
        } 

       foreach( (Conflict first, Conflict second) in x.Zip(y))
       {
            if (conflictsComparer.Equals(first, second) != true)
            {
                return false;
            }
       }

        return true;
    }

    public int GetHashCode([DisallowNull] List<Conflict> obj)
    {
        throw new NotImplementedException();
    }
}