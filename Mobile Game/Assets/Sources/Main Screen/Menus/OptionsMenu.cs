using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu
{ 
    [SerializeField] private Button _backButton;

    [SerializeField] private MainMenu _mainMenu;

    protected override void SetButtonEvents()
    {
        _backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        SetLoadState(false);
        _mainMenu.SetLoadState(true);
    }
}
