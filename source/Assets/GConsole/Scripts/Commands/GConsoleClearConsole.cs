using UnityEngine;
using TMPro;

public class GConsoleClearConsole : MonoBehaviour
{
    private TMP_Text consoleText;

    void Start()
    {
        GConsole.AddCommand("clear", "Clears the console.", ClearConsole);
    }

    string ClearConsole (string param)
    {
        consoleText = GameObject.Find("gc_Output").GetComponent<TMP_Text>();
        consoleText.text = "Bosca Console V1.0\n";

        return null; //No point in returning a message if the application has already shut down.
    }
}
