﻿using Store.BLL.Interfaces;
using Store.DAL.Repositories;
using System.Diagnostics;

namespace Store.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            //Debug.Write(connection + "\n\n\n\n\n\n\n\n");
            return new UserService(new UnitOfWork(connection));
        }

        public IStoreService CreateStoreService(string connection)
        {
            return new StoreService(new UnitOfWork(connection));
        }

        
    }
}
