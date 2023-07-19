using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace Application.Attributes
{
    public class FullPathValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fullPath = value as string;

            // fullPath boş olabilir
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                return ValidationResult.Success;
            }

            // fullPath geçerli bir dosya yolu olmalıdır
            if (!IsRootedPath(fullPath))
            {
                return new ValidationResult("fullPath must be a valid rooted path.");
            }

            // fullPath içinde geçersiz karakterleri kontrol et
            if (ContainsInvalidCharacters(fullPath))
            {
                return new ValidationResult("fullPath contains invalid characters.");
            }

            // fullPath geçerli bir tam yol olmalıdır
            try
            {
                string fullPathNormalized = Path.GetFullPath(fullPath);

                // fullPath'de boşluk içerip içermediğini kontrol et
                if (fullPathNormalized.Contains(" "))
                {
                    return new ValidationResult("fullPath cannot contain spaces.");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("fullPath is not a valid file path.");
            }

            return ValidationResult.Success;
        }

        // Geçerli bir dosya yolu olup olmadığını kontrol eden metod
        private bool IsRootedPath(string path)
        {
            // Başlangıçta ./ ile başlayanları geçerli kabul edelim
            if (path.StartsWith("./"))
            {
                return true;
            }

            // Diğer durumlar için Path.IsPathRooted metodu kullanılabilir
            return Path.IsPathRooted(path);
        }

        // Geçersiz karakterleri kontrol eden metod
        private bool ContainsInvalidCharacters(string path)
        {
            return path.Contains("//") || !Regex.IsMatch(path, @"^[a-zA-Z0-9./\\:]+$");

        }
    }
}
