using AutoMapper;
using EA.JP.Ecommerce.Model.Categories;
using EA.JP.Ecommerce.Model.Products;
using EA.JP.Ecommerce.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            // Product Title
            Mapper.CreateMap<ProductTitle, ProductSummaryView>();
            Mapper.CreateMap<ProductTitle, ProductView>();
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();

            // Category
            Mapper.CreateMap<Category, CategoryView>();

            // IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();

            // Global Money Formatter
           //Mapper.AddFormatter<MoneyFormatter>();

        }
    }

    public class MoneyFormatter : IValueResolver 
    {
        //public string FormatValue(ResolutionContext context)
        //{
        //    if (context.SourceValue is decimal)
        //    {
        //        decimal money = (decimal)context.SourceValue;

        //        return money.FormatMoney();
        //    }

        //    return context.SourceValue.ToString();
        //}

        public object GetFormat(Type formatType)
        {
            throw new NotImplementedException();
        }

        public ResolutionResult Resolve(ResolutionResult context)
        {
            //if (context.Value is decimal)
            //{
            //    decimal money = (decimal)context..Value;

            //    return string.Format("{0:C}", money);
            //}

            //return context.SourceValue.ToString();
            throw new NotImplementedException();
        }
    }
}
