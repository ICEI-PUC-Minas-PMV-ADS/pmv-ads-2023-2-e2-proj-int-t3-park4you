using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_dev_backend.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o nome do evento")]
        [Display(Name = "Nome do Evento")]
        public string NomeEvento { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a descrição do evento")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o local do evento")]
        [Display(Name = "Local do Evento")]
        public string Local { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o endereço do evento")]
        [Display(Name = "Endereço do Evento")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a data do evento")]
        [Display(Name = "Data do Evento")]

        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o horário do evento")]
        [Display(Name = "Horário do Evento")]
        public DateTime Hora { get; set; }
        [Required(ErrorMessage = "Informe o nome do Gestor ")]
        [Display(Name = "Gestor")]
        public int GestorId { get; set; }
        //[Display(Name = "Usuário")]
        //[Required(ErrorMessage = "Obrigatório informar o usuário")]
        public int Endereco_VagaId { get; set; }

        [ForeignKey("Endereco_VagaId")]

        public Endereco_Vaga endereco_Vaga { get; set; }
        public ICollection<Endereco_Vaga> Endereco_Vagas { get; set; }

    }
}
