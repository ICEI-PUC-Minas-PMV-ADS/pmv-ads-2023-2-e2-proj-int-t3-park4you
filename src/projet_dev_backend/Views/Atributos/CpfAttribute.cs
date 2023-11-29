using System.ComponentModel.DataAnnotations;
using ValidaCpf;

namespace projet_dev_backend.Views.Atributos
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cpf = value.ToString();

                // Remova caracteres não numéricos
                cpf = new string(cpf.Where(char.IsDigit).ToArray());

                if (cpf.Length == 11)
                {
                    if (!CPF.IsValid(cpf))
                    {
                        return new ValidationResult("CPF inválido.");
                    }

                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("CPF deve conter 11 dígitos.");
        }
    }
}
