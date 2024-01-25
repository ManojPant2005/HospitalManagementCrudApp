using Microsoft.EntityFrameworkCore;
using WebServerPractical1.Data.Entities;
using WebServerPractical1.Data.Models;
using WebServerPractical1.Data.Services.Contracts;
using WebServerPractical1.Extensions;

namespace WebServerPractical1.Data.Services.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext appDbContext;

        public EmployeeService(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(EmployeeModel employeemodel)
        {
            try
            {
                Employee employeeToAdd = employeemodel.Convert();

                var result = await this.appDbContext.Employees.AddAsync(employeeToAdd);

                await this.appDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                var employee = await this.appDbContext.Employees.FindAsync(id);
                if (employee != null)
                {
                    this.appDbContext.Employees.Remove(employee);
                    await this.appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            try
            {
                return await this.appDbContext.Employees.Convert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeJobTitle>> GetJobTitles()
        {
            try
            {
                return await this.appDbContext.EmployeeJobTitles.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReportToModel>> GetReportToEmployees()
        {
            try
            {
                var employees = await (from e in this.appDbContext.Employees
                                       join j in this.appDbContext.EmployeeJobTitles
                                       on e.EmployeeJobTitleId equals j.EmployeeJobTitleId
                                       where j.Name.ToUpper() == "TL" || j.Name.ToUpper() == "SM"
                                       select new ReportToModel
                                       {
                                           ReportToEmpId = e.Id,
                                           ReportToName = e.FirstName + " " + e.LastName.Substring(0, 1).ToUpper() + "."
                                       }).ToListAsync();
                employees.Add(new ReportToModel { ReportToEmpId = null, ReportToName = "<None>" });

                return employees.OrderBy(o => o.ReportToEmpId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var employeeUpdate = await this.appDbContext.Employees.FindAsync(employeeModel.Id);

                if (employeeUpdate != null)
                {
                    employeeUpdate.FirstName = employeeModel.FirstName;
                    employeeUpdate.LastName = employeeModel.LastName;
                    employeeUpdate.ReportToEmpId = employeeModel.ReportToEmpId;
                    employeeUpdate.DateOfBirth = employeeModel.DateOfBirth;
                    employeeUpdate.ImagePath = employeeModel.ImagePath;
                    employeeUpdate.Gender = employeeModel.Gender;
                    employeeUpdate.Email = employeeModel.Email;
                    employeeUpdate.EmployeeJobTitleId = employeeModel.EmployeeJobTitleId;

                    await this.appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}