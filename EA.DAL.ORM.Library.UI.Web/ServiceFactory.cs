using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using EA.DAL.ORM.Library.Model;
using EA.DAL.ORM.Library.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EA.DAL.ORM.Library.UI.Web
{
    public static class ServiceFactory
    {
        public static LibraryService CreateLibraryService()
        {
            IUnitOfWork uow;
            IBookRepository bookRespository;
            IBookTitleRepository bookTitleRepository;
            IMemberRepository memberRespository;

            string persistenceStrategy = ConfigurationManager.AppSettings["PersistenceStrategy"];

            if (persistenceStrategy == "EF")
            {
                //uow = new Repository.EF.EFUnitOfWork();
                //bookRespository = new Repository.EF.Repositories.BookRepository(uow);
                //bookTitleRepository = new Repository.EF.Repositories.BookTitleRepository(uow);
                //memberRespository = new Repository.EF.Repositories.MemberRepository(uow);

                #region not implemented yet
                uow = new Repository.NH.NHUnitOfWork();
                bookRespository = new Repository.NH.Repositories.BookRepository(uow);
                bookTitleRepository = new Repository.NH.Repositories.BookTitleRepository(uow);
                memberRespository = new Repository.NH.Repositories.MemberRepository(uow);
                #endregion
            }
            else
            {
                uow = new Repository.NH.NHUnitOfWork();
                bookRespository = new Repository.NH.Repositories.BookRepository(uow);
                bookTitleRepository = new Repository.NH.Repositories.BookTitleRepository(uow);
                memberRespository = new Repository.NH.Repositories.MemberRepository(uow);
            }

            return new LibraryService(bookTitleRepository, bookRespository, memberRespository, uow);
        }
    }
}