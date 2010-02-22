﻿using System;
using System.Web.Mvc;
using BA.MultiMVC.Helpers;
using StructureMap;
using BA.MVC.MultiTenant.Core;
using System.Web.Routing;


namespace BA.MultiMVC.Core
{
    public class ExtensionControllerFactory : StructureMapControllerFactory
    {
        #region Methods

        protected override IController GetControllerInstance(Type controllerType)
        {
            if (RequestContext != null)
            {
                var tenantContext = GetTenantContext(RequestContext);
                return GetControllerInstance(tenantContext, controllerType);

            }
            return null;
        }

        protected virtual TenantContext GetTenantContext(RequestContext request)
        {
            var tenantKey = request.GetTenantKey("default");
            var language = request.GetLanguage("en");
            return new TenantContext(tenantKey, language);
        }

        

        protected virtual IController GetControllerInstance(TenantContext tenantContext, Type controllerType)
        {
            var controller = CreateControllerExtension(tenantContext.TenantKey, controllerType)
                                                 ?? base.GetControllerInstance(controllerType) as BaseController;

            controller.TenantContext = tenantContext;
            return controller;
        }
        private static BaseController CreateControllerExtension(string tenantKey, Type controllerType)
        {
            if (controllerType == null)
                return null;

            string controllerName = tenantKey + controllerType.Name.Replace("Controller", "");

            BaseController controller;
            try
            {
                controller = ObjectFactory.GetNamedInstance(typeof(BaseController), controllerName) as BaseController;
            }
            catch (StructureMapException)
            {
                return null;
            }

            return controller;
        }

       

        #endregion Methods
    }
}