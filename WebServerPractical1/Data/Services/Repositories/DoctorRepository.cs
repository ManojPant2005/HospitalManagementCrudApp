using Microsoft.EntityFrameworkCore;
using WebServerPractical1.Data.Entities;
using WebServerPractical1.Data.Services.Contracts;

namespace WebServerPractical1.Data.Services.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<DoctorRepository> _logger;

        public DoctorRepository(ApplicationDbContext appDbContext, ILogger<DoctorRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
        }
        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            try
            {
                var result = await _dbContext.AddAsync(doctor);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);          
            if(doctor == null)
            {
                return false;
            }
            _dbContext.Doctors.Remove(doctor);  
            await _dbContext.SaveChangesAsync();     
            return true;        
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Doctors.Include(x => x.Department).Select(x => new Doctor
                {
                    DoctorID = x.DoctorID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentId = x.DepartmentId,
                    Email = x.Email,
                    Phone = x.Phone,
                    Bio = x.Bio,
                    Salary = x.Salary,
                    PhotoUrl = x.PhotoUrl,
                    Department = new Department { Id = x.DepartmentId, Name = x.Department.Name }
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Doctor>> GetAllAsync(int departmentId)
        {
            try
            {
                return await _dbContext.Doctors.Include(x => x.Department).Select(x => new Doctor
                {
                    DoctorID = x.DoctorID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentId = x.DepartmentId,
                    Email = x.Email,
                    Phone = x.Phone,
                    Bio = x.Bio,
                    Salary = x.Salary,
                    PhotoUrl = x.PhotoUrl,
                    Department = new Department { Id = x.DepartmentId, Name = x.Department.Name }
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public async Task<Doctor> GetAsync(int id)
        {
            try
            {
                var result = await _dbContext.Doctors.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            try
            {
                if (doctor == null) return false;

                _dbContext.Entry(doctor).State = EntityState.Modified;

                var result = await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
