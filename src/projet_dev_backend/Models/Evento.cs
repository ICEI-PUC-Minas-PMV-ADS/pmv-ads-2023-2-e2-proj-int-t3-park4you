using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
       
        public ICollection<Endereco_Vaga> Endereco_Vagas { get; set; }

        public string ImagemEvento { get; set; }

        [NotMapped] // Isso evita que o Entity Framework tente mapear a propriedade para o banco de dados
        [Display(Name = "Upload da Imagem do Evento")]
        public IFormFile ImagemFileEvento { get; set; }

    }
}