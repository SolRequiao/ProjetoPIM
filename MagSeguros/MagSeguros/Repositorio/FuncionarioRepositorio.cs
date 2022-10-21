using MagSeguros.Data;
using MagSeguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagSeguros.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public FuncionarioRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public FuncionarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Funcionario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public FuncionarioModel ListarId(int id)
        {
            return _bancoContext.Funcionario.FirstOrDefault(x => x.Id == id);
        }
        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionario.OrderBy(id => id.Id).ToList();
        }
        public FuncionarioModel Adicionar(FuncionarioModel funcionario)
        {
            funcionario.DataCadastro = DateTime.Now;
            _bancoContext.Funcionario.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }

        public FuncionarioModel Atualizar(FuncionarioModel funcionario)
        {
            //inserir o codigo na view correspondente a alteração para não estoura o erro
            //inserir dentro da tag form: <input type="hidden" asp-for="Id"/>
            FuncionarioModel funcionarioDb = ListarId(funcionario.Id);

            if (funcionarioDb == null) throw new System.Exception("Houve um erro na atualização!");

            funcionarioDb.Nome = funcionario.Nome;
            funcionarioDb.Login = funcionario.Login;
            funcionarioDb.Email = funcionario.Email;
            funcionarioDb.Perfil = funcionario.Perfil;
            funcionarioDb.DataAtualizacao = DateTime.Now;

            _bancoContext.Funcionario.Update(funcionarioDb);
            _bancoContext.SaveChanges();

            return funcionarioDb;
        }
        public bool Apagar(int id)
        {
            //inserir o codigo abaixo na view correspondente a deleção para não estoura o erro
            //inserir como atributo do botao: asp-route-id="@Model.Id"
            FuncionarioModel funcionarioDb = ListarId(id);

            if (funcionarioDb == null) throw new System.Exception("Houve um erro na tentativa de deletar o funcionario!");

            _bancoContext.Funcionario.Remove(funcionarioDb);
            _bancoContext.SaveChanges();

            return true;
        }

        
    }
}
