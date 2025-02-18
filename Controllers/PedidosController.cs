using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
[ApiController]
[Route("[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository _repository;

    public PedidosController(IPedidoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<Pedido>> GetAll()
    {
        var Pedidos = _repository.GetAll();
        return Ok(Pedidos);
    }

    [HttpGet("{id}")]
    public ActionResult<Pedido> Get(int id)
    {
        var pedido = _repository.Get(id);
        if(pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpPost]
    public ActionResult Post(Pedido pedido)
    {
        _repository.Post(pedido);
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Pedido pedidoAtualizado)
    {
        var pedido = _repository.Put(id, pedidoAtualizado);
        
        if(pedido == null)
            return NotFound();

        return Ok(pedido);    
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var pedido = _repository.Delete(id);
        if(pedido == null)
            return NotFound();

        return NoContent();
    }

}
