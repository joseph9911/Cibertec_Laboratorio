using System;
using System.Web;
using System.Web.Mvc;

namespace WebDeveloper.Helpers
{
    public static class CustomHelper
    {
        public static IHtmlString DisplayPriceStatic(double price)
        {
            return new HtmlString(GetHtmlForPrice(price));
        }

        public static IHtmlString DisplayPriceExtension(this HtmlHelper helper, double price)
        {
            return new HtmlString(GetHtmlForPrice(price));
        }
        private static string GetHtmlForPrice(double price)
        {
            return price == 0.0 ? "<span>Free!!!</span>" : $"<span>{price.ToString("C")}</span>";
        }

        public static IHtmlString DisplayDateOrNullExtension(this HtmlHelper helper, DateTime? date)
        {
            return new HtmlString(GetDateHtml(date));
        }

        private static string GetDateHtml(DateTime? date)
        {            
            return date.HasValue ? $"<span>{date.Value.ToString("dd-mm-yyyy")}</span>" : "None";
        }
    }
}
