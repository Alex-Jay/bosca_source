using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start ()
    {
        AudioManager.instance.masterVolume = 0.5f;
    }

    public void PlayGame ()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Level 1"));
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
