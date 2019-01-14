using Layer.DAO.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones del repositorio generico
    /// </summary>
    public abstract class GenericRepository<C, T> : IDisposable, IGenericRepository<T> where T : class where C : DbContext, new()
    {
        #region Declaración
        public C Context { get; set; }
        #endregion

        public GenericRepository()
        {
            Context = new C();
        }

        #region Métodos Públicos
        /// <summary>
        /// Obtención de todos los registros
        /// </summary>
        /// <returns>Lista de Objetos</returns>
        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = Context.Set<T>().AsNoTracking();
            return query;
        }

        /// <summary>
        /// Obtención de elementos en base a una condición
        /// </summary>
        /// <returns>Lista de Objetos</returns>
        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Context.Set<T>().Where(predicate).AsNoTracking();
            return query;
        }

        /// <summary>
        /// Agregar un elemento en la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Obketo</returns>
        public virtual T Add(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Added;
            var obj= Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return obj;
        }

        public virtual void AddLista(IEnumerable<T> entities, T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Added;
            var obj = Context.Set<T>().AddRange(entities);
            Context.SaveChanges();
        }

        //public void AddLista(IEnumerable<T> entities,T entity)
        //{
        //    Context.Entry<T>(entity).State = EntityState.Added;
        //    var obj = Context.Set<T>().AddRange(entities);
        //    Context.SaveChanges();
        //    //return obj;
        //}

        /// <summary>
        /// Eliminar elemento de la base de datos
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            //Context.Entry<T>(entity).State = EntityState.Deleted;
            this.Context.Set<T>().Remove(entity);
            //this.Context.SaveChanges();

            //using (var context = Context)
            //{
            //    var dbSet = context.Set<T>();
            //    dbSet.Attach(entity);
            //    context.Entry(entity).State = EntityState.Deleted;
            //    context.SaveChanges();
            //}
        }

        /// <summary>
        /// Editar elemento
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(T entity)
        {
            using (var context = Context)
            {
                context.Entry<T>(entity).State = EntityState.Detached;
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            //Context.Entry<T>(entity).State = EntityState.Detached;
            //Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Confirmar operación
        /// </summary>
        public virtual void Save()
        {
            Context.SaveChanges();
            //Context.SaveChangesAsync();
        }

        public virtual void CommitAndRefreshChanges()
        {
            Save();
            
            //foreach (var entity in Context.ChangeTracker.Entries())
            //{
            //    entity.Reload();
            //}
        }

        /// <summary>
        /// Liberar objeto
        /// </summary>
        public virtual void Dispose()
        {
            Context.Dispose();
        }

        


        #endregion
    }
}
