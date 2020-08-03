using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfermarkt.WebAPI.Services
{
    public interface ICRUDService<TModel, TSearch, TInsert, TUpdate> : IService<TModel,TSearch>
    {
        TModel Insert(TInsert entity);
        TModel Update(int id, TUpdate entity);
    }
}
