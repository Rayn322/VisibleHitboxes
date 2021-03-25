using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace VisibleHitboxes {

    internal class Config {
        public static Config Instance { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}