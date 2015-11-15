using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.Objects;
using System.Data;
using EA.DAL.ORM.Library.Model;
using System.Data.Entity;

namespace EA.DAL.ORM.Library.Repository.EF
{
    public class LibraryDataContext : DbContext
    {
        private DbSet<Member> _members;
        private DbSet<Book> _books;
        private DbSet<BookTitle> _bookTitles;

        public LibraryDataContext()
            : base("LibraryEntities")  
        {
            //_members = CreateDbSet<Member>();
            //_books = CreateDbSet<Book>();
            //_bookTitles = CreateDbSet<BookTitle>();
            //base.ContextOptions.LazyLoadingEnabled = true;           
        }
      
        public DbSet<Member> Members
        {
            get; set;
        }

        public DbSet<Book> Books
        {
            get; set;
        }
        
        public DbSet<BookTitle> BookTitles
        {
            get; set;
        }
    }
}