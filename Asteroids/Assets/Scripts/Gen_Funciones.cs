using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gen_Funciones : MonoBehaviour {

	/// <summary>
	/// Valida la posicion para los asteroides
	/// </summary>
	public static Vector3 Gen_CheckWarp (Vector3 Position)
	{
		Vector3 aux = Position;
		if (Gen_GameMaster.instance.Cam_MaxCamera.x + 0.5f < aux.x)
			aux.x = Gen_GameMaster.instance.Cam_MinCamera.x + 0.5f;
		
		if (Gen_GameMaster.instance.Cam_MinCamera.x -0.5f > aux.x)
			aux.x = Gen_GameMaster.instance.Cam_MaxCamera.x - 0.5f;
		
		if (Gen_GameMaster.instance.Cam_MaxCamera.y + 0.5f < aux.y)
			aux.y = Gen_GameMaster.instance.Cam_MinCamera.y + 0.5f;
		
		if (Gen_GameMaster.instance.Cam_MinCamera.y -0.5f > aux.y)
			aux.y = Gen_GameMaster.instance.Cam_MaxCamera.y - 0.5f;
		return aux;
	}

	public static void Gen_Asteroids()
	{
		Instantiate (Gen_GameMaster.instance.Ali_Holder);
		for (int x =0; x < Gen_GameMaster.instance.Ast_RoundCount; x++) {
			GameObject clone;
			clone = Instantiate(Gen_GameMaster.instance.Ast_GameObject) as GameObject;
			Gen_GameMaster.instance.Ast_List.Add(clone);

		}
	}

	public static void GameOver(){

		Gen_GameMaster.instance.Gen_GameOver.SetActive(true);
		Gen_GameMaster.instance.Gen_Pause.SetActive(false);
		Gen_GameMaster.instance.Gen_ItsGameOver = true;
		

	}

	public static void Ast_Check(){
		if (Gen_GameMaster.instance.Ast_Count == 0) {
			Gen_GameMaster.instance.Ast_List.Clear();
			Gen_Funciones.Gen_Asteroids ();
		}
		
	}

	public static void NewGamePlus()
	{
		foreach (var item in Gen_GameMaster.instance.Ali_List) 
			Destroy (item);
		Gen_GameMaster.instance.Ali_List.Clear ();
		foreach (var item in Gen_GameMaster.instance.Ast_List) 
			Destroy (item);
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("Shi_Holder")) 
			Destroy(o);

		Gen_GameMaster.instance.Gen_ItsGameOver = false;
		Gen_GameMaster.instance.Ast_List.Clear ();
		Gen_GameMaster.instance.Gen_GameOver.SetActive(false);
		Gen_GameMaster.instance.Gen_Pause.SetActive(false);
		Gen_GameMaster.instance.Gen_Life = Gen_GameMaster.instance.Gen_MaxLife;
		Gen_GameMaster.instance.Sco_Value = 0;
		Gen_Funciones.Gen_Asteroids (); //TODO Quitar!!!
		Sou_SoundManager.instance.Gen_PlayBackgorund ();
		Instantiate (Gen_GameMaster.instance.Shi_Holder);

	}

	public static void NewGame()
	{
		Gen_GameMaster.instance.Gen_ItsGameOver = false;
		
		Gen_GameMaster.instance.Gen_GameOver.SetActive(false);
		Gen_GameMaster.instance.Gen_Pause.SetActive(false);
		Gen_GameMaster.instance.Gen_Life = Gen_GameMaster.instance.Gen_MaxLife;
		Gen_GameMaster.instance.Sco_Value = 0;
		Gen_Asteroids (); //TODO Quitar!!!
		Sou_SoundManager.instance.Gen_PlayBackgorund ();
		Instantiate(Gen_GameMaster.instance.Shi_Holder);
	}
}
