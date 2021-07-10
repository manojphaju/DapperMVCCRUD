using CRUDDapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDDapper.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewAll"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if(id==0)
            return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@employeeId", id);
                return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewById", param).FirstOrDefault<EmployeeModel>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel emp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("employeeId", emp.EmployeeId);
            param.Add("name", emp.Name);
            param.Add("position", emp.Position);
            param.Add("age", emp.Age);
            param.Add("salary", emp.Salary);
            DapperORM.ExecuteWithoutReturn("EmployeeAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("employeeId", id);
            DapperORM.ExecuteWithoutReturn("EmployeeDeleteById", param);
            return RedirectToAction("Index");
        }
    }
}