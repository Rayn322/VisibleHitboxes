using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BS_Utils.Gameplay;

namespace VisibleHitboxes.UI {

    internal class SettingsMenuViewController : BSMLResourceViewController {
        public override string ResourceName => "VisibleHitboxes.UI.Views.SettingsMenu.bsml";

        // sets the toggle to the correct position when opening
        [UIValue("enabled")]
        private bool ModToggle = Config.Instance.IsEnabled;

        // sets the value when the toggle is changed
        [UIAction("setEnabled")]
        private void SetEnabled(bool value) {
            Config.Instance.IsEnabled = value;

            if (value) {
                ScoreSubmission.ProlongedDisableSubmission(Plugin.modName);
            } else {
                ScoreSubmission.RemoveProlongedDisable(Plugin.modName);
            }
        }

        [UIValue("opacity")]
        private float opacity = Config.Instance.Opacity;

        [UIAction("setOpacity")]
        private void SetOpcaity(float value) {
            Config.Instance.Opacity = value;

            Plugin.CreateMaterial();
        }
    }
}