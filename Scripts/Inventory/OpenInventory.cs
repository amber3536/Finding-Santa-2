using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class OpenInventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    //public GameObject firstSlot;
    private bool isOpen = false;
    //public Inventory inventory;
    public InventoryUI inventoryUI;

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void openingInventory() //OnOpenInventory(InputAction.CallbackContext context)
    {
        // if (!context.performed)
        //     return;

        isOpen = !isOpen;

        inventoryPanel.SetActive(isOpen);

        // Optional: pause movement while inventory open
        if (isOpen)
        {
            Time.timeScale = 0f;
            //if (inventoryUI.slotObjects.Count != 0)
            //{
                //Debug.Log("boo");
                //EventSystem.current.SetSelectedGameObject(inventoryUI.slotObjects[0].gameObject);

                //Debug.Log("item is "+ inventoryUI.slotObjects[0].gameObject);
                //Debug.Log(inventoryUI.slotObjects.Count);
            //}
            
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
