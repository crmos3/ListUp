using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR;

namespace ListUp
{
    public class LanguageUtils
    {
        public static void English()
        {
            LanguageManager.ChangeLanguage("English");
        }

        public static void Japanese()
        {
            LanguageManager.ChangeLanguage("Japanese");
        }
    }
}
