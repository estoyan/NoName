using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Common
{
    public class TimeProvider : ITimeProvider
    {

        DateTime ITimeProvider.GetTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
