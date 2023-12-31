﻿using System.ComponentModel.DataAnnotations;

namespace Common.Infrastructure
{
    internal class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var context = (CmsShoppingCartContext)validationContext.GetService(typeof(CmsShoppingCartContext));

            var file = value as IFormFile;

            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { "jpg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));

                if(!result)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return "Allowed extensions are jpg and png.";
        }
    }
}