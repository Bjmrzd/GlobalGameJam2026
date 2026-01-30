using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Choice_dialogue
{
    public string name_NPC;

    public string[] choice_1;
    public string[] choice_2;

    public Dialogue nextDialogue1;

    public Dialogue nextDialogue2;


}
