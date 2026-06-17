using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Button was clicked via the Inspector method!");
        SaveManager.Instance.SaveGame();
    }

}
