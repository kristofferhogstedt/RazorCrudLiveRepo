using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLiveDemo.Data;
using RazorLiveDemo.ViewModels;

namespace RazorLiveDemo.Pages.Employees
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public UpdateEmployeeViewModel UpdateEmployeeVM { get; set; }

        private readonly ApplicationDbContext _dbContext;

        public UpdateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(Guid Id)
        {
            var employeeDB = _dbContext.Employees.Find(Id);

            if (employeeDB != null)
            {
                UpdateEmployeeVM = new UpdateEmployeeViewModel()
                {
                    Id = employeeDB.Id,
                    Name = employeeDB.Name,
                    Email = employeeDB.Email,
                    DateOfBirth = employeeDB.DateOfBirth,
                    Salary = employeeDB.Salary,
                    Department = employeeDB.Department
                };
            }
        }

        public void OnPost()
        {
            var employeeToUpdateDB = _dbContext.Employees.Find(UpdateEmployeeVM.Id);

            if (ModelState.IsValid)
            {
                // Mappar från ViewModel till DB Model
                employeeToUpdateDB.Name = UpdateEmployeeVM.Name;
                employeeToUpdateDB.Email = UpdateEmployeeVM.Email;
                employeeToUpdateDB.Salary = UpdateEmployeeVM.Salary;
                employeeToUpdateDB.DateOfBirth = UpdateEmployeeVM.DateOfBirth;
                employeeToUpdateDB.Department = UpdateEmployeeVM.Department;

                _dbContext.SaveChanges();

                ViewData["Message"] = "Employee updated successfully!";
            }
        }
    }
}
