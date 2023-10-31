using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Park4You.Models;


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

    //[Required(ErrorMessage = "Obrigatório informar o tamanho da vaga!")]
    //public float TamVagas { get; set; }
    [Required(ErrorMessage = "Obrigatório informar o valor da reserva!")]
    public decimal Valor { get; set; }

    [Display(Name = "Tamanho da Vaga")]
    public TamanhoVagas Tipo { get; set; }

    [Display(Name = "Usuário")]
    [Required(ErrorMessage = "Obrigatório informar o usuário")]
    public int UsuarioId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuarios usuario { get; set; }

            // Classe para Imagem

    [NotMapped] // Isso evita que o Entity Framework tente mapear a propriedade para o banco de dados
    public IFormFile ImagemFile { get; set; }

    public byte[] Imagem { get; set; }
        }


    }


    public enum TamanhoVagas
{
    PequenoPorte,
    MedioPorte,
    GrandePorte
}


