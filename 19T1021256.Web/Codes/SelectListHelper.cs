using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021256.Businesslayers;
using _19T1021256.DomainModels;
using System.Globalization;

namespace _19T1021256.Web
{
    /// <summary>
    /// Cung cấp hàm tiện ích liên quan đến SelectList
    /// </summary>
    public static class SelectListHelper
    {
        /// <summary>
        /// Danh sách các quốc gia 
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "--Chọn quốc gia--"

            });
            foreach (var item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CountryName,
                    Text = item.CountryName

                });

            }
            return list;

        }

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

        }
    
}