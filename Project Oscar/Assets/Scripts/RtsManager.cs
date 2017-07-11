using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class RtsManager : MonoBehaviour {

	public static RtsManager Current = null;

	public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();

	public TerrainCollider MapCollider;

    public Text title;
    public Text exitTitle;
    public Button exitButton;

    public List<GameObject> PlayerDrones = new List<GameObject>();
    public List<GameObject> PlayerBase = new List<GameObject>();


    public bool win_lost = false;

	public RtsManager() {
		Current = this;
	}

	public Vector3? ScreenPointToMapPosition(Vector2 point)
	{
		var ray = Camera.main.ScreenPointToRay (point);
		RaycastHit hit;
		if (!MapCollider.Raycast (ray, out hit, Mathf.Infinity))
			return null;

		return hit.point;
	}

	public bool IsGameObjectSafeToPlace(GameObject go)
	{
		var verts = go.GetComponent<MeshFilter> ().mesh.vertices;

		var obstacles = GameObject.FindObjectsOfType<UnityEngine.AI.NavMeshObstacle> ();
		var cols = new List<Collider> ();
		foreach (var o in obstacles) {
			if (o.gameObject != go) {
				cols.Add (o.gameObject.GetComponent<Collider> ());
			}
		}

		foreach (var v in verts) {
			UnityEngine.AI.NavMeshHit hit;
			var vReal = go.transform.TransformPoint (v);
			UnityEngine.AI.NavMesh.SamplePosition (vReal, out hit, 20, UnityEngine.AI.NavMesh.AllAreas);

			bool onXAxis = Mathf.Abs (hit.position.x - vReal.x) < 0.5f;
			bool onZAxis = Mathf.Abs (hit.position.z - vReal.z) < 0.5f;
			bool hitCollider = cols.Any (c => c.bounds.Contains (vReal));

			if (!onXAxis || !onZAxis || hitCollider) {
				return false;
			}
		}

		return true;
	}

	// Use this for initialization
	void Awake() {
        Debug.Log(Players[0].Name);
        title.enabled = false;
        exitTitle.enabled = false;
        exitButton.enabled = false;
		foreach (var p in Players) {
			foreach (var u in p.StartingUnits)
			{
				var go = (GameObject)GameObject.Instantiate(u, p.Location.position, p.Location.rotation);

				var player = go.AddComponent<Player>();
				player.Info = p;
				if (!p.IsAi)
				{
					if (Player.Default == null) Player.Default = p;
					go.AddComponent<RightClickNavigation>();
					go.AddComponent<ActionSelect>();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Players[0].Credits += 1000; 
        }
        PlayerDrones.Clear();
        PlayerBase.Clear();
        foreach (var u in Players[0].ActiveUnits)
        {
            if (u.name.Contains("Drone")) PlayerDrones.Add(u);
            if (u.name.Contains("Command Base")) PlayerBase.Add(u);
        }
        if(PlayerDrones.Count <=0 && PlayerBase.Count <=0)
        {
            title.enabled = true;
            exitTitle.enabled = true;
            exitButton.enabled = true;
        }
	}
}
