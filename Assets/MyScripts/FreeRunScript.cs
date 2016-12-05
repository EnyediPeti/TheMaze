using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FreeRunScript : ButtonController {

	public void StartFreeRun() {
		goText.GetComponent<Text>().text = "Have fun!";

        SetMenuItems(false);

		goText.SetActive (true);
	}
}
