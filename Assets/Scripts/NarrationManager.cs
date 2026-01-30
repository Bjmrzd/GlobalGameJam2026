using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class NarrationManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI NarrationText;
    public float text_speed = 0.2f;

    public bool narration_done = false;

    public Animator animator;
    public Queue<string> sentences;

    public bool isTyping = false;

    public Coroutine typingCoroutine;
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

    IEnumerator EndTyping()
    {
        while (isTyping)
            yield return null;
        EndNarration();
        narration_done = true;
    }

    public void Display_NextSentence()
    {


        if (sentences.Count == 0)
        {
            StartCoroutine(EndTyping());
            return;
        }


        string sentence = sentences.Dequeue();
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(Type_Sentence(sentence));

    }
    IEnumerator Type_Sentence(string sentence)
    {
        isTyping = true;
        NarrationText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            NarrationText.text += letter;
            yield return new WaitForSeconds(text_speed);
        }
        isTyping = false;
    }
    void EndNarration()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }

}
