using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Choice_manager : MonoBehaviour
{
    public TextMeshProUGUI NPC_Text;
    public TextMeshProUGUI Choice1_Text;
    public TextMeshProUGUI Choice2_Text;

    public bool choice_is_done = false;

    public Animator animator;
    public float text_speed = 0.6f;

    public Queue<string> Choice_1_queue;
    public Queue<string> Choice_2_queue;


    void Start()
    {
        Choice_1_queue = new Queue<string>();
        Choice_2_queue = new Queue<string>();
    }

    public void init_choice(Choice_dialogue choice)
    {
        choice_is_done = false;
        animator.SetBool("IsChoice", true);
        NPC_Text.text = choice.name_NPC;
        foreach (string Pick_1 in choice.choice_1)
        {
            Choice_1_queue.Enqueue(Pick_1);
        }
        foreach (string Pick_2 in choice.choice_2)
        {
            Choice_2_queue.Enqueue(Pick_2);
        }
        StartChoice();
    }


    public void StartChoice()
    {
        if (Choice_1_queue.Count == 0 || Choice_2_queue.Count == 0)
            return;


        string Pick_1 = Choice_1_queue.Dequeue();
        string Pick_2 = Choice_2_queue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type_Choice1(Pick_1));
        StartCoroutine(Type_Choice2(Pick_2));

    }
    public void Display_next_dialogue(Dialogue dialogue)
    {
        if (choice_is_done == true)
        {
            animator.SetBool("isOpen", true);
            NPC_Text.text = dialogue.name;
            DialogueManager.StartDialogue(dialogue);

        }
    }

    IEnumerator Type_Choice1(string text1)
    {
        Choice1_Text.text = "";
        foreach (char letter in text1.ToCharArray())
        {
            Choice1_Text.text += letter;
            yield return new WaitForSeconds(text_speed);
        }
    }

    IEnumerator Type_Choice2(string text2)
    {
        Choice2_Text.text = "";
        foreach (char letter in text2.ToCharArray())
        {
            Choice2_Text.text += letter;
            yield return new WaitForSeconds(text_speed);
        }
    }

    public void EndChoice()
    {
        animator.SetBool("IsChoice", false);
        choice_is_done = true;

    }

}
