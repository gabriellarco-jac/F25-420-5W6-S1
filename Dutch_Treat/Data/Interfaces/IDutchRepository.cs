﻿namespace Dutch_Treat.Data.Interfaces
{
    public interface IDutchRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveAll();
    }
}
