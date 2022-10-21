using MagSeguros.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MagSeguros.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public FuncionarioModel BuscarSessaoFuncinario()
        {
            string sessaoFuncionario = _httpContext.HttpContext.Session.GetString("sessaoFuncionarioLogada");

            if (string.IsNullOrEmpty(sessaoFuncionario)) return null;

            return JsonConvert.DeserializeObject<FuncionarioModel>(sessaoFuncionario);
        }

        public void CriarSessaoFuncionario(FuncionarioModel funcionario)
        {
            string valor = JsonConvert.SerializeObject(funcionario);
            _httpContext.HttpContext.Session.SetString("sessaoFuncionarioLogada", valor);
        }

        public void RemoverSessaoFuncionario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoFuncionarioLogada");
        }
    }
}
