using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_dev_backend.Models
{
    [Table("Gestor")]
    public class Gestor
    {
        public int GestorId { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Nome!")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o E-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public ICollection<Evento> eventos { get; set; }


    }
}
