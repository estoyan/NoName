using Noleggio.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Contracts
{
    interface INoleggioDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<RentItem> RentItems { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Lease> Leases { get; set; }

        IDbSet<Category> MainCategory { get; set; }

        void SaveChanges();
    }
}
