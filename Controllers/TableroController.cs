using Microsoft.AspNetCore.Mvc;
using webApi.Repositorios;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private TableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost("api/tablero")]
    public ActionResult<Tablero> CreateTablero(Tablero tablero){
        tableroRepository.Create(tablero);
        return Ok(tablero);
    }
    [HttpGet("api/tableros")]
    public ActionResult<List<Tablero>> GetAllTableros(){
        var tableros = tableroRepository.GetAll();
        return Ok(tableros);
    }

}