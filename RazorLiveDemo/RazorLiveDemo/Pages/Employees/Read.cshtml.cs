using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorLiveDemo.Data;

namespace RazorLiveDemo.Pages.Employees
{
    public class ReadModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public ReadModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _dbContext.Employees.ToList();
        }
    }
}
