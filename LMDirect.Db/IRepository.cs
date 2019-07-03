using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Db
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(dynamic id) where T : class, new();
        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> whereExpression = null) where T : class, new();
        Task<int> CountAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
        Task<int> MaxAsync<T>(Expression<Func<T, int>> expression) where T : class, new();
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
        Task<bool> InsertAsync<T>(List<T> insertObj) where T : class, new();
        Task<bool> InsertAsync<T>(T insertObj) where T : class, new();
        Task<bool> UpdateAsync<T>(T updateObjs) where T : class, new();
        Task<bool> UpdateAsync<T>(List<T> updateObj) where T : class, new();
        Task<bool> DeleteAsync<T>(T deleteObj) where T : class, new();
        Task<bool> DeleteAsync<T>(List<T> deleteObjs) where T : class, new();
        Task<bool> DeleteAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();        
        int ExecuteCommand(string sql, object parameters);
    }
}
