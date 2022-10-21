using MagSeguros.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagSeguros.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o perfil")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Insira sua senha")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual List<SeguradoModel> Segurados { get; set; }

        public bool ValidarSenha(string senha)
        {
            return Senha == senha;
        }
    }
}
