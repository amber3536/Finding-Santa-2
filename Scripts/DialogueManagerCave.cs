using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class DialogueManagerCave : MonoBehaviour
{
    public TextMeshProUGUI elfDialogue;
    public TextMeshProUGUI yetiDialogue;
    public GameObject yeti_bubble;
    public GameObject elf_bubble;
    
    private string[] yetiSentences = {"Hey, man…\r\nI didn’t expect any visitors out here."};
    //  "Yeah, man. That’s me.\r\nFull legend status.",
    //  "Yeah, man, everybody does.\r\nIt’s a whole branding issue.\r\nStill working on it.",
    //  "Uh...ummm...well..."};
    //  "Yeah, man… big red coat, beard, whole vibe?\r\nI've seen him.",
    //  "There’s a passage up ahead, man.\r\nBut listen man—\r\ndo not take the path to the right.",
    //  "Not a good scene.",
    //  "Yeah, man. Life’s full of surprises.\r\nTiny yetis, lost elves…\r\nit’s all part of the cosmic mix.",
    //  "Hey, man—seriously!\r\nNot the right one!"};
        //"It's okay, dad. Just stay strong.\r\nYou can do this. I believe in you."};
    private string[] elfSentences = { };//"Oh hello…\r\nI’m looking for Santa.\r\nHave you seen him?"};   //Are you a yeti?",
    // "I—uh—was expecting someone… bigger.",
    // "Ok...thanks."};
    // "Which way did he go?",
    // "Why not?",
    // "Thank you. I don’t know what\r\nI expected coming in here, but…",
    // "Left path. Got it."};
    private int yetiIndex = 0;
    private float typingSpeed = 0.01f;
    private bool dontSpeak = false;
    private int elfIndex = 0;
    private bool dontInterrupt = false;
    private bool elfSpeaking = true;
    private bool wait = true;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yeti_bubble.SetActive(false);
        elf_bubble.SetActive(false);

        ContentSizeFitter fitter3 = yeti_bubble.GetComponent<ContentSizeFitter>();
        ContentSizeFitter fitter2 = elf_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter2.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter2.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        Invoke("firstLines", 3f);
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
                if (elfIndex == elfSentences.Length && yetiIndex == yetiSentences.Length)
                {
                    dontSpeak = true;
                    Invoke("endScene", 3f);
                    //beginChoices = true;
                }
                else
                {
                    dontInterrupt = true;
                    StartDialogue();
                }

            }
        }

 
    }

     private void endScene()
    {
       // SceneManager.LoadScene("Water Ending");
    }

    private void firstLines()
    {
        dontInterrupt = true;
        wait = false;
        StartCoroutine(TypeChildDialogue(yetiSentences));
    }
    private void disappearTextBubbles()
    {
        elf_bubble.SetActive(false);
        yeti_bubble.SetActive(false);

        elfDialogue.SetCharArray(new char[] { });
        yetiDialogue.SetCharArray(new char[] { });
    }

    public void StartDialogue()
    {
        if (elfSpeaking)
            StartCoroutine(TypeShrimpDialogue(elfSentences));
        else
            StartCoroutine(TypeChildDialogue(yetiSentences));
    }

    private IEnumerator TypeShrimpDialogue(string[] sentences)
    {
        elf_bubble.SetActive(true);
        ////
        foreach (char letter in sentences[elfIndex])
        {
            elfDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        elfIndex++;
        elfSpeaking = false;
        dontInterrupt = false;
        Debug.Log("shrimp index " + elfIndex);
        //StartDialogue();
    }

    private IEnumerator TypeChildDialogue(string[] sentences)
    {
        yeti_bubble.SetActive(true);
        //dontSpeak = true;
        ////
        foreach (char letter in sentences[yetiIndex])
        {
            yetiDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yetiIndex++;
        dontInterrupt = false;
        elfSpeaking = true;

    }
}
