using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public void SetLoadState(bool state)
    {
        gameObject.SetActive(state);
    }

    private void Start()
    {
        SetButtonEvents();
    }

    protected abstract void SetButtonEvents();
}
