using Entreprise.Architecture.BBL.Contract;
using Entreprise.Architecture.Repository;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entreprise.Architecture.WebUI
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                
                x.AddRegistry<ProductRegistry>();

            });
        }

        public class ProductRegistry : Registry
        {
            public ProductRegistry()
            {
                For<BBL.Contract.IProductRepository<Model.Product>>().Use<ProductRepository>();
                
            }

        }
    }
}