using UnityEngine;
using System.Collections;

public class Gen_Explotion : MonoBehaviour {

	// Uienuse this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(1.0f);
		//Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
