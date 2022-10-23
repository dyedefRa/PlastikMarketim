using System;

namespace PlastikMarketim
{
    public static class PlastikMarketimConsts
    {
        public const string DbTablePrefix = "PM";

        public const string DbSchema = null;

        #region MailTemplateKey

        public static class MailTemplateKey
        {
            public const string TemplateBody = "template_body";
            public const string TemplateFooter = "template_footer";
        }

        #endregion

        public static class DEFAULT
        {
            /// <summary>
            /// Filtrelerde kullanılan default tarih değeri
            /// </summary>
            public static DateTime DefaultDate = new DateTime(2000, 01, 01);
        }
    }
}
