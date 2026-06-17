using UnityEngine;
using UnityEngine.InputSystem;

public class GoInsideCabin : MonoBehaviour
{
    public CameraMovement myCamera;
    public bool relocate = false;
    public GameObject axe;

    void Start()
    {
        axe.SetActive(false);
    }
//
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (Keyboard.current.spaceKey.isPressed)
        //{
            Debug.Log("relocate true");
            relocate = true;
            //myCamera.transform.position = new Vector3(-20, 15, -10);
            myCamera.mode = CameraMode.LockedPosition;
            myCamera.LockToPosition(new Vector3(-20, 15, -10));
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        relocate = false;
        //Debug.Log("relocate false");
    }

    public void free()
    {
        myCamera.ResumeFollow();
        axe.SetActive(true);
        PersistentObject po_axe = axe.GetComponent<PersistentObject>();
        
        SaveManager.Instance.worldObjects[po_axe.UniqueId] = new WorldObjectSaveData
            {
                id = po_axe.UniqueId,
                isDestroyed = false
            };
    }
}
