using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BS_Utils.Gameplay;

namespace VisibleHitboxes.UI {

    internal class SettingsMenuViewController : BSMLResourceViewController {
        public override string ResourceName => "VisibleHitboxes.UI.Views.SettingsMenu.bsml";

        // sets the slider to the correct position when opening
        [UIValue("enabled")]
        private bool modToggle = Config.Instance.IsEnabled;

        // sets the value when the slider is changed
        [UIAction("setEnabled")]
        private void SetEnabled(bool value) {
            Config.Instance.IsEnabled = value;

            if (value) {
                ScoreSubmission.ProlongedDisableSubmission(Plugin.modName);
            } else {
                ScoreSubmission.RemoveProlongedDisable(Plugin.modName);
            }
        }
    }
}