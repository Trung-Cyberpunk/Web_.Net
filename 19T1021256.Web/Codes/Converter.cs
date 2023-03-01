using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


namespace _19T1021256.Web
{
    public static class Converter
    {
        public static DateTime? DMYStringToDateTime(string s, string format = "d/M/yyyy")
        {
            try
            {
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);


            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static UserAccount CookieToUserAccount(string cookie)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserAccount>(cookie);
        }
    }
}