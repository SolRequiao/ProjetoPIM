using MagSeguros.Data;
using MagSeguros.Models;
using System.Collections.Generic;
using System.Linq;

namespace MagSeguros.Repositorio
{
    public class SeguradoRepositorio : ISeguradoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public SeguradoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public SeguradoModel ListarId(int id)
        {
            return _bancoContext.Segurado.FirstOrDefault(x => x.Id == id);
        }
        public List<SeguradoModel> BuscarTodos()
        {
            return _bancoContext.Segurado.OrderBy(id => id.Id).ToList();
        }
        public SeguradoModel Adicionar(SeguradoModel segurado)
        {
            _bancoContext.Segurado.Add(segurado);
            _bancoContext.SaveChanges();
            return segurado;
        }

        public SeguradoModel Atualizar(SeguradoModel segurado)
        {
            //inserir o codigo na view correspondente a alteração para não estoura o erro
            //inserir dentro da tag form: <input type="hidden" asp-for="Id"/>
            SeguradoModel seguradoDb = ListarId(segurado.Id);

            if (seguradoDb == null) throw new System.Exception("Houve um erro na atualização");

            seguradoDb.Nome = segurado.Nome;
            seguradoDb.Cpf = segurado.Cpf;
            seguradoDb.Nascimento = segurado.Nascimento;
            seguradoDb.Genero = segurado.Genero;
            seguradoDb.EstadoCivil = segurado.EstadoCivil;
            seguradoDb.Cel = segurado.Cel;
            seguradoDb.Email = segurado.Email;
            seguradoDb.Renda = segurado.Renda;
            seguradoDb.Cep = segurado.Cep;
            seguradoDb.Cidade = segurado.Cidade;
            seguradoDb.Uf = segurado.Uf;
            seguradoDb.Endereco = segurado.Endereco;
            seguradoDb.ComplementoEnd = segurado.ComplementoEnd;
            seguradoDb.DoencaGrave = segurado.DoencaGrave;
            seguradoDb.Premio = segurado.Premio;
            seguradoDb.Parcela = segurado.Parcela;
            seguradoDb.NomeBeneficiario = segurado.NomeBeneficiario;
            seguradoDb.CpfBeneficiario = segurado.CpfBeneficiario;
            seguradoDb.EmaiBeneficiario = segurado.EmaiBeneficiario;

            _bancoContext.Segurado.Update(seguradoDb);
            _bancoContext.SaveChanges();

            return seguradoDb;
        }
        public bool Apagar(int id)
        {
            //inserir o codigo abaixo na view correspondente a deleção para não estoura o erro
            //inserir como atributo do botao com asp-action="Apagar": asp-route-id="@Model.Id"
            SeguradoModel seguradoDb = ListarId(id);

            if (seguradoDb == null) throw new System.Exception("Houve um erro na tentativa de deletar o segurado");

            _bancoContext.Segurado.Remove(seguradoDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
