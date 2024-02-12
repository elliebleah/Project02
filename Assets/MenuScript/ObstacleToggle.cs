using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleToggle : MonoBehaviour
{
    public Toggle asteroid;
    // Start is called before the first frame updatepublic Toggle asteroid;
    public Toggle wave;
    public Toggle revolver, poisoner, still, progDif;

    void Start()
    {
        // Load previous toggle states
        asteroid.isOn = PlayerPrefs.GetInt("Asteroid", 0) == 1;
        wave.isOn = PlayerPrefs.GetInt("Wave", 0) == 1;
        revolver.isOn = PlayerPrefs.GetInt("Revolver", 0) == 1;
        poisoner.isOn = PlayerPrefs.GetInt("Poisoner", 0) == 1;
        still.isOn = PlayerPrefs.GetInt("Still", 0) == 1;
        progDif.isOn = PlayerPrefs.GetInt("Progressive", 0) == 1;

        // Add listener for each toggle
        asteroid.onValueChanged.AddListener(delegate { ToggleValueChanged(asteroid, "Asteroid"); });
        wave.onValueChanged.AddListener(delegate { ToggleValueChanged(wave, "Wave"); });
        revolver.onValueChanged.AddListener(delegate { ToggleValueChanged(revolver, "Revolver"); });
        poisoner.onValueChanged.AddListener(delegate { ToggleValueChanged(poisoner, "Poisoner"); });
        still.onValueChanged.AddListener(delegate { ToggleValueChanged(still, "Still"); });
        progDif.onValueChanged.AddListener(delegate {ToggleValueChanged(progDif, "Progressive");});
    }

    void ToggleValueChanged(Toggle toggle, string key)
    {
        int value = toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt(key, value);
    }
}
