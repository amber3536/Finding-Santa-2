using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class EnterCandyHouse2 : MonoBehaviour
{
    public CameraMovement myCamera;
    private bool relocate = false;
    public GameObject elf;
    public TextMeshProUGUI catDialogue;
    public GameObject cat_bubble;
    private string[] catSentences = {"Zzzzz....."};
    private string[] catSentences1 = {"Thanks for the milk.\r\nHere is an old bone if you want it."};
    private int catIndex = 0;
    private float typingSpeed = 0.01f;
    public Animator animator;
    public Animator animator_elf;
    public EnterCandyHouse4 enterCandyHouse4;

    void Start()
    {
        cat_bubble.SetActive(false);

        ContentSizeFitter fitter3 = cat_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 20, -10));
        relocate = true;

        if (enterCandyHouse4.holdingMilk)
        {
            animator.SetBool("Waking", true);
            animator_elf.SetBool("Milk", false);
            Invoke("Wake", 2f);
        }
        else
        {
            Invoke("firstLines", 2f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }

    void Update()
    {
        if (relocate && Keyboard.current.spaceKey.isPressed)
        {   
            elf.transform.position = new Vector3(0f, 7f, 0);
            myCamera.ResumeFollow();
            relocate = false;
            disappearTextBubbles();
        }
    }
    private void firstLines()
    {
        StartCoroutine(TypeChefDialogue(catSentences));
    }

    private void Wake()
    {
        StartCoroutine(TypeChefDialogue(catSentences1));
    }
    private void disappearTextBubbles()
    {
        cat_bubble.SetActive(false);
        catDialogue.SetCharArray(new char[] { });
    }
    private IEnumerator TypeChefDialogue(string[] sentences)
    {
        cat_bubble.SetActive(true);
        ////
        foreach (char letter in sentences[0])
        {
            catDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        catIndex++;

    }
}
