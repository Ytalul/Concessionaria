using System.ComponentModel.DataAnnotations;

namespace Veiculo.Models
{
    public abstract class Abstrair
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Preço { get; set; }
    }
}
