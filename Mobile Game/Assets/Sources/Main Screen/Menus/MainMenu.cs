using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private OptionsMenu _optionsMenu;

    protected override void SetButtonEvents()
    {
        _startButton.onClick.AddListener(SceneLoader.LoadGameScene);
        _optionsButton.onClick.AddListener(OpenOptionsMenu);
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void OpenOptionsMenu()
    {
        SetLoadState(false);
        _optionsMenu.SetLoadState(true);
    }
}
