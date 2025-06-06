﻿using Cwiczenia11.Data;
using Cwiczenia11.DTOs;
using Cwiczenia11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicamentController : ControllerBase
{
    private readonly IDbService _dbService;

    public MedicamentController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> GetPatientInfo(PatientRequestDTO patient)
    {
        if (!await _dbService.patientExists(patient))
        {
            _dbService.createPatient(patient);
        }

        await _dbService.checkDrugNumber(patient);
        await _dbService.checkDrugsExists(patient);
        var patientInfo = await _dbService.getPatientInfo(patient);
        
        return Ok(patientInfo);
    }
}