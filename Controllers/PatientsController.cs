using GRProntAPP.Models;
using GRProntAPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRProntAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Patient>>> GetPatients()
        {
            try
            {
                var patients = await _patientService.GetPatients();
                return Ok(patients);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar pacientes.");
            }
        }

        [HttpGet("PatientByName")]
        public async Task<ActionResult<IAsyncEnumerable<Patient>>> GetPatientsByName([FromQuery] string name)
        {
            try
            {
                var patients = await _patientService.GetPatientsByName(name);
                if (patients == null)
                {
                    return NotFound($"Nenhum paciente encontrado com o nome '{name}'.");
                }
                return Ok(patients);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar pacientes.");
            }
        }

        [HttpGet("{id:int}", Name = "GetPatient")]
        public async Task<ActionResult<IAsyncEnumerable<Patient>>> GetPatient(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound($"Nenhum paciente encontrado com o id '{id}'.");
                }
                return Ok(patient);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar paciente.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Patient patient)
        {
            try
            {
                await _patientService.CreatePatient(patient);
                return CreatedAtRoute(nameof(GetPatient), new { id = patient.Id }, patient);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar paciente.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Patient patient)
        {
            try
            {
                if (id != patient.Id)
                {
                    return BadRequest("O id da rota difere do id do paciente.");
                }

                var patientToUpdate = await _patientService.GetPatientById(id);
                if (patientToUpdate == null)
                {
                    return NotFound($"Nenhum paciente encontrado com o id '{id}'.");
                }

                // Atualiza campos permitidos na entidade rastreada
                patientToUpdate.Name = patient.Name;
                patientToUpdate.DateOfBirth = patient.DateOfBirth;
                patientToUpdate.Gender = patient.Gender;
                patientToUpdate.CPF = patient.CPF;
                patientToUpdate.RG = patient.RG;
                patientToUpdate.Email = patient.Email;
                patientToUpdate.Mobile = patient.Mobile;
                patientToUpdate.Street = patient.Street;
                patientToUpdate.Number = patient.Number;
                patientToUpdate.Complement = patient.Complement;
                patientToUpdate.Neighborhood = patient.Neighborhood;
                patientToUpdate.City = patient.City;
                patientToUpdate.State = patient.State;
                patientToUpdate.ZipCode = patient.ZipCode;
                patientToUpdate.EmergencyContactName = patient.EmergencyContactName;
                patientToUpdate.EmergencyContactPhone = patient.EmergencyContactPhone;
                patientToUpdate.Occupation = patient.Occupation;
                patientToUpdate.Nationality = patient.Nationality;
                patientToUpdate.BloodType = patient.BloodType;
                patientToUpdate.Allergies = patient.Allergies;
                patientToUpdate.MedicalHistory = patient.MedicalHistory;
                patientToUpdate.InsuranceProvider = patient.InsuranceProvider;
                patientToUpdate.Notes = patient.Notes;
                patientToUpdate.UpdatedAt = DateTime.UtcNow;

                await _patientService.UpdatePatient(patientToUpdate);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar paciente.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound($"Nenhum paciente encontrado com o id '{id}'.");
                }
                else
                {
                    await _patientService.DeletePatient(patient);
                    return Ok($"Paciente excluído com sucesso");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir paciente.");
            }
        }
    }    
}
