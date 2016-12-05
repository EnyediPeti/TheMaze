using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public bool isDebugMode;
	public float speed;

	private Vector3 originalPosition;
	private Camera playerCamera;
	private Rigidbody playerRigidbody;
	private TimerScript timerScript;
	private GameObject[] finishItems;

	bool isMoving;

	void Start()
	{
		isMoving = false;
		originalPosition = transform.position;
		playerCamera = GetComponentInChildren<Camera>();
		playerRigidbody = GetComponent<Rigidbody>();
		timerScript = GameObject.FindWithTag("Timer").GetComponent<TimerScript>();
		finishItems = GameObject.FindGameObjectsWithTag("FinishItem");
		SetFinishItems(false);
	}

	void FixedUpdate()
	{
		if (isDebugMode)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			movement = playerCamera.transform.TransformDirection(movement);
			movement.Set(movement.x, 0.0f, movement.z);
			playerRigidbody.velocity = movement * speed;
		}
		else
		{
			if (Input.touches.Length != 0)
				isMoving = true;
			else
				isMoving = false;

			if (isMoving)
			{
				Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
				movement = playerCamera.transform.TransformDirection(movement);
				movement.Set(movement.x, 0.0f, movement.z);
				playerRigidbody.velocity = movement * speed;
			}
		}
	}

	public void ResetPlayer()
	{
		transform.position = originalPosition;
		SetFinishItems(false);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Finish")
		{
			timerScript.StopTimer();
			SetFinishItems(true);
		}
	}

	private void SetFinishItems(bool isActive)
	{
		foreach (GameObject g in finishItems)
		{
			g.SetActive(isActive);
		}
	}
}
