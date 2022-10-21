using MagSeguros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MagSeguros.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoFuncionario = HttpContext.Session.GetString("sessaoFuncionarioLogada");

            if (string.IsNullOrEmpty(sessaoFuncionario))
            {
                return null;
            }

            FuncionarioModel funcionario = JsonConvert.DeserializeObject<FuncionarioModel>(sessaoFuncionario);

            return View(funcionario);
        }
    }
}
