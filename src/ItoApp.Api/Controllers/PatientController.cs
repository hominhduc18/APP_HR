using ItoApp.Application.Auth.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepo;

    public PatientController(IPatientRepository patientRepo)
    {
        _patientRepo = patientRepo;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var patient = await _patientRepo.GetByIdAsync(id);
        if (patient == null) return NotFound();
        return Ok(patient);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePatientDto dto)
    {
        var patient = await _patientRepo.GetByIdAsync(id);
        if (patient == null) return NotFound();

        // Use the UpdateProfile method from the entity
        patient.UpdateProfile(
            dto.Name ?? patient.FullName,
            dto.BirthDate ?? patient.DateOfBirth,
            patient.Gender,
            patient.Address,
            patient.EmergencyContact,
            patient.BloodType,
            patient.Allergies,
            patient.MedicalHistory
        );

        await _patientRepo.UpdateAsync(patient);
        return NoContent();
    }
}