﻿using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ValidCredentials(string identifier, string password);
        Task<ArchiveUser> GetArchiveUser(string identifier);
        Task<Query<ArchiveUser>> RegisterUser(string userName, string email, string password);
    }
}