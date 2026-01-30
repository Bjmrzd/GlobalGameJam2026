using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
public class SettingsButton : MonoBehaviour
{
    public void Settings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
