using UnityEngine;

/// <summary>
/// Adds the quit command to the console, which closes the application (if in non-web non-editor build).
/// </summary>
public class GConsoleQuit : MonoBehaviour {

	void Start () {
	    GConsole.AddCommand("quit", "Quits the application.", QuitApplication);
	}

    string QuitApplication(string param)
    {
            Application.Quit();
            return null; //No point in returning a message if the application has already shut down.
    }
}
