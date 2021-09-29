using NT.Tasks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Domain.interfaces
{
    public interface ICityRepository:IEntityRepository<City>
    {
        Task<City> GetByName(string name);
    }
}
