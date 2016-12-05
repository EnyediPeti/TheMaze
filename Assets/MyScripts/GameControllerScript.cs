using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	void LateUpdate()
	{
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed)
		{
			Application.Quit();
		}
	}

    public void LoadMultiplayerScene()
    {
        SceneManager.LoadScene(1);
    }
}
