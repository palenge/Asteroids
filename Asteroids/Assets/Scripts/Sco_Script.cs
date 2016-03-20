using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sco_Script : MonoBehaviour
{

	private Text Sco_Text;
	public bool Sco_Control = false; //Controla si afecta a la vida o al score 
	// Use this for initialization
	void Start ()
	{
		Sco_Text = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Sco_Text.text = Sco_Control ? Gen_GameMaster.instance.Sco_Value.ToString () : Gen_GameMaster.instance.Gen_Life.ToString ();
	}
}
