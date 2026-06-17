using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    public GameObject saveMenu;
    public void OnButtonClick()
    {
        Debug.Log("Button was clicked via the Inspector method!");
        saveMenu.SetActive(false);
        SaveManager.Instance.LoadGame();
    }
}
