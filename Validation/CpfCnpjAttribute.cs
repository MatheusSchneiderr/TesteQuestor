using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TesteQuestor.Validation;

public class CpfCnpjAttribute : ValidationAttribute
{
    private static readonly Regex DigitsOnly = new(@"\D", RegexOptions.Compiled);

    public CpfCnpjAttribute()
    {
        ErrorMessage = "CPF/CNPJ deve conter 11 (CPF) ou 14 (CNPJ) dígitos.";
    }

    public override bool IsValid(object? value)
    {
        if (value is not string s || string.IsNullOrWhiteSpace(s))
            return false;

        var digits = SomenteDigitos(s);
        return digits.Length == 11 || digits.Length == 14;
    }

    public static string SomenteDigitos(string valor) => DigitsOnly.Replace(valor, string.Empty);
}
