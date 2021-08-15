using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace RD.Core.CAP
{
    public abstract class BaseEventHandler<T> : ICapSubscribe where T : IEvent
    {

    }
}
