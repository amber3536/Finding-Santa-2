using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManagerPenguin : MonoBehaviour
{
   //public TextMeshProUGUI shrimpDialogue;
    public TextMeshProUGUI penguinDialogue;
    public GameObject penguin_bubble;
    //public GameObject shrimp_bubble;
    //public GoInsideCabin goInsideCabin;
    //public GameObject elf;
    private string[] penguinSentences = {"I hear the fishing is better in the North."};
    private string[] penguinSentences1 = {"My friend! Thank you for this pleasant surprise."};
    private int penguinIndex = 0;
    private float typingSpeed = 0.01f;
    //private bool dontSpeak = false;
    //private int shrimpIndex = 0;
    //private bool dontInterrupt = false;
    //private bool shrimpSpeaking = true;
    //private bool wait = true;
    public ElfMovement elf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        penguin_bubble.SetActive(false);
        //shrimp_bubble.SetActive(false);

        ContentSizeFitter fitter3 = penguin_bubble.GetComponent<ContentSizeFitter>();
        //ContentSizeFitter fitter2 = shrimp_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

    }

    // Update is called once per frame
    void Update()
    {
        // if (!dontSpeak && !wait)
        // {
        //     if (Keyboard.current.spaceKey.isPressed && !dontInterrupt)
        //     {
        //         disappearTextBubbles();
        //         if (penguinIndex == penguinSentences.Length)
        //         {
        //             dontSpeak = true;
        //             Invoke("endScene", 1f);
        //         }

        //     }
        // }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf")
        {
            if (elf.holdingFish)
            {
                lastLines();
            }
            else
            {
                firstLines();
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf")
        {
            endScene();
            disappearTextBubbles();
        }
    }

     private void endScene()
    {
        //dontSpeak = false;
        penguinIndex = 0;
    }

    private void firstLines()
    {
        //dontInterrupt = true;
        //wait = false;
        StartCoroutine(TypeBartenderDialogue(penguinSentences));
    }

    private void lastLines()
    {
        //dontInterrupt = true;
        //wait = false;
        StartCoroutine(TypeBartenderDialogue(penguinSentences1));
    }
    private void disappearTextBubbles()
    {
        //shrimp_bubble.SetActive(false);
        penguin_bubble.SetActive(false);

        //shrimpDialogue.SetCharArray(new char[] { });
        penguinDialogue.SetCharArray(new char[] { });
    }



    private IEnumerator TypeBartenderDialogue(string[] sentences)
    {
        penguin_bubble.SetActive(true);
        //dontSpeak = true;
        ////
        foreach (char letter in sentences[penguinIndex])
        {
            penguinDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        penguinIndex++;
        //dontInterrupt = false;
        //shrimpSpeaking = true;

    }
}
