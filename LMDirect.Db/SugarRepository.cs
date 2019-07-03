using LMDirect.Core.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Db
{
    public class SugarRepository : IRepository
    {
        private readonly SqlSugarClient _context;

        public SugarRepository(SqlSugarClient context)
        {
            _context = context;                        
        }

        public async Task<T> GetByIdAsync<T>(dynamic id) where T : class, new()
        {
            return await Task.Run(() => _context.Queryable<T>().InSingle(id));
        }

        public async Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            return await _context.Queryable<T>().SingleAsync(whereExpression);
        }

        public async Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> whereExpression = null) where T : class, new()
        {
            return whereExpression == null ? await _context.Queryable<T>().ToListAsync() : await _context.Queryable<T>().Where(whereExpression).ToListAsync();
        }

        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            return await _context.Queryable<T>().CountAsync(whereExpression);
        }
        public async Task<int> MaxAsync<T>(Expression<Func<T, int>> expression) where T : class, new()
        {
            return await _context.Queryable<T>().MaxAsync(expression);
        }
        public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            return await _context.Queryable<T>().Where(whereExpression).AnyAsync();
        }
        public async Task<bool> InsertAsync<T>(List<T> insertObj) where T : class, new()
        {
            return await _context.Insertable<T>(insertObj).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> InsertAsync<T>(T insertObj) where T : class, new()
        {
            return await _context.Insertable(insertObj).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> UpdateAsync<T>(T updateObj) where T : class, new()
        {
            return await _context.Updateable(updateObj).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> UpdateAsync<T>(List<T> updateObjs) where T : class, new()
        {
            return await _context.Updateable(updateObjs).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> DeleteAsync<T>(T deleteObj) where T : class, new()
        {
            return await _context.Deleteable<T>().Where(deleteObj).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> DeleteAsync<T>(List<T> deleteObjs) where T : class, new()
        {
            return await _context.Deleteable<T>().Where(deleteObjs).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> DeleteAsync<T>(Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            return await _context.Deleteable<T>().Where(whereExpression).ExecuteCommandAsync() > 0;
        }

        public int ExecuteCommand(string sql, object parameters)
        {
            return _context.Ado.ExecuteCommand(sql, parameters);
        }

    }
}
