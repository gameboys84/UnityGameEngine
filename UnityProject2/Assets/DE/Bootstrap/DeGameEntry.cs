using DE.Production.Runtime;

namespace DE.Bootstrap
{
    /// <summary>The product entry only starts the real DE source-backed runtime. Historical prototypes are explicit test fixtures.</summary>
    public static class DeGameEntry
    {
        public static void Entrance(object[] args) { DeProductionRuntimeHost.StartProduction(); }
    }
}
