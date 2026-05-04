using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace helloword_projeto.Models
{
    public class Produto()
    {
        [Key]
        public int  Id { get; set; } 
        [Required(ErrorMessage ="Este campo é de preenchimento obrigatório")]
        [DisplayName("Nome do produto")] // um nome que tu pode colocar nos atributos
        public string  Nome { get; set; }
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [DisplayName("Preço do produto")]
        public int?  Preco { get; set; }

    }
    
}
        





        /* public int MyProperty { get; set; } // get e set de um atributo ainda não criado

         public int MyProperty // aqui é a mesma coisa de cime porem aqui da para modificar, colocar o codigo que quiser ali dentro
         {
             get { return id; }
             set { id = value; }

         }


         private int id;
         private string nome;
         private float preco;

         public int Id { get { return id; }
                         set { id = value; }
         }

         public string getNome()
         { 
             retunr nome;
         }
         public string setNome(string nome)
         {
             retunr this.nome = nome;
         }*/
   