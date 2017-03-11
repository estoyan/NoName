using System;

namespace Noleggio.DbModels.Factories
{
    interface ILeaseFactory
    {
        Lease CreateLease(Guid rentItem, Guid user, DateTime startDate, DateTime endDate);

    }
}
