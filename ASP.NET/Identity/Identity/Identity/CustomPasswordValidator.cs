using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Identity.Identity
{
    public class CustomPasswordValidator : PasswordValidator // Custom şifre doğrulayıcı yazıyoruz. Bunu miras almalıyız ( PasswordValidator )
    {
        public override async Task<IdentityResult> ValidateAsync(string sifre) // doğrulama işlemini override ediyoruz
        {
            var result = await base.ValidateAsync(sifre);
            if (sifre.Contains("12345"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Parola ardışık sayısal ifade içeremez ");
                result = new IdentityResult(errors);
                return result;
            }

            return await base.ValidateAsync(sifre);
        }
    }
}