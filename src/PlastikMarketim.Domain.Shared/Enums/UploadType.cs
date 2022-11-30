using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PlastikMarketim.Enums
{
    public enum UploadType
    {
        [Description("wwwroot/uploads/productfiles/")]
        Product = 1,
        [Description("wwwroot/uploads/categoryfiles/")]
        Category = 2
    }
}
