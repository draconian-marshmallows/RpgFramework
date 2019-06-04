using DraconianMarshmallows.UI;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.UI
{
    public class TitleScreen : UIBehavior
    {
        [SerializeField] private UIBehavior characterCreationPanel;
//        [SerializeField] private UIBehavior loadGamePanel;

        [SerializeField] private ButtonPlus startButton;
        [SerializeField] private ButtonPlus loadButton;

        protected override void Start()
        {
            startButton.onClick.AddListener(onClickStart);
            loadButton.onClick.AddListener(onClickLoad);
        }

        private void onClickStart()
        {
            SetActive(false);
            characterCreationPanel.SetActive(true);
        }

        private void onClickLoad()
        {
            SetActive(false);
//            loadGamePanel.SetActive(true);
        }
    }
}
