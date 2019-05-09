
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence
{
    public class PasswordGenerate
    {

        //https://www.c-sharpcorner.com/article/hashing-in-asp-net-core-2-0/ 
        public static string HashPassword(string value)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes("Secret key"),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public static bool Validate(string value, string hash)
            => HashPassword(value) == hash;
    }
}
