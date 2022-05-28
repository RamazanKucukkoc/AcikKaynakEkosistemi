using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
   public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            // var context = new ValidationContext<Product>(product); demek dogrulama yapacagım ve sınıfım Prodcut'tır diyoruz
            var context = new ValidationContext<object>(entity);

            //var result = productValidator.Validate(context); deme ProductValidator SINIFINDAKİ KODLARI DOGRULA DEMEKTİR Validate(context); demek ise dogrula ve contexti kullan
            //context ise product dogrulama demektir.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            //if (!result.IsValid) valid yok ise exception fırlat 
            //{
            //    throw new ValidationException(result.Errors);
            //}
        }
    }
}
