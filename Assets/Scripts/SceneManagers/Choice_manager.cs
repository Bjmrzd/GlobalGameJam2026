using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Choice_manager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI Choice1_Text;
    public TextMeshProUGUI Choice2_Text;

    public bool choice_is_done = false;

    public Animator animator;
    public float text_speed = 0.6f;

    public Queue<string> Choice_1;
    public Queue<string> Choice_2;


    void Start()
    {
        Choice_1 = new Queue<string>();
        Choice_2 = new Queue<string>();
    }

    public void init_choice(Choice_dialogue choice)
    {
        choice_is_done = false;
        animator.SetBool("IsChoice", true);
        nameText.text = choice.name_NPC;
        foreach (string Choice_1 in choice.choice_1)
        {
            Choice_1.Enqueue(Choices_1);
        }
        foreach (string Choice_2 in choice.choice_2)
        {
            Choice_2.Enqueue(Choices_2);
        }
        StartChoice();
    }


    public void StartChoice()
    {

        string Choices_1 = Choice_1.Dequeue();
        string Choices_2 = Choice_2.Dequeue();
        StartCoroutine(Type_Choice1(Choices_1));
        StartCoroutine(Type_Choice2(Choices_2));

    }
    public void Display_next_dialogue(Dialogue dialogue)
    {
        if (choice_is_done == true)
        {
            animator.SetBool("isOpen", true);
            nameText.text = dialogue.name;

        }
    }

    IEnumerator Type_Choice1(string Choice_1)
    {
        Choice_1.text = "";
        foreach (char letter in Choice_1.ToCharArray())
        {
            Choice_1.text += letter;
            yield return new WaitForSeconds(text_speed);
        }
    }

    IEnumerator Type_Choice2(string Choice_2)
    {
        Choice_2.text = "";
        foreach (char letter in Choice_2.ToCharArray())
        {
            Choice_2.text += letter;
            yield return new WaitForSeconds(text_speed);
        }
    }

    public void EndChoice()
    {
        animator.SetBool("IsChoice", false);

    }



}
