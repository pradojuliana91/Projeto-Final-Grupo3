using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProjetoFinal
{
    public static class CommonUtils
    {
        public static void Alerta(Page page, string msg)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('" + msg + "');", true);
        }

        public static bool IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        public static int? ParseIntOrNull(string value)
        {
            if (int.TryParse(value, out int valueRet))
            {
                return valueRet;
            }
            return null;
        }
    }
}