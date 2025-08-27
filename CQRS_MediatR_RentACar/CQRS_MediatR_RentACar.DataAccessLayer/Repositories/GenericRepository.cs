using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CQRSMediatRDbContext _cQRSMediatRDbContext;

        public GenericRepository(CQRSMediatRDbContext cQRSMediatRDbContext)
        {
            _cQRSMediatRDbContext = cQRSMediatRDbContext;
        }

        public async Task DeleteAsync(T t)
        {
            _cQRSMediatRDbContext.Set<T>().Remove(t);
            await _cQRSMediatRDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _cQRSMediatRDbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _cQRSMediatRDbContext.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T t)
        {
            await _cQRSMediatRDbContext.Set<T>().AddAsync(t);
            await _cQRSMediatRDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _cQRSMediatRDbContext.Set<T>().Update(t);
            await _cQRSMediatRDbContext.SaveChangesAsync();
        }
    }
}
