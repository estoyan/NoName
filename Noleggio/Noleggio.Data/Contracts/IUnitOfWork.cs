﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
