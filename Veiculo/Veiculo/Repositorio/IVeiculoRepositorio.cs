using Veiculo.Models;

namespace Veiculo.Repositorio
{
    public interface IVeiculoRepositorio
    {
        VeiculoModel Adicionar(VeiculoModel veiculo);
        List<VeiculoModel> ListarTodos();
        VeiculoModel AttVeiculo(int id);
        VeiculoModel Atualizar(VeiculoModel veiculo);
        VeiculoModel Apagar(int id);
        bool ApagarVeiculo(VeiculoModel veiculo);

    }
}
