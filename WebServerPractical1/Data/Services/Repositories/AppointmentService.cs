using Microsoft.AspNetCore.Components.Authorization;
using WebServerPractical1.Data.Entities;
using WebServerPractical1.Data.Models;
using WebServerPractical1.Data.Services.Contracts;
using WebServerPractical1.Extensions;

namespace WebServerPractical1.Data.Services.Repositories
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext salesManagementDbContext;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AppointmentService(ApplicationDbContext salesManagementDbContext,
                                  AuthenticationStateProvider authenticationStateProvider)
        {
            this.salesManagementDbContext = salesManagementDbContext;
            this.authenticationStateProvider = authenticationStateProvider;
        }
        public async Task AddAppointment(AppointmentModel appointmentModel)
        {
            try
            {

                Appointment appointment = appointmentModel.Convert();
                await this.salesManagementDbContext.AddAsync(appointment);
                await this.salesManagementDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<AppointmentModel>> GetAppointments()
        {
            try
            {          
                return await this.salesManagementDbContext.Appointments.Where(e => e.EmployeeId == 9).Convert();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteAppointment(int id)
        {
            try
            {
                Appointment? appointment = await this.salesManagementDbContext.Appointments.FindAsync(id);

                if (appointment != null)
                {
                    this.salesManagementDbContext.Remove(appointment);
                    await this.salesManagementDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task UpdateAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                Appointment? appointment = await this.salesManagementDbContext.Appointments.FindAsync(appointmentModel.Id);

                if (appointment != null)
                {
                    appointment.Description = appointmentModel.Description;
                    appointment.IsAllDay = appointmentModel.IsAllDay;
                    appointment.RecurrenceId = appointmentModel.RecurrenceId;
                    appointment.RecurrenceRule = appointmentModel.RecurrenceRule;
                    appointment.RecurrenceException = appointmentModel.RecurrenceException;
                    appointment.StartTime = appointmentModel.StartTime;
                    appointment.EndTime = appointmentModel.EndTime;
                    appointment.Location = appointmentModel.Location;
                    appointment.Subject = appointmentModel.Subject;

                    await salesManagementDbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}