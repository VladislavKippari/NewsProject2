﻿using System;
using System.Collections.Generic;
using System.Text;
using NewsApp.ReposInterfaces.Base;
using NewsApp.Domain.Entities;

namespace NewsApp.ReposInterfaces
{
    public interface IUserRepository : IRepository<User>, IKeyRepository<User, int> 
    {
    }
}
