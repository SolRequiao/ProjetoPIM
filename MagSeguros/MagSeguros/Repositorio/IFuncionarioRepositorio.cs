using MagSeguros.Models;
using System.Collections.Generic;

namespace MagSeguros.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        FuncionarioModel BuscarPorLogin(string login);
        FuncionarioModel ListarId(int id);
        List<FuncionarioModel> BuscarTodos();
        FuncionarioModel Adicionar(FuncionarioModel segurado);
        FuncionarioModel Atualizar(FuncionarioModel segurado);
        bool Apagar(int id);
    }
}
