using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManagerPenguin : MonoBehaviour
{
    public TextMeshProUGUI penguinDialogue;
    public GameObject penguin_bubble;

    private string[] penguinSentences = {"I hear the fishing is better in the North."};
    private string[] penguinSentences1 = {"My friend! Thank you for this pleasant surprise."};
    private int penguinIndex = 0;
    private float typingSpeed = 0.01f;

    public ElfMovement elf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        penguin_bubble.SetActive(false);

        ContentSizeFitter fitter3 = penguin_bubble.GetComponent<ContentSizeFitter>();

        fitter3.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter3.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

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
        StartCoroutine(TypeBartenderDialogue(penguinSentences));
    }

    private void lastLines()
    {
        StartCoroutine(TypeBartenderDialogue(penguinSentences1));
    }
    private void disappearTextBubbles()
    {
        penguin_bubble.SetActive(false);
        penguinDialogue.SetCharArray(new char[] { });
    }



    private IEnumerator TypeBartenderDialogue(string[] sentences)
    {
        penguin_bubble.SetActive(true);
        ////
        foreach (char letter in sentences[penguinIndex])
        {
            penguinDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        penguinIndex++;

    }
}
