using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class AudioButton : MonoBehaviour
{
    public void Audio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
