using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trade.DAL.Entities;

namespace Trade.BL.Repositories
{
	public interface IRepository<T>
	{
		public IQueryable<T> GetAll();
		public IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
		public T GetBy(Expression<Func<T, bool>> expression);
		public Task<T> GetAsync(Expression<Func<T, bool>> expression);
		public void Add(T entity);
		public void Update(T entity);
		public void Delete(T entity);
        T Get(int id);
        //T GetByOrderNumber(string orderNumber);
    }
}
