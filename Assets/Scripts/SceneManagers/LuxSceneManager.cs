using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuxSceneManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public Narration[] narrations;
    // public Image Darkener;
    // public Image Whitener;
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
        // Darkener.GetComponent<Animation>().Play("Fade_in_1");
        // this.GetComponent<Animation>().Play("SoundFade_in");
        yield return new WaitForSeconds(3);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[0]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[1]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[2]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<NarrationManager>().StartNarration(narrations[0]);
        yield return WaitUntilNarrationDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[3]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[4]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[5]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<NarrationManager>().StartNarration(narrations[1]);
        yield return WaitUntilNarrationDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[6]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[7]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        // Darkener.GetComponent<Animation>().Play("Fade_in_2");
        DarkBackground.GetComponent<Animation>().Play("Background_disappears");
        // Whitener.GetComponent<Animation>().Play("Fade_in_white");
    }

    public IEnumerator WaitUntilDialogueDone()
    {
        while (FindFirstObjectByType<DialogueManager>().dialogue_done == false)
        {
            yield return null;
        }



    }
    public IEnumerator WaitUntilNarrationDone()
    {
        while (FindFirstObjectByType<NarrationManager>().narration_done == false)
        {
            yield return null;
        }

    }
}
