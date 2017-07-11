using UnityEngine;
using System.Collections.Generic;

public class AiSupport : MonoBehaviour {

	public List<GameObject> Drones = new List<GameObject>();
	public List<GameObject> CommandBases = new List<GameObject>();

	public PlayerSetupDefinition Player = null;

	public static AiSupport GetSupport (GameObject go)
	{
		return go.GetComponent<AiSupport>();
	}

	public void Refresh()
	{
		Drones.Clear ();
		CommandBases.Clear ();
		foreach (var u in Player.ActiveUnits) {
			if (u.name.Contains("Drone")) Drones.Add (u);
			if (u.name.Contains("Command Base")) CommandBases.Add(u);
		}
        if(Drones.Count <= 0 & CommandBases.Count <= 0)
        {
            Time.timeScale = 0;
            RtsManager.Current.title.text = "Victory!";
            RtsManager.Current.title.enabled = true;
            RtsManager.Current.exitTitle.enabled = true;
            RtsManager.Current.exitButton.enabled = true;
        }
	}
}
