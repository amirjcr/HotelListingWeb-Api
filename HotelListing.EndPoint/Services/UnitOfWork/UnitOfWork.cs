using System;
using HotelListing.EndPoint.Services.IRepositories;
using HotelListing.EndPoint.Data.Entities;
using System.Threading.Tasks;
using HotelListiing.EndPoint.Data;
using HotelListing.EndPoint.Services.Repositories;

namespace HotelListing.EndPoint.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        private IGenericRepository<Country> countries;
        private IGenericRepository<Hotel> hotels;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public IGenericRepository<Country> Countries => countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => hotels ??= new GenericRepository<Hotel>(_context);

        public async Task<int> Commit() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}