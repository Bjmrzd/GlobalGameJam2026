using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

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
        this.GetComponent<Animation>().Play("SoundFadeOut");
        yield return new WaitForSeconds(2f);
        Darkener.GetComponent<Animation>().Play("Fade_in_2");
        DarkBackground.GetComponent<Animation>().Play("Background_disappears");
        Whitener.GetComponent<Animation>().Play("Fade_in_white");
        yield return new WaitForSeconds(4.5f);
        this.sfx[0].Stop();
        this.musics[0].GetComponent<Animation>().Play("main_hub_fade_in");
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[3]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        characters[0].GetComponent<Animation>().Play("BarMaidAppears");
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[4]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        characters[1].GetComponent<Animation>().Play("PlayerAppears");
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[5]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[6]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[7]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        Whitener.GetComponent<Animation>().Play("fade_out_white");
        yield return new WaitForSeconds(2f);
        characters[0].GetComponent<Image>().color = new Color(characters[0].GetComponent<Image>().color.r, characters[0].GetComponent<Image>().color.g, characters[0].GetComponent<Image>().color.b, 0f);
        characters[1].GetComponent<Image>().color = new Color(characters[1].GetComponent<Image>().color.r, characters[1].GetComponent<Image>().color.g, characters[1].GetComponent<Image>().color.b, 0f);
        characters[2].GetComponent<Image>().color = new Color(characters[2].GetComponent<Image>().color.r, characters[2].GetComponent<Image>().color.g, characters[2].GetComponent<Image>().color.b, 255f);
        characters[3].GetComponent<Image>().color = new Color(characters[3].GetComponent<Image>().color.r, characters[3].GetComponent<Image>().color.g, characters[3].GetComponent<Image>().color.b, 255f);
        Whitener.GetComponent<Animation>().Play("Fade_in_white");
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[8]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[9]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[10]);
        yield return WaitUntilDialogueDone();
        // characters[2].getComponent<Animation>().Play("Character_disappears");
        // yield return new WaitForSeconds(1f);
        // characters[1].getComponent<Animation>().Play("PlayerAppears");
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[11]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[12]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[13]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[14]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[15]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogues[16]);
        yield return WaitUntilDialogueDone();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator WaitUntilDialogueDone()
    {
        while (FindFirstObjectByType<DialogueManager>().dialogue_done == false)
        {
            yield return null;
        }
    }


}
