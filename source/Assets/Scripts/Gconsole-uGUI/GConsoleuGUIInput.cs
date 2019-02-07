using UnityEngine;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("Scripts/Gconsole-uGUI/GConsoleuGUIInput")]
public class GConsoleuGUIInput : MonoBehaviour
{
		[HideInInspector]
		public GConsoleuGUI uGUI;
		private string oldvalue;
		//private InputField input;
		private TMP_InputField input;

		void Start ()
		{
				input = GetComponent<TMP_InputField> ();
				input.onEndEdit.AddListener (onEndEdit);
				input.onValueChanged.AddListener (onChangeEdit);
		}

		void onEndEdit (string line)
		{
			if (Input.GetButtonDown ("Submit")) {	// make sure we only realy as a submition if submit key was used same frame (Ugly but workaround since uGUI triggers submit when inputfield is deselected)
				uGUI.OnInput ();
			}
		}
		
		void onChangeEdit(string line)
		{
			if (input.text != oldvalue) {
				uGUI.OnChange ();
			}
			oldvalue = input.text;
		}
}
