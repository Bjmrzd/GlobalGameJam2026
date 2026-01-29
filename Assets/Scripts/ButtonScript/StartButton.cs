using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class StartButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
