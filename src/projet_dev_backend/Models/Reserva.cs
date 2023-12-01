using Park4You.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projet_dev_backend.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataReserva { get; set; }

        public int EnderecoVagaId { get; set; }

        [ForeignKey("EnderecoVagaId")]
        public Endereco_Vaga EnderecoVaga { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }
    }
}