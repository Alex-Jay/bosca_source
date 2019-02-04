using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Camera _camera;
    public GameObject pauseMenu;
    public GameObject pauseTint;
    public GameObject gameUI;

    private bool cutVolume = true;

    void Awake ()
    {
        gameUI.SetActive(true);
        pauseTint.SetActive(false);
        pauseMenu.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        _camera.GetComponent<MouseLook>().enabled = false;

        if (cutVolume)
        {
            // Cut volume by 50%
            AudioManager.instance.masterVolume = AudioManager.instance.masterVolume / 2;
            cutVolume = false;
        }
        
        gameUI.SetActive(true);
        pauseTint.SetActive(true);
        pauseMenu.SetActive(true);

        // Show the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;
    }

    public void ResumeGame ()
    {
        _camera.GetComponent<MouseLook>().enabled = true;

        // Boost volume by 50%
        AudioManager.instance.masterVolume = AudioManager.instance.masterVolume * 2f;

        gameUI.SetActive(true);
        pauseTint.SetActive(false);
        pauseMenu.SetActive(false);

        cutVolume = true;

        Time.timeScale = 1f;
    }

    public void ReturnMainMenu ()
    {
        Time.timeScale = 1f;

        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Main Menu"));
    }

}
