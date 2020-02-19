using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ASPNetCoreIntro.Extensions
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value) // parametre olarak bir key bir de obje alıyoruz.
        {
            string objectString = JsonConvert.SerializeObject(value); // Objenin Json halini değişkene atadık
            session.SetString(key, objectString); // json olan stringi set ettik
        }
        public static T GetObject<T>(this ISession session, string key) where T : class // T tipinde bir işlem. where T : class -> T class olmalı
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            else
            {
                T value = JsonConvert.DeserializeObject<T>(objectString); // T tipinde objeyi deserialize et
                return value;
            }

        }

    }
}
