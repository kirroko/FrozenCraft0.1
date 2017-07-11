using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour {

	public void Quit()
	{
		//If we are running in a standalone build of the game
	#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
        PlayMusic.current.PressBack();
	#endif

		//If we are running in the editor
	#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
	}
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        ShowPanels.current.HidePausePanel();
        PlayMusic.current.PressBack();
    }
}
