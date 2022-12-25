using Veiculo.Enums;
using System.ComponentModel.DataAnnotations;

namespace Veiculo.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string Senha { get; set; }
        public DateTime DataCriação { get; set; }
        public DateTime? DataAtualização { get; set; }
        public bool SenhaValida(string senha)
        {
            if (Senha == senha )
            {
                return true;
            }
            else
            {
                return false;
            }
        }   
    }
}
