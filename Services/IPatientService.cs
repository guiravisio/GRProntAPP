using GRProntAPP.Models;

namespace GRProntAPP.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatientsByName(string name);
        Task CreatePatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(Patient patient);
    }
}
