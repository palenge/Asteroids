using UnityEngine;
using System.Collections;

public class Gen_Pause : MonoBehaviour {

	bool isPaused;
	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!Gen_GameMaster.instance.Gen_ItsGameOver) {
			
				if (isPaused) {
					Time.timeScale = 0;
					Gen_GameMaster.instance.Gen_Pause.SetActive(true);
				} else{
					Time.timeScale = 1;
					Gen_GameMaster.instance.Gen_Pause.SetActive(false);
				
				}
				isPaused = !isPaused;
			}
		}
	}
}
