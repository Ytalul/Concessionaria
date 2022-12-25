using System.ComponentModel.DataAnnotations;

namespace Veiculo.Models
{
    public class VeiculoModel : Abstrair
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descrição { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Motor { get; set; }
    }
}
