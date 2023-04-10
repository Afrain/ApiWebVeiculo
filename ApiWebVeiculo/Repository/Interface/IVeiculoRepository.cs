using ApiWebVeiculo.Models;

namespace ApiWebVeiculo.Repository.Interface
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> BuscarTodosVeiculos();
        Task<Veiculo> BuscarVeiculoId(int id);
        Task<Veiculo> SalvarVeiculo(Veiculo veiculo);
        Task<Veiculo> AlterarVeiculo(Veiculo veiculo);
        Task<bool> ExcluirVeiculo(int id);
    }
}
