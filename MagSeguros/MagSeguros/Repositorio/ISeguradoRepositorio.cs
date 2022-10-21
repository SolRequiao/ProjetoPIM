using MagSeguros.Models;
using System.Collections.Generic;

namespace MagSeguros.Repositorio
{
    public interface ISeguradoRepositorio
    {
        SeguradoModel ListarId(int id);
        List<SeguradoModel> BuscarTodos();
        SeguradoModel Adicionar(SeguradoModel segurado);
        SeguradoModel Atualizar(SeguradoModel segurado);
        bool Apagar(int id);
    }
}
