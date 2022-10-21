using MagSeguros.Filters;
using MagSeguros.Models;
using MagSeguros.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MagSeguros.Controllers
{
    [PaginaParaFuncionarioLogado]
    public class SeguradoController : Controller
    {
        //var para acessar a var seguradoRepositrio
        private readonly ISeguradoRepositorio _seguradoRepositorio;
        public SeguradoController(ISeguradoRepositorio seguradoRepositorio)
        {
            this._seguradoRepositorio = seguradoRepositorio;
        }
        //metodos de get
        public IActionResult Index()
        {
            List<SeguradoModel> segurado = _seguradoRepositorio.BuscarTodos();
            return View(segurado);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            //inserir o codigo na view correspondente a alteração para não estoura o erro
            //inserir dentro da tag form: <input type="hidden" asp-for="Id"/>
            SeguradoModel segurado = _seguradoRepositorio.ListarId(id);
            return View(segurado);
        }
        public IActionResult ConfirmarApagar(int id)
        {
            SeguradoModel segurado = _seguradoRepositorio.ListarId(id);
            return View(segurado);
        }
        public IActionResult Apagar(int id)
        {
            //inserir o codigo abaixo na view correspondente a deleção para não estoura o erro
            //inserir como atributo no botao com asp-action="Apagar": asp-route-id="@Model.Id"
            try
            {
                bool apagado = _seguradoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MenssagemSucesso"] = "Segurado excluido com sucesso!";
                }
                else
                {
                    TempData["MenssagemErro"] = "Houve um erroa ao tentar cadastrar o segurado, tente novamente me alguns instantes!";
                }

                
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Houve um erro ao tentar cadastrar o segurado, tente novamente mais tarde, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        //metodos post
        [HttpPost]
        public IActionResult Criar(SeguradoModel segurado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    segurado = _seguradoRepositorio.Adicionar(segurado);
                    TempData["MenssagemSucesso"] = "Segurado cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(segurado);
            }
            catch (System.Exception erro)
            {

                TempData["MenssagemErro"] = $"Houve um erroa ao tentar cadastrar o segurado, tente novamente mais tarde, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(SeguradoModel segurado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _seguradoRepositorio.Atualizar(segurado);
                    TempData["MenssagemSucesso"] = "Segurado alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", segurado);
            }
            catch (System.Exception erro)
            {

                TempData["MenssagemErro"] = $"Houve um erroa ao tentar alterar o segurado, tente novamente mais tarde. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
