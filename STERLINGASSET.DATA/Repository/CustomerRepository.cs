using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using STERLINGASSET.DATA.Contracts;

using System.Linq;
using STERLINGASSET.DATA.Models;

namespace STERLINGASSET.DATA.Repository
{
    
    public class CustomerRepository : EFRepository<TblAssetCustomer>, ICustomerRepository
    {
        
        public CustomerRepository(STERLINGASSETContext context) : base(context) { } 

        public IQueryable<TblAssetCustomer> ValidateCustomer(int customerId)
        {
            return dbSet.Where(ps => ps.CustomerId == customerId);
        }
    }
}
