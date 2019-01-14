using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz generica con todas las operaciones a ser implementadas
    /// </summary>
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        #region Declaración
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void AddLista(IEnumerable<T> entities, T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        void CommitAndRefreshChanges();
        #endregion
    }
}
