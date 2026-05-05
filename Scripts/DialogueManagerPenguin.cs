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
        //"It's okay, dad. Just stay strong.\r\nYou can do this. I believe in you."};
    //private string[] shrimpSentences = { };
    private int penguinIndex = 0;
    private float typingSpeed = 0.01f;
    private bool dontSpeak = false;
    //private int shrimpIndex = 0;
    private bool dontInterrupt = false;
    //private bool shrimpSpeaking = true;
    private bool wait = true;
    //private bool startedSpeaking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        penguin_bubble.SetActive(false);
        //shrimp_bubble.SetActive(false);

        ContentSizeFitter fitter3 = penguin_bubble.GetComponent<ContentSizeFitter>();
        //ContentSizeFitter fitter2 = shrimp_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        //fitter2.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        //fitter2.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        //Invoke("firstLines", 3f);
    }

    // Update is called once per frame
    void Update()
    {
         if (!dontSpeak && !wait)
        {
            //Debug.Log("hiyya");
            if (Keyboard.current.spaceKey.isPressed && !dontInterrupt)
            {
                disappearTextBubbles();
                if (penguinIndex == penguinSentences.Length)
                {
                    dontSpeak = true;
                    Invoke("endScene", 1f);
                    //beginChoices = true;
                }
                else
                {
                    //dontInterrupt = true;
                    //StartDialogue();
                }

            }
        }

        // if (goInsideCabin.relocate && !startedSpeaking)
        // {
        //     startedSpeaking = true;
        //     Invoke("firstLines", 4f);
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf")
        {
            firstLines();
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
        dontSpeak = false;
        penguinIndex = 0;
        // goInsideCabin.free();
        // elf.transform.position = new Vector3(53f, -5f, 0f);
        // startedSpeaking = false;
        // bartenderIndex = 0;
        // dontSpeak = false;
        //SceneManager.LoadScene("Water Ending");
    }

    private void firstLines()
    {
        dontInterrupt = true;
        wait = false;
        StartCoroutine(TypeBartenderDialogue(penguinSentences));
    }
    private void disappearTextBubbles()
    {
        //shrimp_bubble.SetActive(false);
        penguin_bubble.SetActive(false);

        //shrimpDialogue.SetCharArray(new char[] { });
        penguinDialogue.SetCharArray(new char[] { });
    }

    // public void StartDialogue()
    // {
    //     if (shrimpSpeaking)
    //         StartCoroutine(TypeShrimpDialogue(shrimpSentences));
    //     else
    //         StartCoroutine(TypeBartenderDialogue(bartenderSentences));
    // }

    // private IEnumerator TypeShrimpDialogue(string[] sentences)
    // {
    //     shrimp_bubble.SetActive(true);
    //     ////
    //     foreach (char letter in sentences[shrimpIndex])
    //     {
    //         shrimpDialogue.text += letter;
    //         yield return new WaitForSeconds(typingSpeed);
    //     }
    //     shrimpIndex++;
    //     shrimpSpeaking = false;
    //     dontInterrupt = false;
    //     Debug.Log("shrimp index " + shrimpIndex);
    //     //StartDialogue();
    // }

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
        dontInterrupt = false;
        //shrimpSpeaking = true;

    }
}
