using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace helloword_projeto.Models
{
    public class Cliente
    {
            [Key]
            public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [DisplayName("Nome do cliente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [DisplayName("Email do cliente")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [DisplayName("Telefone do cliente")]
        public string Telefone { get; set; }

      
    }
}
// Criação da classe e seus atributos 
//