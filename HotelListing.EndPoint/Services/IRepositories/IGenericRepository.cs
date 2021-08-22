using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using HotelListing.EndPoint.Models;
using X.PagedList;

namespace HotelListing.EndPoint.Services.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                             List<string> inculde = null
                             );


        Task<IPagedList<T>> GetAll(
            RequestParamter paramter = null
        );

        Task<T> Get(Expression<Func<T, bool>> expression = null,
                    List<string> include = null);
    }
}