using AutoMapper;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>
        ,ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase:class
    {
        public BaseCRUDService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper){}

        public virtual TModel Insert(TInsert request)
        {
            var e = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(e);

            _context.SaveChanges();

            return _mapper.Map<TModel>(e);
        }

        public virtual TModel Update(int Id, TUpdate request)
        {
            var e = _context.Set<TDatabase>().Find(Id);
            _context.Set<TDatabase>().Attach(e);
            _context.Set<TDatabase>().Update(e);
            _mapper.Map(request, e);

            _context.SaveChanges();

            return _mapper.Map<TModel>(e);
        }
    }
}
