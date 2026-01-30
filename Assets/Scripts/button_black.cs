
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class button_black : MonoBehaviour
{
    public void game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
