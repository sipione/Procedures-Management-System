using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacion.CasosDeUso;
namespace apiMVC.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ExpedientesController : ControllerBase
{
    private readonly ILogger<ExpedientesController> _logger;
    private readonly CasoDeUsoExpedienteConsultaTodos _casoDeUsoExpedienteConsultaTodos;
    private readonly CasoDeUsoExpedienteAlta _casoDeUsoExpedienteAlta;
    private readonly CasoDeUsoExpedienteBaja _casoDeUsoExpedienteBaja;
    private readonly CasoDeUsoExpedienteModificacion _casoDeUsoExpedienteModificacion;


    public ExpedientesController(ILogger<ExpedientesController> logger, CasoDeUsoExpedienteConsultaTodos casoDeUsoExpedienteConsultaTodos, CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta, CasoDeUsoExpedienteBaja casoDeUsoExpedienteBaja, CasoDeUsoExpedienteModificacion casoDeUsoExpedienteModificacion)
    {
        _logger = logger;
        _casoDeUsoExpedienteConsultaTodos = casoDeUsoExpedienteConsultaTodos;
        _casoDeUsoExpedienteAlta = casoDeUsoExpedienteAlta;
        _casoDeUsoExpedienteBaja = casoDeUsoExpedienteBaja;
        _casoDeUsoExpedienteModificacion = casoDeUsoExpedienteModificacion;
    }

    [HttpGet(Name = "GetExpedientes")]
    public IEnumerable<Expediente> Get()
    {
        return _casoDeUsoExpedienteConsultaTodos.Ejecutar();   
    }

    [HttpPost(Name = "PostExpediente")]
    public IActionResult Post([FromBody] Expediente expediente, [FromHeader] int usuarioId)
    {
        if (expediente == null)
        {
            return BadRequest("Expediente data is required.");
        }

        OperationResult result = _casoDeUsoExpedienteAlta.Ejecutar(expediente, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpDelete("{id}", Name = "DeleteExpediente")]
    public IActionResult Delete(int id, [FromHeader] int usuarioId)
    {
        OperationResult result = _casoDeUsoExpedienteBaja.Ejecutar(id, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpPut(Name = "PutExpediente")]
    public IActionResult Put([FromBody] Expediente expediente, [FromHeader] int usuarioId)
    {
        if (expediente == null)
        {
            return BadRequest("Expediente data is required.");
        }

        OperationResult result = _casoDeUsoExpedienteModificacion.Ejecutar(expediente, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }
}