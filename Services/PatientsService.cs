using GRProntAPP.Context;
using GRProntAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GRProntAPP.Services
{
    public class PatientsService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            try
            {
                return await _context.Patients.ToListAsync();
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao obter os pacientes.");
            }
        }

        public async Task<Patient> GetPatientById(int id)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id);
                if(patient == null)
                {
                    throw new Exception("Paciente não encontrado.");
                }
                return patient;

            }
            catch
            {
                throw new Exception("Ocorreu um erro ao obter o paciente por ID.");

            }
        }

        public async Task<IEnumerable<Patient>> GetPatientsByName(string name)
        {
            IEnumerable<Patient> patients;
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    patients = await _context.Patients
                        .Where(p => p.Name.Contains(name))
                        .ToListAsync();
                }
                else
                {
                    patients = await GetPatients();
                }
                return patients;
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao obter os pacientes por nome.");
            }
        }

        public async Task CreatePatient(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao criar o paciente.");
            }
        }

        public async Task UpdatePatient(Patient patient)
        {
            try
            {
                _context.Entry(patient).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao criar o paciente.");
            }
        }

        public async Task DeletePatient(Patient patient)
        {
            try
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao remover o paciente.");
            }
        }
       
    }
}
