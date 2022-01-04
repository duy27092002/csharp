using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public interface IBaseDAO<T, U>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(U id);

        Task<List<T>> GetByKeyword(string keyword);

        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(U id);
    }
}