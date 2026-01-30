using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.UIElements;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public float text_speed = 0.2f;

    public bool dialogue_done = false;

    public Animator animator;
    public Queue<string> sentences;
    public bool isTyping = false;

    public Coroutine typingCoroutine;




    void Start()
    {

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogue_done = false;
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }


    IEnumerator EndTyping()
    {
        while (isTyping)
            yield return null;
        EndDialogue();
        dialogue_done = true;
    }
    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            StartCoroutine(EndTyping());
            return;
        }
        string sentence = sentences.Dequeue();
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(text_speed);
        }
        isTyping = false;

    }
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }

}
