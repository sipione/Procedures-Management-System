using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacion.CasosDeUso;
namespace apiMVC.Controllers;

[ApiController]
[Route("[controller]")]

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
    public void Post([FromBody] Expediente expediente, [FromHeader] int usuarioId)
    {
        try{
            _casoDeUsoExpedienteAlta.Ejecutar(expediente, usuarioId);
        }catch(Exception e){
            _logger.LogError(e.Message);
            throw e;
        }
    }

    [HttpDelete("{id}", Name = "DeleteExpediente")]
    public void Delete(int id, [FromHeader] int usuarioId)
    {
        _casoDeUsoExpedienteBaja.Ejecutar(id, usuarioId);
    }

    [HttpPut(Name = "PutExpediente")]
    public void Put([FromBody] Expediente expediente, [FromHeader] int usuarioId)
    {
        _casoDeUsoExpedienteModificacion.Ejecutar(expediente, usuarioId);
    }
}