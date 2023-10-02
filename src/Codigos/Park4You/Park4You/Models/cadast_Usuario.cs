using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Park4You.Models
{

        [Table("Usuarios")]
        public class cadast_Usuario
        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o nome!")]
            public string Nome { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o E-mail!")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Obrigatório informar a Senha!")]
            public string Senha { get; set; }
            [Required(ErrorMessage = "Obrigatório informar a Endereço!")]
            public string Endereco { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o Telefone!")]
            public int Telefone { get; set; }
        }
    }



