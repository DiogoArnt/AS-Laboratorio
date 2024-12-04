using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository _repository;

    public PedidosController(IPedidoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) =>
        Ok(await _repository.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Pedido pedido)
    {
        await _repository.AddAsync(pedido);
        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pedido pedido)
    {
        if (id != pedido.Id) return BadRequest();
        await _repository.UpdateAsync(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}