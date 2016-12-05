using UnityEngine;

public class NetworkManager : MonoBehaviour {

	//public Camera sceneCamera;
	public GameObject gvrmain;

	public static bool isPlayerInScene = false;

	void Start () {
		Connect ();
	}

	void Connect() {
		PhotonNetwork.ConnectUsingSettings ("v1.0.0");
	}

	void OnGUI() {
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby() {
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}
	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");

		SpawnMyPlayer ();
	}

	void SpawnMyPlayer(){
		isPlayerInScene = true;
		GameObject player = PhotonNetwork.Instantiate ("Player_Multi", new Vector3 (-12.5f, 1f, -15f), Quaternion.identity, 0);
		//GvrViewer.Instance.VRModeEnabled = false;
		//sceneCamera.enabled = false;
		//GvrViewer.Instance. Controller.InvalidateEyes ();
		//Destroy (sceneCamera);
		//Camera.SetupCurrent (GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<Camera> ());
	}

	public static bool getIsPlayerSpawned() {
		return isPlayerInScene;
	}
}
