using Microsoft.AspNetCore.Mvc;
using SimuladorEmprestimo.Services;

namespace SimuladorEmprestimo.Controllers;

[ApiController]
[Route("[controller]")]
public class SimuladorEmprestimoController(IEmprestimoService service) : ControllerBase
{
    private readonly IEmprestimoService _service = service;

    [HttpGet("simular")]
    public object Get([FromQuery] string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            return Results.BadRequest("O nome deve ser informado.");
        }

        var result = _service.SimularEmprestimo(nome);

        return Ok(result);
    }
}
