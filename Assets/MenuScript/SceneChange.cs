using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string sceneName; // Name of the scene to switch to

    void Start()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();
        
        // Add an OnClick listener to the button
        button.onClick.AddListener(SwitchScene);
    }

    public void SwitchScene()
    {
        // Load the scene specified by sceneName
        SceneManager.LoadScene(sceneName);
    }
}

