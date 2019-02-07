using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    // Singleton instance of AudioManager
    // Can be accessed from any script
    public static GameController instance = null;

    void Awake()
    {
        // Check for already existing instances of AudioManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DisableCursor();
    }

    public void DisableCursor ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EnableCursor ()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
