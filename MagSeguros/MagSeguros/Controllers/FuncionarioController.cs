using MagSeguros.Filters;
using MagSeguros.Models;
using MagSeguros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MagSeguros.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class FuncionarioController : Controller
    {
        //var para acessar a var funcionarioRepositorio
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            this._funcionarioRepositorio = funcionarioRepositorio;
        }
        public IActionResult Index()
        {
            List<FuncionarioModel> funcionario = _funcionarioRepositorio.BuscarTodos();
            return View(funcionario);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarId(id);
            return View(funcionario);
        }
        public IActionResult ConfirmarApagar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarId(id);
            return View(funcionario);
        }
        [HttpPost]
        public IActionResult Editar(FuncionarioSemSenhaModel funcionarioSemSenha)
        {
            try
            {
                FuncionarioModel funcionario = null;

                if (ModelState.IsValid)
                {

                    funcionario = new FuncionarioModel()
                    {
                        Id = funcionarioSemSenha.Id,
                        Nome = funcionarioSemSenha.Nome,
                        Login = funcionarioSemSenha.Login,
                        Email = funcionarioSemSenha.Email,
                        Perfil = funcionarioSemSenha.Perfil
                    };

                    funcionario = _funcionarioRepositorio.Atualizar(funcionario);
                    TempData["MenssagemSucesso"] = "Funcionario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(funcionario);
            }
            catch (System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Houve um erroa ao tentar alterar o funcionario, tente novamente mais tarde. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            //inserir o codigo abaixo na view correspondente a deleção para não estoura o erro
            //inserir como atributo no botao com asp-action="Apagar": asp-route-id="@Model.Id"
            try
            {
                bool apagado = _funcionarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MenssagemSucesso"] = "Funcionario excluido com sucesso!";
                }
                else
                {
                    TempData["MenssagemErro"] = "Houve um erroa ao tentar cadastrar o funcionario, tente novamente me alguns instantes!";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Houve um erro ao tentar cadastrar o funcionario, tente novamente mais tarde, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    funcionario = _funcionarioRepositorio.Adicionar(funcionario);
                    TempData["MenssagemSucesso"] = "Funcionario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(funcionario);
            }
            catch (System.Exception erro)
            {

                TempData["MenssagemErro"] = $"Houve um erroa ao tentar cadastrar o funcionario, tente novamente mais tarde, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
