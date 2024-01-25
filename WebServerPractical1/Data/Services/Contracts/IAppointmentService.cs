using WebServerPractical1.Data.Models;

namespace WebServerPractical1.Data.Services.Contracts
{
    public interface IAppointmentService
    {
        Task<List<AppointmentModel>> GetAppointments();
        Task AddAppointment(AppointmentModel appointmentModel);
        Task UpdateAppointment(AppointmentModel appointmentModel);
        Task DeleteAppointment(int id);
    }
}
