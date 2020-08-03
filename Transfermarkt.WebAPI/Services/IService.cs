using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Transfermarkt.WebAPI.Services
{
    public interface IService<T, TSearch>
    {
        List<T> Get(TSearch search);
        T GetById(int id);
    }
}
