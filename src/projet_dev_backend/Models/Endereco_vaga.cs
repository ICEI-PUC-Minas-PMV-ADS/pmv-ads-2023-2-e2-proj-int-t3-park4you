using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Park4You.Models;
using Microsoft.AspNetCore.Authorization;

namespace projet_dev_backend.Models
{


 [Table("Endereco_Vaga")]

public class Endereco_Vaga

{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
    [RegularExpression(@"[0-9]{8}$", ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
    [UIHint("_CepTemplate")]
    public string CEP { get; set; }

    [Required(ErrorMessage = "O CEP informado não retornou um endereço válido!")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
    [Display(Name = "Número")]
    public int Numero { get; set; }

    public string Complemento { get; set; }

    [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
    public string UF { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a Data!")]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a Quantidade de vagas!")]
    [Display(Name = "Quantidade de vagas")]
    public int QuantVagas { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o valor da reserva!")]
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    [Display(Name = "Valor da Reserva")]
    public decimal Valor { get; set; }

    [Display(Name = "Tamanho da Vaga")]
    public TamanhoVagas Tipo { get; set; }

    [Display(Name = "Usuário")]
    [Required(ErrorMessage = "Obrigatório informar o usuário")]
    public int UsuarioId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuarios Usuario { get; set; }

    [Display(Name = "Evento")]
    [Required(ErrorMessage = "Obrigatório informar o evento")]
    public int IdEvento { get; set; }

    [ForeignKey("IdEvento")]
    public Evento Evento { get; set; }
           
    // Classe para Imagem
    [Display(Name = "Nome do Arquivo")]
    public string ImagemNome { get; set; }

    [NotMapped] // Isso evita que o Entity Framework tente mapear a propriedade para o banco de dados
    [Display(Name ="Imagem da Vaga")]
    public IFormFile ImagemFile { get; set; }

    }


}


    public enum TamanhoVagas
{
    PequenoPorte,
    MedioPorte,
    GrandePorte
}


