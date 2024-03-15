using LibraryT.Debugging;

namespace LibraryT
{
    public class LibraryTConsts
    {
        public const string LocalizationSourceName = "LibraryT";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "4ab56685d7a14b7cb2e715c6f56357ff";
    }
}
