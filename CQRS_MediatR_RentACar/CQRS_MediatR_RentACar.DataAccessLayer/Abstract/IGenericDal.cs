using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task InsertAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<List<T>> GetListAsync();
        Task <T> GetByIdAsync(int id);

    }
}
