using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STERLINGASSET.DATA.Models;
using STERLINGASSET.DATA.Contracts;

namespace STERLINGASSET.Controllers
{
    public class CustomerController : Controller
    {
        string[] Gender= {"Male","Female" };
        string[] Status = { "Single", "Married", "Divorce" };
        
        public ISetupUnitOfWork SetupUnitOfWork { get; set; }
        public CustomerController(ISetupUnitOfWork uowSetup)
        {
            SetupUnitOfWork = uowSetup;
        }
        public IActionResult Index()
        {
            ViewBag.Sex = Gender;
            ViewBag.status = Status;
            return View();
        }

        public JsonResult AddCustomer(TblAssetCustomer CustomerInfo)
        {
            SetupUnitOfWork.Customer.Add(CustomerInfo);
            SetupUnitOfWork.Commit();
            return Json(CustomerInfo.CustomerId);

        }
        public JsonResult UpdateCustomer(TblAssetCustomer CustomerInfo)
        {
            SetupUnitOfWork.Customer.Update(CustomerInfo);
            SetupUnitOfWork.Commit();
            return Json(CustomerInfo.CustomerId);
        }
        public JsonResult DeleteCustomer(TblAssetCustomer CustomerInfo)
        {
            SetupUnitOfWork.Customer.Delete(CustomerInfo);
            SetupUnitOfWork.Commit();
            return Json(CustomerInfo.CustomerId);
        }

        public JsonResult listcustomer(TblAssetCustomer CustomerInfo)
        {
            var result =SetupUnitOfWork.Customer.GetAll();
            return Json(result);

        }
    }
}