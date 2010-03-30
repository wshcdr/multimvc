﻿using System.Web;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Infrastructure;
using StructureMap;
using BA.MultiMvc.Sample.Models.Infrastructure;

namespace BA.MultiMvc.Sample
{
    public static class Bootstrapper
    {
        #region Methods

        public static void ConfigureStructureMap(string extensionPath)
        {
            ObjectFactory.Initialize(x =>
                                         {
                                             x.AddRegistry(new SampleRegistry(extensionPath));
                                         });
        }

        public static string ExtensionPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/Bin");
            }
        }
        #endregion Methods
    }

    public class SampleRegistry : ExtensionRegistry
    {
        #region Constructors
        
        public SampleRegistry(string extensionPath)
        {
            ForRequestedType<User>()
                .TheDefaultIsConcreteType<User>();
            ForRequestedType<IMembershipService>()
                .TheDefaultIsConcreteType<MembershipService>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<UserRepository>();
            ForRequestedType<IResourceProviderService>()
                .TheDefaultIsConcreteType<ResourceProviderService>();
            ForRequestedType<IResourceRepository>()
                .TheDefaultIsConcreteType<RessourceRepository>();
            ForRequestedType<ICacheService>()
                .TheDefaultIsConcreteType<DefaultCacheService>();


            ScanControllersAndRepositoriesFromPath(extensionPath);
        }

       

        #endregion Constructors
    }
}