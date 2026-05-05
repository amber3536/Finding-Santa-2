using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DialogueManagerBartender : MonoBehaviour
{
    public TextMeshProUGUI shrimpDialogue;
    public TextMeshProUGUI bartenderDialogue;
    public GameObject bartender_bubble;
    public GameObject shrimp_bubble;
    public GoInsideCabin goInsideCabin;
    public GameObject elf;
    private string[] bartenderSentences = {"I am starving right now.\r\nI could really use some berries."};
        //"It's okay, dad. Just stay strong.\r\nYou can do this. I believe in you."};
    private string[] bartenderSentences2 = {"Some secret info..."};
    private string[] shrimpSentences = { };
    private int bartenderIndex = 0;
    private float typingSpeed = 0.01f;
    private bool dontSpeak = false;
    private int shrimpIndex = 0;
    private bool dontInterrupt = false;
    private bool shrimpSpeaking = true;
    private bool wait = true;
    private bool startedSpeaking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("berries", 0);

        bartender_bubble.SetActive(false);
        shrimp_bubble.SetActive(false);

        ContentSizeFitter fitter3 = bartender_bubble.GetComponent<ContentSizeFitter>();
        ContentSizeFitter fitter2 = shrimp_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter2.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter2.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

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
                if (shrimpIndex == shrimpSentences.Length && bartenderIndex == bartenderSentences.Length)
                {
                    dontSpeak = true;
                    Invoke("endScene", 1f);
                    //beginChoices = true;
                }
                else
                {
                    dontInterrupt = true;
                    StartDialogue();
                }

            }
        }

        //Debug.Log(goInsideCabin.relocate);
        if (goInsideCabin.relocate && !startedSpeaking)
        {
            int num = PlayerPrefs.GetInt("berries");
            startedSpeaking = true;

            if (num == 6)
            {
                //Debug.Log("hyooo");
                Invoke("secondLines", 3f);

            }
            else
            {
                //Debug.Log("firstLines");
                //startedSpeaking = true;
                Invoke("firstLines", 3f);
            }

        }
    }

     private void endScene()
    {
        //Debug.Log("something wrong");
        goInsideCabin.free();
        elf.transform.position = new Vector3(53f, -5f, 0f);
        startedSpeaking = false;
        bartenderIndex = 0;
        dontSpeak = false;
        wait = true;
        //SceneManager.LoadScene("Water Ending");
    }

    private void firstLines()
    {
        dontInterrupt = true;
        wait = false;
        //Debug.Log("wait");
        StartCoroutine(TypeBartenderDialogue(bartenderSentences));
    }

    private void secondLines()
    {
        dontInterrupt = true;
        wait = false;
        StartCoroutine(TypeBartenderDialogue(bartenderSentences2));
    }
    private void disappearTextBubbles()
    {
        shrimp_bubble.SetActive(false);
        bartender_bubble.SetActive(false);

        shrimpDialogue.SetCharArray(new char[] { });
        bartenderDialogue.SetCharArray(new char[] { });
    }

    public void StartDialogue()
    {
        if (shrimpSpeaking)
            StartCoroutine(TypeShrimpDialogue(shrimpSentences));
        else
            StartCoroutine(TypeBartenderDialogue(bartenderSentences));
    }

    private IEnumerator TypeShrimpDialogue(string[] sentences)
    {
        shrimp_bubble.SetActive(true);
        ////
        foreach (char letter in sentences[shrimpIndex])
        {
            shrimpDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        shrimpIndex++;
        shrimpSpeaking = false;
        dontInterrupt = false;
        Debug.Log("shrimp index " + shrimpIndex);
        //StartDialogue();
    }

    private IEnumerator TypeBartenderDialogue(string[] sentences)
    {
        bartender_bubble.SetActive(true);
        //dontSpeak = true;
        ////
        foreach (char letter in sentences[bartenderIndex])
        {
            bartenderDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        bartenderIndex++;
        dontInterrupt = false;
        shrimpSpeaking = true;

    }
}
