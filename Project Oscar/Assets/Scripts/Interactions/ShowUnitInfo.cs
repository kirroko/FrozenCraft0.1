using UnityEngine;
using System.Collections;

public class ShowUnitInfo : Interaction {

	public string Name;
	public float MaxHealth, CurrentHealth;

	public Sprite[] ProfilePic;

    private Sprite DefaultPic;

	bool show = false;

	public override void Select ()
	{
		show = true;
	}
    private void Start()
    {
        DefaultPic = ProfilePic[Random.Range(0, ProfilePic.Length)];
    }

    void Update ()
	{
		if (!show)
			return;
        InfoManager.Current.SetPic(DefaultPic);
		InfoManager.Current.SetLines (
			Name, 
			CurrentHealth + "/" + MaxHealth,
			"Owner: " + GetComponent<Player> ().Info.Name);
	}

	public override void Deselect ()
	{
		InfoManager.Current.ClearPic ();
		InfoManager.Current.ClearLines ();
		show = false;
	}
}
