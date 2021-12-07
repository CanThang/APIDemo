using APIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Contracts
{
    public interface IHangRepository
    {
        public Task<IEnumerable<Hang>> GetHangs();

        //Tim Hang Theo ID
        public Task<Hang> GetHang(string id);

        public Task<Hang> CreateHang(Hang h);

        public Task UpdateHang(string id, Hang h);

        public Task DeleteHang(string id);

    }
}
