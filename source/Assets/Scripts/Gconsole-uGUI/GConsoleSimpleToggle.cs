using UnityEngine;

public class GConsoleSimpleToggle : MonoBehaviour {
	//public string toggleCMD = string.Empty;
	public GameObject consoleObject;

	void Update () {
		//if (toggleCMD == string.Empty) {
		//	return;
		//}
		if (Input.GetKeyUp("`")) {
			consoleObject.SetActive( !consoleObject.activeSelf );
		}
	}
}
