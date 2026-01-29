using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public Image Darkener;
    public Image Whitener;
    public Image DarkBackground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Scene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Scene()
    {
        yield return new WaitForSeconds(0.1f);
        Darkener.GetComponent<Animation>().Play("Fade_in_1");
        this.GetComponent<Animation>().Play("SoundFade_in");
        yield return new WaitForSeconds(6);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[0]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[1]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[2]);
        yield return WaitUntilDialogueDone();
        Darkener.GetComponent<Animation>().Play("Fade_in_2");
        DarkBackground.GetComponent<Animation>().Play("Background_disappears");
        Whitener.GetComponent<Animation>().Play("Fade_in_white");
    }

    public IEnumerator WaitUntilDialogueDone()
    {
        while (FindFirstObjectByType<DialogueManager>().dialogue_done == false)
        {
            yield return null;
        }
    }
}
