using UnityEngine;
using System.Collections;

public class CameraCradle : MonoBehaviour {

	public float Speed = 20;
	public float Height = 80;

	// Use this for initialization
	void Start () {
		foreach (var p in RtsManager.Current.Players) {
			if (p.IsAi)
				continue;

			var pos = p.Location.position;
			pos.y = Height;
			transform.position = pos;
		}
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Speed = 80;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Speed = 40;
        }
		transform.Translate (
			Input.GetAxis ("Horizontal") * Speed * Time.deltaTime,
			Input.GetAxis ("Vertical") * Speed * Time.deltaTime,
			0);
	}
}
