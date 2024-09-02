using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacion.CasosDeUso;
namespace apiMVC.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TramitesController : ControllerBase
{
    private readonly ILogger<TramitesController> _logger;
    private readonly CasoDeUsoTramiteConsultaTodos _casoDeUsoTramiteConsultaTodos;
    private readonly CasoDeUsoTramiteAlta _casoDeUsoTramiteAlta;
    private readonly CasoDeUsoTramiteBaja _casoDeUsoTramiteBaja;
    private readonly CasoDeUsoTramiteModificacion _casoDeUsoTramiteModificacion;

    public TramitesController(ILogger<TramitesController> logger, CasoDeUsoTramiteConsultaTodos casoDeUsoTramiteConsultaTodos, CasoDeUsoTramiteAlta casoDeUsoTramiteAlta, CasoDeUsoTramiteBaja casoDeUsoTramiteBaja, CasoDeUsoTramiteModificacion casoDeUsoTramiteModificacion)
    {
        _logger = logger;
        _casoDeUsoTramiteConsultaTodos = casoDeUsoTramiteConsultaTodos;
        _casoDeUsoTramiteAlta = casoDeUsoTramiteAlta;
        _casoDeUsoTramiteBaja = casoDeUsoTramiteBaja;
        _casoDeUsoTramiteModificacion = casoDeUsoTramiteModificacion;
    }

    [HttpGet(Name = "GetTramites")]
    public IEnumerable<Tramite> Get()
    {
        return _casoDeUsoTramiteConsultaTodos.Ejecutar();   
    }

    [HttpPost(Name = "PostTramite")]
    public IActionResult Post([FromBody] Tramite tramite, [FromHeader] int usuarioId)
    {
        if (tramite == null)
        {
            return BadRequest("Tramite data is required.");
        }

        OperationResult result = _casoDeUsoTramiteAlta.Ejecutar(tramite, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpDelete("{id}", Name = "DeleteTramite")]
    public IActionResult Delete(int id, [FromHeader] int usuarioId)
    {
        OperationResult result = _casoDeUsoTramiteBaja.Ejecutar(id, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpPut(Name = "PutTramite")]
    public IActionResult Put([FromBody] Tramite tramite, [FromHeader] int usuarioId)
    {
        if (tramite == null)
        {
            return BadRequest("Tramite data is required.");
        }
        OperationResult result = _casoDeUsoTramiteModificacion.Ejecutar(tramite, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }
}