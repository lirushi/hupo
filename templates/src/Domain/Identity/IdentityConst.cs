namespace Hupo.Template.Domain.Identity;

public static class IdentityConst
{
    public static class User
    {
        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxUserNameLength { get; set; } = 256;

        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxEmailLength { get; set; } = 256;

        /// <summary>
        ///     Default value: 128
        /// </summary>
        public static int MaxPasswordLength { get; set; } = 128;

        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxPasswordHashLength { get; set; } = 256;

        /// <summary>
        ///     Default value: 128
        /// </summary>
        public static int MaxPhoneNumberLength { get; set; } = 128;

        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxSecurityStampLength { get; set; } = 256;

        /// <summary>
        ///     Default value: 128
        /// </summary>
        public static int MaxLoginProviderLength { get; set; } = 128;
    }

    public static class UserLogin
    {
        /// <summary>
        ///     Default value: 64
        /// </summary>
        public static int MaxLoginProviderLength { get; set; } = 64;

        /// <summary>
        ///     Default value: 196
        /// </summary>
        public static int MaxProviderKeyLength { get; set; } = 256;

        /// <summary>
        ///     Default value: 128
        /// </summary>
        public static int MaxProviderDisplayNameLength { get; set; } = 128;
    }

    public static class UserToken
    {
        /// <summary>
        ///     Default value: 128
        /// </summary>
        public static int MaxLoginProviderLength { get; set; } = UserLogin.MaxLoginProviderLength;

        /// <summary>
        ///     Default value: 128
        /// </summary>
        public static int MaxNameLength { get; set; } = 128;
    }

    public static class Role
    {
        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxNameLength { get; set; } = 256;
    }

    public static class Calim
    {
        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxTypeLength { get; set; } = 256;
        
        /// <summary>
        ///     Default value: 256
        /// </summary>
        public static int MaxValueLength { get; set; } = 256;
    }
}
