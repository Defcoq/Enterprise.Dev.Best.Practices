using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EA.DAL.ORM.Library.Repository.EF.DataContextStorage;

namespace EA.DAL.ORM.Library.Repository.EF
{
    public class DataContextFactory
    {      
        public static LibraryDataContext GetDataContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer(); 

            LibraryDataContext libraryDataContext = _dataContextStorageContainer.GetDataContext();
            if (libraryDataContext == null)
            {
                libraryDataContext = new LibraryDataContext();
                _dataContextStorageContainer.Store(libraryDataContext);
            }

            return libraryDataContext;            
        }       
    }
}
