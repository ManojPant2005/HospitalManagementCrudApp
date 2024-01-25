namespace WebServerPractical1.Data.Models
{
    public class DashboardResponse<T> where T : class
    {
        public int TotalPatient { get; set; }
        public int TotalAppointment { get; set; }
        public int TodaysAppointment { get; set; }
        public int PendingAppointment { get; set; }
        public IEnumerable<T> list { get; set; }
    }
}
