using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using Veiculo.Models;

namespace Veiculo.Views.Shared.Components.Menu
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string chave = HttpContext.Session.GetString("usuarioLogado");
            if (chave.IsNullOrEmpty()) return null;
            UsuarioModel user = JsonConvert.DeserializeObject<UsuarioModel>(chave);
            return View(user);
        }
        
    }
}
