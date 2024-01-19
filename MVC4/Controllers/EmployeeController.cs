using Microsoft.AspNetCore.Mvc;
using MVC4.Models;

namespace MVC4.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> list = null;
        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
                {
                    new Employee() { Id = 1, Name = "Priya", DateOfJoining = new DateOnly(2023, 12, 12), Salary = 12000, Department = "IT" },
                 new Employee() { Id = 2, Name = "Priyanka", DateOfJoining = new DateOnly(2023, 02, 06), Salary = 13000, Department = "HR" },
                  new Employee() { Id = 3, Name = "Nikhil", DateOfJoining = new DateOnly(2019, 06, 12), Salary = 15000, Department = "Sales" }
                };

            }

        }
        public IActionResult Index()
        {
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee) {
            list.Add(employee);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Display(int? id)
        {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                
                    return View(employee);
        
        }
        [HttpPost]
        public IActionResult Delete(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            list.Remove(temp);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
           
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                return View(employee);
        }

       

        [HttpPost]
        public IActionResult Edit(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Employee emp in list)
                {
                    if (emp.Id == temp.Id)
                    {
                        emp.Name = employee.Name;
                        emp.DateOfJoining = employee.DateOfJoining;
                        emp.Salary= employee.Salary;
                        emp.Department = employee.Department;
                        break;
                    }


                }
            }
            return RedirectToAction("Index");

        }


    }
}
