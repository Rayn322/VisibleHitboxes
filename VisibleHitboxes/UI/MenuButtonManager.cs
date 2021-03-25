using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using HMUI;

namespace VisibleHitboxes.UI {

    public class MenuButtonManager {
        private MenuButton _menuButton;
        private static VisibleHitboxesCoordinator _flow;

        internal void Setup() {
            _menuButton = new MenuButton("Visible Hitboxes", "Toggle the visible hitboxes mod", ShowUI, true);
            MenuButtons.instance.RegisterButton(_menuButton);
        }

        private static void ShowUI() {
            if (_flow == null) {
                _flow = BeatSaberUI.CreateFlowCoordinator<VisibleHitboxesCoordinator>();
            }

            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(_flow);
        }
    }

    internal class VisibleHitboxesCoordinator : FlowCoordinator {
        internal static VisibleHitboxesCoordinator instance { get; private set; }
        internal SettingsMenuViewController settingsView;

        public void Awake() {
            instance = this;

            if (settingsView == null)
                settingsView = BeatSaberUI.CreateViewController<SettingsMenuViewController>();
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling) {
            SetTitle("Visible Hitboxes Settings");
            showBackButton = true;
            ProvideInitialViewControllers(settingsView);
        }

        protected override void BackButtonWasPressed(ViewController topViewController) {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
        }
    }
}