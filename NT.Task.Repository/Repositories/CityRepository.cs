using Microsoft.EntityFrameworkCore;
using NT.Tasks.Domain.interfaces;
using NT.Tasks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Repository.Repositories
{
    internal class CityRepository : EntityRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context) { }
        public Task<City> GetByName(string name)=> this.Query().FirstOrDefaultAsync(r => r.Name == name);
        
    }
}
