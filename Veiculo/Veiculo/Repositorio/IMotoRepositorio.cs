using Veiculo.Models;

namespace Veiculo.Repositorio
{
    public interface IMotoRepositorio
    {
        List<MotoModel> Listar();
        MotoModel Adicionar(MotoModel moto);
        MotoModel Editar(int id);
        MotoModel Atualizar(MotoModel moto);
        MotoModel Apagar(int id);
        bool ApagarMoto(MotoModel moto);
    }
}
