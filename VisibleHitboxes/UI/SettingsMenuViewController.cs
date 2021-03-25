using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BS_Utils.Gameplay;

namespace VisibleHitboxes.UI {

    internal class SettingsMenuViewController : BSMLResourceViewController {
        public override string ResourceName => "VisibleHitboxes.UI.Views.SettingsMenu.bsml";

        [UIValue("enabled")]
        private bool modToggle = Config.Instance.IsEnabled;

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