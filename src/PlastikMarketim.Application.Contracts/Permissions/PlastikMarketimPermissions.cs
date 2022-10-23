namespace PlastikMarketim.Permissions
{
    public static class PlastikMarketimPermissions
    {
        public const string GroupName = "PlastikMarketim";
        public const string Identity = "AbpIdentity";

        public static class Users
        {
            public const string Default = Identity + ".Users";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ManagePermission = Default + ".ManagePermissions";
        }
        public static class Roles
        {
            public const string Default = Identity + ".Roles";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ManagePermission = Default + ".ManagePermissions";
        }

        public static class Products
        {
            public const string Default = GroupName + ".Product";
            //public const string Create = Default + ".Create";
            //public const string Edit = Default + ".Edit";
            //public const string Delete = Default + ".Delete";
        }
        public static class Categories
        {
            public const string Default = GroupName + ".Category";
            //public const string Create = Default + ".Create";
            //public const string Edit = Default + ".Edit";
            //public const string Delete = Default + ".Delete";
        }
        public static class ContactForms
        {
            public const string Default = GroupName + ".ContactForm";
            //public const string Create = Default + ".Create";
            //public const string Edit = Default + ".Edit";
            //public const string Delete = Default + ".Delete";
        }
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}