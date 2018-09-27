using Microsoft.EntityFrameworkCore;
using System;
using STERLINGASSET.DATA;
using STERLINGASSET.DATA.Contracts;
using STERLINGASSET.DATA.Models;
using STERLINGASSET.DATA.Helpers;

namespace STERLINGASSET.DATA
{
    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Person"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class SetupUnitOfWork : ISetupUnitOfWork, IDisposable
    {
        private STERLINGASSETContext DbContext = new STERLINGASSETContext();
        public SetupUnitOfWork(IRepositoryProvider repositoryProvider)
        {
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }
        protected IRepositoryProvider RepositoryProvider { get; set; }

        // Define repositories
 
        public ICustomerRepository Customer { get { return GetEntityRepository<ICustomerRepository>(); } }
    
        
        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

     

      
        private IRepository<T> GetStandardRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetEntityRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

    
        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}