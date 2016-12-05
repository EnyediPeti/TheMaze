using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController_Multi : MonoBehaviour {

	public bool isDebugMode;
	public float speed;

	bool isMoving;

	void Start() {
		isMoving = false;
	}

	void FixedUpdate() {
		if (isDebugMode) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			movement = GetComponentInChildren<Camera> ().transform.TransformDirection (movement);
			movement.Set (movement.x, 0.0f, movement.z);
			GetComponent<Rigidbody> ().velocity = movement * speed;
		} 
		else {
			if (Input.touches.Length != 0)
				isMoving = true;
			else
				isMoving = false;

			if (isMoving) {
				Vector3 movement = new Vector3 (0.0f, 0.0f, 1.0f);
				movement = GetComponentInChildren<Camera> ().transform.TransformDirection (movement);
				movement.Set (movement.x, 0.0f, movement.z);
				GetComponent<Rigidbody> ().velocity = movement * speed;
			}
		}
	}

	void LateUpdate() {
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void LoadSingleplayerScene() {
		SceneManager.LoadScene (0);
	}
}
