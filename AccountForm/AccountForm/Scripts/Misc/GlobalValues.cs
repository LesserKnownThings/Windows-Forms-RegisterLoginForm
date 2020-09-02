namespace AccountForm.Scripts.Misc
{
    /// <summary>
    /// Class used to hold all the global values
    /// </summary>
    public static class GlobalValues
    {
        /// <summary>
        /// The php script to register account
        /// It should pass these values:
        /// Username
        /// Hashed + Salted Password
        /// Hash
        /// Salt
        /// </summary>
        public static string PHP_REGISTER { get => ""; }
        /// <summary>
        /// The php script to login
        /// It should pass these values:
        /// Username
        /// Password
        /// </summary>
        public static string PHP_LOGIN { get => ""; }
    }
}
