using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorLiveDemo.Data;
using RazorLiveDemo.ViewModels;

namespace RazorLiveDemo.Pages.Employees;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public CreateModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public CreateEmployeeViewModel CreateEmployeeRequest { get; set; }

    public void OnGet()
    {
    }
        
    public void OnPost()
    {
        var employeeDbModel = new Employee
        {
            Name = CreateEmployeeRequest.Name,
            Email = CreateEmployeeRequest.Email,
            Salary = CreateEmployeeRequest.Salary,
            DateOfBirth = CreateEmployeeRequest.DateOfBirth,
            Department = CreateEmployeeRequest.Department
        };

        _dbContext.Employees.Add(employeeDbModel);
        _dbContext.SaveChanges();

        ViewData["Message"] = "Employee created successfully!";
    }
}
