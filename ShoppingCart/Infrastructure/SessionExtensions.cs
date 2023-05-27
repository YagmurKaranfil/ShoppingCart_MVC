using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System;
using System.Reflection.Metadata;

namespace ShoppingCart.Infrastructure
{
    public static  class SessionExtensions
    {

        //bir kullanıcının web uygulamasına ait oturum verilerini depolamak ve erişmek için kullanılırbir kullanıcının
        //    web uygulamasına ait oturum verilerini depolamak ve erişmek için kullanılır


        //Bu metodun ilk parametresi ISession arayüzüne genişletildiği için, bu metod doğrudan ISession örneklerine 
        //    uygulanabilir hale gelir.İkinci parametre olan key değeri, oturum verisinin erişim anahtarını temsil e
        //    der.Üçüncü parametre olan value, oturum verisi olarak kaydedilecek olan nesneyi temsil eder. Bu metod,
        //    verilen nesneyi JSON formatına dönüştürerek, oturum verilerine belirtilen anahtar ile birlikte ekler.

        public static void  SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
       // Bu metodun ilk parametresi de ISession arayüzüne genişletildiği için, doğrudan ISession örneklerine uygulanabilir hale gelir.
       //     İkinci parametre olan key, erişilecek oturum verisinin anahtarını temsil eder. Bu metod, belirtilen anahtara sahip
       //     oturum verisini session.GetString(key) yöntemiyle alır.Daha sonra, alınan oturum verisini JSON formatından gerçek 
       //     nesne tipine dönüştürmek için JsonConvert.DeserializeObject<T>(sessionData) yöntemi kullanılır.Bu dönüşüm işlemi,
       //     veri kaydedilirken JSON formatına dönüştürüldüğü şekliyle geri dönüştürülmesini sağlar.


       //Eğer belirtilen anahtara sahip oturum verisi bulunmazsa, default(T) ifadesi kullanılarak varsayılan değer (null veya temel
       //     veri tipleri için uygun olan değer) döndürülür.
        public static T GetJson<T>(this ISession session,string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
