using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class NarrationManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI NarrationText;
    public float text_speed = 0.6f;

    public bool narration_done = false;

    public Animator animator;
    public Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartNarration(Narration narration)
    {
        narration_done = false;
        animator.SetBool("isOpen", true);
        nameText.text = narration.name;
        sentences.Clear();

        foreach (string sentence in narration.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Display_NextSentence();
    }


    public void Display_NextSentence()
    {


        if (sentences.Count == 0)
        {
            EndNarration();
            narration_done = true;
            return;
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type_Sentence(sentence));

    }
    IEnumerator Type_Sentence(string sentence)
    {

        NarrationText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            NarrationText.text += letter;
            yield return new WaitForSeconds(text_speed);
        }

    }
    void EndNarration()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }

}
