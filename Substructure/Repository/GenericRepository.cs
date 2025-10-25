using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SweaterPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace SweaterPlanning.Substructure.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal CodeDbSet context;
        private Microsoft.EntityFrameworkCore.DbSet<TEntity> dbSet;
        public GenericRepository(CodeDbSet context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>(); 
        }

        public virtual async Task<dynamic> Add(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
               return await Save(1);
            }
            catch (Exception )
            {

                throw;
            }
        }

        public virtual async Task<dynamic> Delete(int Id)
        {
            try
            {
                TEntity entity = dbSet.Find(Id);
                dbSet.Attach(entity);
                context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Deleted;
                return await Save(3);
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public virtual async Task<dynamic> Delete(TEntity entityToDelete)
        {
            try
            {
                //if (context.Entry(entityToDelete).State == EntityState.Detached)
                //{
                //    dbSet.Attach(entityToDelete);s
                //}
                dbSet.Remove(entityToDelete);
                return await Save(3);
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                dynamic query = dbSet.Where(predicate);
                return await Task.FromResult(query);
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                IEnumerable<TEntity> query = dbSet;
                return await Task.FromResult(query.ToList());
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public virtual async Task<TEntity> GetByID(int Id)
        {
            try
            {
                return await Task.FromResult(dbSet.Find(Id));
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<int> GetMaxID(Expression<Func<TEntity, int>> predicate)
        {
            dynamic result = dbSet.Max(predicate) + 1;
            return await Task.FromResult(result);
        }

        public virtual async Task<dynamic> Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Modified;
                return await Save(2);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.ToString()) ;
            }
            
        }




        public async Task<dynamic> Save(int option)
        {
            try
            {
                var res = await Task.FromResult(context.SaveChangesAsync());
                if (await res == 1 && option == 1)
                {
                    return "Data Saved Successfully";
                }
                if (await res == 1 && option == 2)
                {
                    return "Data Update Successfully";
                }
                if (await res == 1 && option == 3)
                {
                    return "Data Deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return null;
        }

      public async  Task<IEnumerable<TEntity>> StoreProcedure(string command)
        {
            try
            {
                dynamic result = dbSet.FromSqlRaw(command).ToList();
                return await Task.FromResult( result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
