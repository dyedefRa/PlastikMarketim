using PlastikMarketim.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PlastikMarketim.Permissions
{
    public class PlastikMarketimPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PlastikMarketimPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(PlastikMarketimPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PlastikMarketimResource>(name);
        }
    }
}
