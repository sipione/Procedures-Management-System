using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacion.CasosDeUso;
namespace apiMVC.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsuariosController: ControllerBase{
    private readonly ILogger<UsuariosController> _logger;
    private readonly CasoDeUsoUsuarioConsultaTodos _casoDeUsoUsuarioConsultaTodos;
    private readonly CasoDeUsoUsuarioAlta _casoDeUsoUsuarioAlta;
    private readonly CasoDeUsoUsuarioBaja _casoDeUsoUsuarioBaja;
    private readonly CasoDeUsoUsuarioModificacion _casoDeUsoUsuarioModificacion;

    public UsuariosController(ILogger<UsuariosController> logger, CasoDeUsoUsuarioConsultaTodos casoDeUsoUsuarioConsultaTodos, CasoDeUsoUsuarioAlta casoDeUsoUsuarioAlta, CasoDeUsoUsuarioBaja casoDeUsoUsuarioBaja, CasoDeUsoUsuarioModificacion casoDeUsoUsuarioModificacion)
    {
        _logger = logger;
        _casoDeUsoUsuarioConsultaTodos = casoDeUsoUsuarioConsultaTodos;
        _casoDeUsoUsuarioAlta = casoDeUsoUsuarioAlta;
        _casoDeUsoUsuarioBaja = casoDeUsoUsuarioBaja;
        _casoDeUsoUsuarioModificacion = casoDeUsoUsuarioModificacion;
    }

    [HttpGet(Name = "GetUsuarios")]
    public IActionResult Get([FromHeader] int usuarioId)
    {
        OperationResult result = _casoDeUsoUsuarioConsultaTodos.Ejecutar(usuarioId, true);
        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpPost("PostUsuario", Name = "PostUsuario")]
    public IActionResult Post([FromBody] Usuario usuario, [FromHeader] int usuarioId)
    {
        if (usuario == null)
        {
            return BadRequest("Usuario data is required.");
        }
    
        OperationResult result = _casoDeUsoUsuarioAlta.Ejecutar(usuario, usuarioId, true);
    
        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }
    
    [HttpPost("SignInUsuario", Name = "SignInUsuario")]
    public IActionResult SignIn([FromBody] Usuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("Usuario data is required.");
        }
    
        OperationResult result = _casoDeUsoUsuarioAlta.Ejecutar(usuario, true);
    
        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpDelete("{id}", Name = "DeleteUsuario")]
    public IActionResult Delete(int id, [FromHeader] int usuarioId)
    {
        OperationResult result = _casoDeUsoUsuarioBaja.Ejecutar(id, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }

    [HttpPut(Name = "PutUsuario")]
    public IActionResult Put([FromBody] Usuario usuario, [FromHeader] int usuarioId)
    {
        if (usuario == null)
        {
            return BadRequest("Usuario data is required.");
        }
        OperationResult result = _casoDeUsoUsuarioModificacion.Ejecutar(usuario, usuarioId, true);

        return StatusCode(result.StatusCode, result.Data ?? result.Message);
    }
}