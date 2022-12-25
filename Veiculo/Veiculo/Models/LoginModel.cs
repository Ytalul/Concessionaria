using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veiculo.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Campo obrigatório")]
        public string Login {get; set;}
        [Required(ErrorMessage="Campo obrigatório")]
        public string Senha {get; set;}
    }
}