using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<MVCEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Employees").Result;
            empList=response.Content.ReadAsAsync<IEnumerable<MVCEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int id =0)
        {
            if(id == 0)
            {
                return View(new MVCEmployeeModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCEmployeeModel>().Result);
            }
            
        }
        [HttpPost]
        public ActionResult AddOrEdit(MVCEmployeeModel emp)
        {
            if (emp.EmployeeId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Employees/" + emp.EmployeeId, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully.";
            }
            return RedirectToAction("Index");
        }
      
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully.";
            return RedirectToAction("Index");
        }
    }
}