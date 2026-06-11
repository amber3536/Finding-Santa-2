using UnityEngine;

public class SaveMenu : MonoBehaviour
{
    [SerializeField] private GameObject saveMenuPanel;

    private bool isOpen;

    void Start()
    {
        saveMenuPanel.SetActive(false);
    }

    public void ToggleSaveMenu()
    {
        isOpen = !isOpen;

        saveMenuPanel.SetActive(isOpen);

        if (isOpen)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void CloseMenu()
    {
        isOpen = false;
        saveMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
