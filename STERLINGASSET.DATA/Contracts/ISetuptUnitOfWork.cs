using STERLINGASSET.DATA.Models;

namespace STERLINGASSET.DATA.Contracts
{
    /// <summary>
    /// Interface for the "Unit of Work"
    /// </summary>
    public interface ISetupUnitOfWork
    {
        // Save pending changes to the data store.
        void Commit();

        ICustomerRepository Customer { get; }
   
    
    }
}