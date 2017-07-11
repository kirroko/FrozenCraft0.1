using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Button exitText;


	// Use this for initialization
	void Start () 
	{
		exitText = exitText.GetComponent<Button> ();
	}

	public void Exit ()
	{
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
	}

	public void OptionsPress ()
	{
		exitText.enabled = false;
	}

	public void BackPress ()
	{
		exitText.enabled = true;
	}
}
