using System.ComponentModel.DataAnnotations;

namespace Veiculo.Models
{
    public class MotoModel : Abstrair
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Cilindradas { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string MaxVel { get; set; }
    }
}
