using MagSeguros.Models;

namespace MagSeguros.Helper
{
    public interface ISessao
    {
        void CriarSessaoFuncionario(FuncionarioModel funcionario);
        void RemoverSessaoFuncionario();
        FuncionarioModel BuscarSessaoFuncinario();

    }
}
