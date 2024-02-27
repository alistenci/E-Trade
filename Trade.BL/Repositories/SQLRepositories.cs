using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trade.DAL.Context;
using Trade.DAL.Entities;

namespace Trade.BL.Repositories
{
	public class SQLRepositories<T> : IRepository<T> where T : class
	{
		SQLContext db;
		public SQLRepositories(SQLContext _db)
		{
			db = _db;
		}
		public IQueryable<T> GetAll()
		{
			return db.Set<T>();
		}

		public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
		{
			return db.Set<T>().Where(expression);
		}

		public T GetBy(Expression<Func<T, bool>> expression)
		{
			return db.Set<T>().FirstOrDefault(expression);
		}

		public void Add(T entitiy)
		{
			db.Set<T>().Add(entitiy);
			db.SaveChanges();
		}

		public void Update(T entitiy)
		{
			db.Update(entitiy);
			db.SaveChanges();
		}
		public void Delete(T entitiy)
		{
			db.Remove(entitiy);
			db.SaveChanges();
		}

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefaultAsync(expression);
        }
        //public T GetByOrderNumber(string orderNumber)
        //{
        //    return db.Set<T>().Find(orderNumber);
        //}
    }
}