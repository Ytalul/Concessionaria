using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veiculo.Controllers
{
    public class MensagemErro
    {
        public MensagemErro(int erro, string texto)
        { 
            Erro = erro;
            Texto = texto;
        }
        public int Erro {get; set;}
        public string Texto {get; set;}
    }
}