using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected readonly FootballAssociationDbContext _context;
        protected readonly IMapper _mapper;

        public BaseService(FootballAssociationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual List<TModel> Get(TSearch search)
        {
            var list = _context.Set<TDatabase>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }
        public virtual TModel GetById(int id)
        {
            var e = _context.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(e);
        }
    }
}
