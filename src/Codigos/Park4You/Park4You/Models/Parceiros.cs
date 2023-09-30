using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Park4You.Models
{
    [Table("Parceiros")]
    public class Parceiro
    {
        [Key]
        private int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o nome")]
        private string nomeParceiro { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar os Dados Bancários")]
        private int dadosBancario { get; set; }

    }
}
