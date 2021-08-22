using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelListiing.EndPoint.Data;
using HotelListing.EndPoint.Models;
using HotelListing.EndPoint.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HotelListing.EndPoint.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;


        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> include = null)
        {
            IQueryable<T> query = _db;

            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }


            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, List<string> inculde = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
                query = query.Where(expression);

            if (inculde != null)
                foreach (var item in inculde)
                    query = query.Include(item);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<T>> GetAll( RequestParamter paramter = null)
        {
            IQueryable<T> query = _db;



            return await query.AsNoTracking().ToPagedListAsync(paramter.PageNumber,paramter.PageSize);
        }
    }
}