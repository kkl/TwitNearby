﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace TwitsNearby
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        IUnityContainer _container;

        public UnityControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(Type controllerType)
        {
            if (controllerType == null)
                throw new ArgumentNullException("controllerType");

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format(
                    "Type requested is not a controller: {0}", controllerType.Name),
                    "controllerType");

            return _container.Resolve(controllerType) as IController;
        }

    }
}
