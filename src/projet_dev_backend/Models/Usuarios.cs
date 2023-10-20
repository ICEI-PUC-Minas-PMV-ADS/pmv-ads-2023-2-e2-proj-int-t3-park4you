using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using projet_dev_backend.Models;

namespace Park4You.Models
{
    [Table("Usuario")]
    public class Usuarios

    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o E-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Telefone!")]
        public string Telefone { get; set; }

        public ICollection<Endereco_Vaga> Endereco_Vagas { get; set; }

    }
    }
    