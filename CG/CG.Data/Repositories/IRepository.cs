﻿namespace CG.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using CG.Contracts;

    public interface IRepository<T>
        where T : IEntity
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        void Detach(T entity);

        void UpdateValues(Expression<Func<T, object>> entity);
    }
}