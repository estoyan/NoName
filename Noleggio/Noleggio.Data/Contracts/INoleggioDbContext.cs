﻿using Noleggio.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Contracts
{
    public interface INoleggioDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<RentItem> RentItems { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Lease> Leases { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        //IDbSet<Category> MainCategory { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
