using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject saveMenu;
    public SquirrelMovement squirrel;
    public void OnButtonClick()
    {
        //Debug.Log("Button was clicked via the Inspector method!");
        saveMenu.SetActive(false);
        //SaveManager.Instance.SaveGame();
        squirrel.beginSquirrel();
    }

}
