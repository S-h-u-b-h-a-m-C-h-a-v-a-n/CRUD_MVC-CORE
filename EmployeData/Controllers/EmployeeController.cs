using EmployeData.DAL;
using EmployeData.Models;
using EmployeData.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeData.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {

            var employees = _context.Employees.ToList();
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            if (employees != null)
            {
                
                foreach (var employee in employees)
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    { 
                        Id = employee.Id,
                        First_Name= employee.First_Name,
                        Last_Name = employee.Last_Name,
                        DateOfBirth = employee.DateOfBirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };

                    employeeList.Add(EmployeeViewModel);
                }

                return View(employeeList);
            }

            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        First_Name = employeeData.First_Name,
                        Last_Name = employeeData.Last_Name,
                        DateOfBirth = employeeData.DateOfBirth,
                        Email = employeeData.Email,
                        Salary = employeeData.Salary
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["SuccessMassage"] = "Employee Created SuccesFully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["eroorMassage"] = "Model data is Not Valid.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["eroorMassage"] = ex.Message;
                return View();

            }

            
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var emolpyee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (emolpyee != null)
                {
                    var emolpyeeView = new EmployeeViewModel()
                    {
                        Id = emolpyee.Id,
                        First_Name = emolpyee.First_Name,
                        Last_Name = emolpyee.Last_Name,
                        DateOfBirth = emolpyee.DateOfBirth,
                        Email = emolpyee.Email,
                        Salary = emolpyee.Salary
                    };

                    return View(emolpyeeView);
                }
                else
                {
                    TempData["errorMassage"] = $"Employee  Details Not Availiable with the Id :  {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMassage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        DateOfBirth = model.DateOfBirth,
                        Email = model.Email,
                        Salary = model.Salary

                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["SuccessMassage"] = "Employee Details Updated Successfully! ";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["errorMassage"] = "Model Data is In-valid";
                    return View();

                }
            }
            catch (Exception ex)
            {

                TempData["errorMassage"] = ex.Message;
                return View();
            }
                
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var emolpyee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (emolpyee != null)
                {
                    var emolpyeeView = new EmployeeViewModel()
                      {
                        Id = emolpyee.Id,
                        First_Name = emolpyee.First_Name,
                        Last_Name = emolpyee.Last_Name,
                        DateOfBirth = emolpyee.DateOfBirth,
                        Email = emolpyee.Email,
                        Salary = emolpyee.Salary
                    };

                    return View(emolpyeeView);
                }
                else
                {
                    TempData["errorMassage"] = $"Employee  Details Not Availiable with the Id :  {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMassage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(EmployeeViewModel model)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == model.Id);

                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["SuccessMassage"] = "Employee Deleted Successfully";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["errorMassage"] = $"Employee  Details Not Availiable with the Id :  {model.Id}";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {


                TempData["errorMassage"] = ex.Message;
                return View();

            }
            
        }
    }

}
