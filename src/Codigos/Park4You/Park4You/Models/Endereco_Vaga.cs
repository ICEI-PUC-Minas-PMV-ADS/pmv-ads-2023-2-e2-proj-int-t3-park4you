using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Park4You.Models
{ 
     [Table("Endereco_Vaga")]

    public class Endereco_Vaga

        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o CEP!")]
            public string CEP { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o nome do logradouro!")]
            public string Logradouro { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o número da residência!")]
            [Display(Name = "Número")]
            public int Numero { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o complemento!")]
            public string Complemento { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o bairro!")]
            public string Bairro { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o nome da Cidade!")]
            public string Cidade { get; set; }
            [Required(ErrorMessage = "Obrigatório informar a UF!")]
            public string UF { get; set; }
            [Required(ErrorMessage = "Obrigatório informar a Data!")]
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
            public cadast_Usuario cadast_Usuario { get; set; }
        }

        public enum TamanhoVagas
        {
            PequenoPorte,
            MedioPorte,
            GrandePorte
        }
    }

