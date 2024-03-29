﻿using System;
using System.Web.Mvc;
using StructureMap;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// ControllerFactory that retrieve controllers from the StructureMap repository.
    /// </summary>
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        #region Methods

        protected override IController  GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            IController result;
            try
            {
                result = ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException ex)
            {
                //TODO: use logging framework
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }

            return result;
        }

        #endregion Methods
    }
}