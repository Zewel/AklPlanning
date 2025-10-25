using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SweaterPlanning.Substructure.Repository
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int Id);
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<dynamic> Add(T entity);
        Task<dynamic> Update(T entity);
        Task<dynamic> Delete(int Id);
        Task<dynamic> Delete(T entity);
        Task<int> GetMaxID(Expression<Func<T, int>> predicate);
        Task<IEnumerable<T>> StoreProcedure(string command);
    }
}
