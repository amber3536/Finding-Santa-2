using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class EnterCandyHouse4 : MonoBehaviour
{
    public CameraMovement myCamera;
    private bool relocate = false;
    public GameObject elf;
    public TextMeshProUGUI chefDialogue;
    public GameObject chef_bubble;

    private string[] chefSentences = {"Bonjour! Have some milk on the house."};
    private int chefIndex = 0;
    private float typingSpeed = 0.01f;

    void Start()
    {
        chef_bubble.SetActive(false);

        ContentSizeFitter fitter3 = chef_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 10f, -10));
        relocate = true;
        firstLines();
    }
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     relocate = false;
    // }

    void Update()
    {
        if (relocate && Keyboard.current.spaceKey.isPressed)
        {   
            elf.transform.position = new Vector3(15f, 25.1f, 0);
            myCamera.ResumeFollow();
            relocate = false;
        }
    }

    private void firstLines()
    {
        StartCoroutine(TypeChefDialogue(chefSentences));
    }
    private void disappearTextBubbles()
    {
        chef_bubble.SetActive(false);
        chefDialogue.SetCharArray(new char[] { });
    }
    private IEnumerator TypeChefDialogue(string[] sentences)
    {
        chef_bubble.SetActive(true);
        ////
        foreach (char letter in sentences[chefIndex])
        {
            chefDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        chefIndex++;

    }
}
