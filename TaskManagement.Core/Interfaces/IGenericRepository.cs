﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllQueryAbleAsync();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
