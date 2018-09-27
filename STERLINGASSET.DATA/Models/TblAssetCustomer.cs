using System;
using System.Collections.Generic;

namespace STERLINGASSET.DATA.Models
{
    public partial class TblAssetCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNo { get; set; }
        public string CustomerSex { get; set; }
        public DateTime? CustomerDob { get; set; }
        public string CustomerStatus { get; set; }
    }
}
