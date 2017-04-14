using BibliotecaASPNET.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaASPNET
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<LivroRepository ,LivroRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}