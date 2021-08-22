using System;
using HotelListing.EndPoint.Services.IRepositories;
using HotelListing.EndPoint.Data.Entities;
using System.Threading.Tasks;



namespace HotelListing.EndPoint.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }

        Task<int> Commit();
    }
}