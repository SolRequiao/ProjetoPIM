using MagSeguros.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MagSeguros.Models
{
    public class FuncionarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira um e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o perfil")]
        public PerfilEnum? Perfil { get; set; }
    }
}
