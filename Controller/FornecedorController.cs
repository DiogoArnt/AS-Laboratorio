using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FornecedoresController : ControllerBase
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedoresController(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fornecedores = await _fornecedorRepository.GetAllAsync();
        return Ok(fornecedores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
        if (fornecedor == null)
        {
            return NotFound(new { Message = "Fornecedor não encontrado" });
        }
        return Ok(fornecedor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Fornecedor fornecedor)
    {
        if (fornecedor == null)
        {
            return BadRequest(new { Message = "Dados inválidos" });
        }
        await _fornecedorRepository.AddAsync(fornecedor);
        return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            return BadRequest(new { Message = "ID do fornecedor não corresponde" });
        }

        var fornecedorExistente = await _fornecedorRepository.GetByIdAsync(id);
        if (fornecedorExistente == null)
        {
            return NotFound(new { Message = "Fornecedor não encontrado" });
        }

        await _fornecedorRepository.UpdateAsync(fornecedor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var fornecedorExistente = await _fornecedorRepository.GetByIdAsync(id);
        if (fornecedorExistente == null)
        {
            return NotFound(new { Message = "Fornecedor não encontrado" });
        }

        await _fornecedorRepository.DeleteAsync(id);
        return NoContent();
    }
}
