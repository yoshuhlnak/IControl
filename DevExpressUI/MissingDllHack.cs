using System.Data.Entity.SqlServer;

namespace DevExpressUI
{
    internal static class MissingDllHack
    {
        private static SqlProviderServices _instance = SqlProviderServices . Instance;
    }
}