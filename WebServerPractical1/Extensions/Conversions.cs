using Microsoft.EntityFrameworkCore;
using WebServerPractical1.Data;
using WebServerPractical1.Data.Entities;
using WebServerPractical1.Data.Models;

namespace WebServerPractical1.Extensions
{
    public static class Conversions
    {
        public static async Task<List<EmployeeModel>> Convert(this IQueryable<Employee> employees)
        {
            return await (from e in employees
                          select new EmployeeModel
                          {
                              Id = e.Id,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              EmployeeJobTitleId = e.EmployeeJobTitleId,
                              Email = e.Email,
                              DateOfBirth = e.DateOfBirth,
                              ReportToEmpId = e.ReportToEmpId,
                              Gender = e.Gender,
                              ImagePath = e.ImagePath,
                          }).ToListAsync();
        }
        public static Employee Convert(this EmployeeModel employeeModel)
        {
            return new Employee
            {
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                EmployeeJobTitleId = employeeModel.EmployeeJobTitleId,
                Email = employeeModel.Email,
                DateOfBirth = employeeModel.DateOfBirth,
                ReportToEmpId = employeeModel.ReportToEmpId,
                Gender = employeeModel.Gender,
                ImagePath = employeeModel.Gender.ToUpper() == "MALE" ? "/Images/Profile/MaleDefault.jpg"
                                                                    : "/Images/Profile/FemaleDefault.jpg"

            };
        }

        public static Appointment Convert(this AppointmentModel appointmentModel)
        {
            return new Appointment
            {
                EmployeeId = 9,
                Description = appointmentModel.Description,
                IsAllDay = appointmentModel.IsAllDay,
                RecurrenceId = appointmentModel.RecurrenceId,
                StartTime = appointmentModel.StartTime,
                EndTime = appointmentModel.EndTime,
                RecurrenceException = appointmentModel.RecurrenceException,
                RecurrenceRule = appointmentModel.RecurrenceRule,
                Location = appointmentModel.Location,
                Subject = appointmentModel.Subject
            };

        }

        public static async Task<List<AppointmentModel>> Convert(this IQueryable<Appointment> appointments)
        {
            return await (from a in appointments
                          select new AppointmentModel
                          {
                              Id = a.Id,
                              EmployeeId = a.EmployeeId,
                              Description = a.Description,
                              IsAllDay = a.IsAllDay,
                              RecurrenceId = a.RecurrenceId,
                              StartTime = a.StartTime,
                              EndTime = a.EndTime,
                              RecurrenceException = a.RecurrenceException,
                              RecurrenceRule = a.RecurrenceRule,
                              Location = a.Location,
                              Subject = a.Subject
                          }).ToListAsync();

        }

        public static async Task<Employee> GetEmployeeObject(this System.Security.Claims.ClaimsPrincipal user, ApplicationDbContext context)
        {
            var emailAddress = user.Identity.Name;
            var employee = await context.Employees.Where(e => e.Email.ToLower() == emailAddress.ToLower()).SingleOrDefaultAsync();
            return employee;
        }
    }
}
