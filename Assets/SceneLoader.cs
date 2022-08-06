using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string loadSceneName = "Stage1";
    public void LoadScene()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
