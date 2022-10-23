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

            var productPermission = myGroup.AddPermission(PlastikMarketimPermissions.Products.Default, L("ProductManagement"));
            //productPermission.AddChild(PlastikMarketimPermissions.Products.Create, L("Permission:Products.Create"));
            //productPermission.AddChild(PlastikMarketimPermissions.Products.Edit, L("Permission:Products.Edit"));
            //productPermission.AddChild(PlastikMarketimPermissions.Products.Delete, L("Permission:Products.Delete"));

            var categoryPermission = myGroup.AddPermission(PlastikMarketimPermissions.Categories.Default, L("CategoryManagement"));

            var contactFormPermission = myGroup.AddPermission(PlastikMarketimPermissions.ContactForms.Default, L("ContactFormManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PlastikMarketimResource>(name);
        }
    }
}
