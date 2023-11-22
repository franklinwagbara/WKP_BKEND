namespace WKP.Domain.Enums_Contants
{
    public static class USER_STATUS
    {
        private const string V = "Activated";
        private static string activated = V;

        private const string DV = "Deactivated";
        private static string deactivated = DV;

        public static string Activated { get => activated; }
        public static string Deactivated { get => deactivated; }
    }
}