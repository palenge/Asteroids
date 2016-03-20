using UnityEngine;
using System.Collections;

public class Sho_Script : MonoBehaviour {
	
	void Start(){
		Gen_GameMaster.instance.Sho_CurrentShot ++;
			Sou_SoundManager.instance.Shi_PlayShot();
		
		StartCoroutine(this.DestroyMe ());
	}
	
	IEnumerator DestroyMe(){
		yield return new WaitForSeconds(Gen_GameMaster.instance.Sho_LifeTime);
		Gen_GameMaster.instance.Sho_CurrentShot --;
		Destroy(this.gameObject);
	}

	
	void Update()
	{
		this.transform.position += this.transform.up * Gen_GameMaster.instance.Sho_Speed * Time.deltaTime;
		this.transform.position = Gen_Funciones.Gen_CheckWarp(this.transform.position);
	}
}
