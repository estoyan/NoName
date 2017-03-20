using System;

namespace Noleggio.Common
{
    public interface ITimeProvider
    {
        DateTime GetTime { get; }
    }
}