using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public AudioSource[] sfx;
    public AudioSource[] musics;
    public Image[] characters;
    public Image Darkener;
    public Image Whitener;
    public Image DarkBackground;

    public bool scene_done = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Scene());
        scene_done = true;
    }

    public IEnumerator Scene()
    {
        yield return new WaitForSeconds(0.1f);
        Darkener.GetComponent<Animation>().Play("Fade_in_1");
        this.GetComponent<Animation>().Play("SoundFadeIn");
        yield return new WaitForSeconds(6);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[0]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[1]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[2]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        this.GetComponent<Animation>().Play("SoundFadeOut");
        Darkener.GetComponent<Animation>().Play("Fade_in_2");
        DarkBackground.GetComponent<Animation>().Play("Background_disappears");
        Whitener.GetComponent<Animation>().Play("Fade_in_white");
        yield return new WaitForSeconds(4.5f);
        this.sfx[0].Stop();
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[3]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        characters[0].GetComponent<Animation>().Play("BarMaidAppears");
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[4]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[5]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[6]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[7]);
        yield return WaitUntilDialogueDone();
        Whitener.GetComponent<Animation>().Play("Fade_out_white");
        yield return new WaitForSeconds(1f);
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
