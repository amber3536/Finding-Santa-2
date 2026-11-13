using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class EnterCandyHouse3 : MonoBehaviour
{
    public CameraMovement myCamera;
    private bool relocate = false;
    public GameObject elf;
     public TextMeshProUGUI dogDialogue;
    public GameObject dog_bubble;
    private string[] dogSentences = {"Zzzzz....."};
    private string[] dogSentences1 = {"Thanks for the milk.\r\nHere is an old bone if you want it."};
    private int dogIndex = 0;
    private float typingSpeed = 0.01f;
    //public Animator animator;
    public Animator animator_elf;
    public EnterCandyHouse2 enterCandyHouse2;

    void Start()
    {
        dog_bubble.SetActive(false);

        ContentSizeFitter fitter3 = dog_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 0, -10));
        relocate = true;

        if (enterCandyHouse2.holdingBone)
        {
            //animator.SetBool("Waking", true);
            animator_elf.SetBool("Bone", false);
            animator_elf.SetBool("Candy Cane", true);
            Invoke("Wake", 2f);
        }
        else
        {
            Invoke("firstLines", 2f);
        }
    }



    void Update()
    {
        if (relocate && Keyboard.current.spaceKey.isPressed)
        {   
            elf.transform.position = new Vector3(15f, 5.1f, 0);
            myCamera.ResumeFollow();
            relocate = false;
            disappearTextBubbles();
        }
    }

     private void firstLines()
    {
        StartCoroutine(TypeChefDialogue(dogSentences));
    }

    private void Wake()
    {
        StartCoroutine(TypeChefDialogue(dogSentences1));
    }
    private void disappearTextBubbles()
    {
        dog_bubble.SetActive(false);
        dogDialogue.SetCharArray(new char[] { });
    }
    private IEnumerator TypeChefDialogue(string[] sentences)
    {
        dog_bubble.SetActive(true);
        ////
        foreach (char letter in sentences[0])
        {
            dogDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        dogIndex++;

    }
}
