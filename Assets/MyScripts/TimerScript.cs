using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using System;

public class TimerScript : ButtonController {

	private Stopwatch timer;
	private GameObject elapsedTime;
	Text timerText;

	void Start () {
        base.Start();
        timer = new Stopwatch ();
		goText.SetActive (false);
		timerText = GetComponent<Text> ();
	}

	void Update () {
		timerText.text = new DateTime (timer.Elapsed.Ticks).ToString ("mm:ss");
	}

	public void StartTimer () {
		timer.Reset ();
		timer.Start ();

        SetMenuItems(false);

		goText.SetActive (true);
	}

	public void StopTimer () {
		timer.Stop ();

        SetMenuItems(true);

		goText.GetComponent<Text>().text = "GO!";
		goText.SetActive (false);
	}
}
