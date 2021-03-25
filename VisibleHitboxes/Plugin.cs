using BS_Utils.Gameplay;
using HarmonyLib;
using IPA;
using IPA.Config.Stores;
using System.Reflection;
using UnityEngine;
using VisibleHitboxes.UI;
using IPALogger = IPA.Logging.Logger;

namespace VisibleHitboxes {

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static Material hitboxMaterial { get; private set; }
        internal static Mesh cubeMesh { get; private set; }
        internal static string modName = "Visible Hitboxes";
        private static Harmony _harmonyInstance;
        private static MenuButtonManager _menuButtonManager;

        [Init]
        public void Init(IPALogger logger, IPA.Config.Config conf) {
            Instance = this;

            Log = logger;
            Log.Info("VisibleHitboxes initialized.");

            Config.Instance = conf.Generated<Config>();
            Log.Debug("Config loaded");
        }

        [OnStart]
        public void OnApplicationStart() {
            Log.Debug("OnApplicationStart");
            new GameObject("VisibleHitboxesController").AddComponent<VisibleHitboxesController>();
            _harmonyInstance = new Harmony("com.ryan.VisibleHitboxes");
            _harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

            if (Config.Instance.IsEnabled) {
                ScoreSubmission.ProlongedDisableSubmission(modName);
            }

            _menuButtonManager = new MenuButtonManager();
            _menuButtonManager.Setup();

            CreateMaterial();
            CreateCubeMesh();
        }

        [OnExit]
        public void OnApplicationQuit() {
            Log.Debug("OnApplicationQuit");
            _harmonyInstance.UnpatchAll("com.ryan.VisibleHitboxes");
            _harmonyInstance = null;

            ScoreSubmission.RemoveProlongedDisable(modName);
        }

        private void CreateCubeMesh() {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeMesh = cube.GetComponent<MeshFilter>().mesh;
        }

        private void CreateMaterial() {
            hitboxMaterial = new Material(Shader.Find("Legacy Shaders/Transparent/VertexLit"));
            // Legacy Shaders/Transparent/VertexLit
            hitboxMaterial.color = new Color(255, 255, 255, 0.5f);
        }
    }
}