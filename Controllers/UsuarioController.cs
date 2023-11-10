using Microsoft.AspNetCore.Mvc;
using webApi.Repositorios;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioRepository usuarioRepository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("api/usuario")]
    public ActionResult<Usuario> CreateUser(Usuario usuario){
        usuarioRepository.Create(usuario);
        return Ok(usuario);
    }
    [HttpGet("api/usuario")]
    public ActionResult<List<Usuario>> GetAllUsers(){
        var usuarios = usuarioRepository.GetAll();
        return Ok(usuarios);
    }
    [HttpGet("api/usuario/{idUser}")]
    public ActionResult<Usuario> GetUser(int idUser){
        var usuario = usuarioRepository.Get(idUser);
        return Ok(usuario);
    }
    [HttpPut("api/usuario/{idUser}/nombre")]
    public ActionResult<Usuario> UpdateUser(int idUser, Usuario usuario){
        usuarioRepository.Update(idUser, usuario);
        return Ok(usuario);
    }

}
