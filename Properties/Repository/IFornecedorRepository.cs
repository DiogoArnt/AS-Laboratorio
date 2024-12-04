using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFornecedorRepository
{
    Task<IEnumerable<Fornecedor>> GetAllAsync(); // Obtém todos os fornecedores
    Task<Fornecedor> GetByIdAsync(int id);       // Obtém um fornecedor específico pelo ID
    Task AddAsync(Fornecedor fornecedor);        // Adiciona um novo fornecedor
    Task UpdateAsync(Fornecedor fornecedor);     // Atualiza as informações de um fornecedor existente
    Task DeleteAsync(int id);                    // Remove um fornecedor pelo ID
}