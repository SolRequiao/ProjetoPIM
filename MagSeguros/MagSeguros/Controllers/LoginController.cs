using MagSeguros.Helper;
using MagSeguros.Models;
using MagSeguros.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MagSeguros.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IFuncionarioRepositorio funcionarioRepositorio, ISessao sessao)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {

            if (_sessao.BuscarSessaoFuncinario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoFuncionario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FuncionarioModel login = _funcionarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (login != null)
                    {
                        if (login.ValidarSenha(loginModel.Senha))
                        {
                            _sessao.CriarSessaoFuncionario(login);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MenssagemErro"] = "Senha incorreto(s)";
                    }

                    TempData["MenssagemErro"] = "Login e/ou senha incorreto(s)";
                }
                return View("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MenssagemErro"] = $"Houve um erro ao tentar fazer o login, tente novamente mais tarde. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
