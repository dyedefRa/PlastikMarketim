using System;
using System.Collections.Generic;
using System.Text;
using PlastikMarketim.Localization;
using Volo.Abp.Application.Services;

namespace PlastikMarketim
{
    /* Inherit your application services from this class.
     */
    public abstract class PlastikMarketimAppService : ApplicationService
    {
        protected PlastikMarketimAppService()
        {
            LocalizationResource = typeof(PlastikMarketimResource);
        }
    }
}
