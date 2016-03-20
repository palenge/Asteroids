using UnityEngine;
using System.Collections;

public class Gen_Menu : MonoBehaviour {

	public void LoadGame()
	{

		Application.LoadLevel("Ast_Game");
	} 
	public void Exit()
	{
		Application.Quit();
	}
	public void NewGame()
	{
		Time.timeScale = 1;
		Gen_Funciones.NewGamePlus ();
	}
	public void MainMenu()
	{
		Application.LoadLevel("Ast_Menu");
		
	}
}
