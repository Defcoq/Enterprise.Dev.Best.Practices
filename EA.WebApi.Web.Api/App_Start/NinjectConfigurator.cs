using EA.WebApi.Common;
using EA.WebApi.Common.logging;
using EA.WebApi.Common.Security;
using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.QueryProcessors;
using EA.WebApi.Data.SqlServer.mappings;
using EA.WebApi.Data.SqlServer.QueryProcessors;
using EA.WebApi.Model.InquiryProcessing;
using EA.WebApi.Web.Api.AutomappingConfiguration;
using EA.WebApi.Web.Api.InquiryProcessing;
using EA.WebApi.Web.Api.MaintenanceProcessing;
using EA.WebApi.Web.Api.Security;
using EA.WebApi.Web.Common;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }
        private void AddBindings(IKernel container)
        {
            ConfigureLog4net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureAutoMapper(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
            container.Bind<IAddTaskQueryProcessor>().To<AddTaskQueryProcessor>().InRequestScope();
            container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InSingletonScope();
            container.Bind<ITaskByIdQueryProcessor>().To<TaskByIdQueryProcessor>().InRequestScope();
            container.Bind<IUpdateTaskStatusQueryProcessor>().To<UpdateTaskStatusQueryProcessor>().InRequestScope();
            container.Bind<IStartTaskWorkflowProcessor>().To<StartTaskWorkflowProcessor>().InRequestScope();
            container.Bind<ICompleteTaskWorkflowProcessor>().To<CompleteTaskWorkflowProcessor>().InRequestScope();
            container.Bind<IReactivateTaskWorkflowProcessor>().To<ReactivateTaskWorkflowProcessor>().InRequestScope();
            container.Bind<ITaskByIdInquiryProcessor>().To<TaskByIdInquiryProcessor>().InRequestScope();
            container.Bind<IUpdateTaskQueryProcessor>().To<UpdateTaskQueryProcessor>().InRequestScope();
            container.Bind<ITaskUsersMaintenanceProcessor>().To<TaskUsersMaintenanceProcessor>().InRequestScope();
            container.Bind<IUpdateablePropertyDetector>().To<JObjectUpdateablePropertyDetector>().InSingletonScope();
            container.Bind<IUpdateTaskMaintenanceProcessor>().To<UpdateTaskMaintenanceProcessor>().InRequestScope();
            container.Bind<IPagedDataRequestFactory>().To<PagedDataRequestFactory>().InSingletonScope();
            container.Bind<IAllTasksQueryProcessor>().To<AllTasksQueryProcessor>().InRequestScope();
            container.Bind<IAllTasksInquiryProcessor>().To<AllTasksInquiryProcessor>().InRequestScope();












        }
        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("WebApi2BookDb")))
               .CurrentSessionContext("web")
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
               .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession).InRequestScope();

            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();


        }

        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();

            container.Bind<IAutoMapperTypeConfigurator>().To<StatusEntityToStatusAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<StatusToStatusEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<UserEntityToUserAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<UserToUserEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<NewTaskToTaskEntityAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>().To<TaskEntityToTaskAutoMapperTypeConfigurator>().InSingletonScope();
            container.Bind<IAddTaskMaintenanceProcessor>().To<AddTaskMaintenanceProcessor>().InRequestScope();


        }



        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }

    }
}