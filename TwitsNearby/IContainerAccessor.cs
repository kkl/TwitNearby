using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace TwitsNearby
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
}
