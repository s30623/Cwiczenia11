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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var patientInfo = _dbService.getPatientInfo();
        return Ok(patientInfo);
    }
}