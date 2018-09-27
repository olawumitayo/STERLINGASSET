using STERLINGASSET.DATA.Contracts;
using STERLINGASSET.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace STERLINGASSET.DATA.Contracts
{
    
   public interface ICustomerRepository : IRepository<TblAssetCustomer>
    {
       
        IQueryable<TblAssetCustomer> ValidateCustomer(int customerId);

    }
}
