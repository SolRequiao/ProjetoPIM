using System.ComponentModel.DataAnnotations;

namespace MagSeguros.Models
{
    public class SeguradoModel
    {
        //inserir o codigo abaixo em cada item correspodente na view
        //@Html.ValidationMessageFor(qualquerVar => qualquerVar.AtributosDestaClasse)
        //exemplo @Html.ValidationMessageFor(cpf => cpf.Cpf)
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Insira a data de nascimento")]
        public string Nascimento { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        [Required(ErrorMessage = "Insira um numero de telefone ou celular")]
        [Phone(ErrorMessage = "O numero de telefone ou celular foi informado incorretamente")]
        public string Cel { get; set; }
        [Required(ErrorMessage = "Insira o e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira a renda")]
        public string Renda { get; set; }
        [Required(ErrorMessage = "Insira o CEP")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Insira a Cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Insira o Estado")]
        public string Uf { get; set; }
        [Required(ErrorMessage = "Insira o Endereço")]
        public string Endereco { get; set; }
        public string ComplementoEnd { get; set; }
        [Required(ErrorMessage = "Insira se possui ou não uma doença grave")]
        public string DoencaGrave { get; set; }
        [Required(ErrorMessage = "Insira o valor total que será recebido")]
        public string Premio { get; set; }
        [Required(ErrorMessage = "Calcule o valor da parcela no botão em baixo do campo premio")]
        public string Parcela { get; set; }
        [Required(ErrorMessage = "Insira o nome do(a) beneficiário(a)")]
        public string NomeBeneficiario { get; set; }
        [Required(ErrorMessage = "Insira o CPF do(a) beneficiário(a)")]
        public string CpfBeneficiario { get; set; }
        [Required(ErrorMessage = "Insira o E-mail do(a) beneficiário(a)")]
        public string EmaiBeneficiario { get; set; }
        public int? FuncionarioId { get; set; }
        public FuncionarioModel Funcionario { get; set; }
    }
}