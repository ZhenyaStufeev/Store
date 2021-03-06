﻿using Store.DAL.Entities.StoreEntities;
using Store.DAL.EntityFramework;
using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DAL.Identity.StoreManagers
{
    public class ApplicationStoreManager : IStoreManager
    {
        private ApplicationContext DbContext;
        public ApplicationStoreManager(ApplicationContext AppDbContext)
        {
            DbContext = AppDbContext;
        }

        public async Task CreateAsync<T>(T item) where T : class
        {
            await Task.Run(() =>
            {
                DbContext.Set<T>().Add(item);
                DbContext.SaveChanges();
            });
        }

        public async Task<IList<T>> GetItemsAsync<T>() where T : class
        {
            return await Task.Run(() =>
            {
                return DbContext.Set<T>().ToList() ?? null;
            });

        }


        public void Dispose()
        {
            DbContext.Dispose();
        }


    }
}
