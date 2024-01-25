using WebServerPractical1.Data.Entities;
using WebServerPractical1.Data.Models;

namespace WebServerPractical1.Data.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetEmployees();
        Task<List<EmployeeJobTitle>> GetJobTitles();
        Task<List<ReportToModel>> GetReportToEmployees();
        Task<Employee> AddEmployee(EmployeeModel employeeModel);
        Task UpdateEmployee(EmployeeModel employeeModel);
        Task DeleteEmployee(int id);
    }
}
