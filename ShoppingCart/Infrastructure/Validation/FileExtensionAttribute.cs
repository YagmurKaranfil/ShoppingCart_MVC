using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Cryptography;

namespace ShoppingCart.Infrastructure.Validation
{
    //Bir Attribute, belirli bir konuda bilgi sağlar ve çalışma zamanında bu bilgileri kullanmak için çeşitli senaryolar sunar.
    public class FileExtensionAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is IFormFile file)

         //       value bir IFormFile nesnesi ise, dosyanın uzantısını Path.GetExtension(file.FileName) kullanarak alırız.

         //extensions adında bir dizi oluşturulur ve kabul edilebilir dosya uzantılarını içerir.Bu örnekte, sadece "jpg" ve "png"
         //uzantıları kabul edilir.
         //   extensions.Any(x => extension.EndsWith(x)) ifadesi kullanılarak, dosyanın uzantısının extensions dizisinde 
         //       belirtilen uzantılardan biriyle bitip bitmediği kontrol edilir. Bu ifade,
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { "jpg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));

                if(!result)
                {
                    return new ValidationResult("Allowed extensions are jpg and png");
                }
            }

            return ValidationResult.Success;
        }
    }
}
