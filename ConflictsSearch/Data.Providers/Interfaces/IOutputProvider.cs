using ConflictsSearch.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictsSearch.Data.Providers
{
    public interface IOutputProvider
    {
        public void WriteData(List<Conflict> conflicts);
    }
}
