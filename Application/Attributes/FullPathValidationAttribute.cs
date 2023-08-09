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
            var fullPath = value as string;

            // fullPath boş olabilir
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                return ValidationResult.Success;
            }

           
            if (!IsRootedPath(fullPath))
            {
                return new ValidationResult("fullPath must be a valid rooted path.");
            }

            if (ContainsInvalidCharacters(fullPath))
            {
                return new ValidationResult("fullPath contains invalid characters.");
            }

            try
            {
                string fullPathNormalized = Path.GetFullPath(fullPath);

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

        private static bool IsRootedPath(string path)
        {
            if (path.StartsWith("./"))
            {
                return true;
            }

            return Path.IsPathRooted(path);
        }

        private bool ContainsInvalidCharacters(string path)
        {
            return path.Contains("//") || !Regex.IsMatch(path, @"^[a-zA-Z0-9./\\:]+$");

        }
    }
}
