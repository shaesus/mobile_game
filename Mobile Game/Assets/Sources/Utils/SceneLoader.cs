using UnityEngine.SceneManagement;

public enum Scenes
{
    MainMenu,
    Game
}

public static class SceneLoader
{
    public static void LoadGameScene()
    {
        SceneManager.LoadScene((int)Scenes.Game);
    }

    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
