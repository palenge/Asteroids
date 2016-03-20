using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Gen_GameMaster : MonoBehaviour
{
	#region GAMEMASTER
	private static Gen_GameMaster _instance;

	public static Gen_GameMaster instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<Gen_GameMaster> ();
				//DontDestroyOnLoad (_instance.gameObject);
			}
				
			return _instance;
		}
	}

	void Awake ()
	{
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad (this);
		} else {
			if (this != _instance)
				Destroy (this.gameObject);
		}
	}
	#endregion

	#region Privados
	private Vector3 cam_maxcamera;
	private Vector3 cam_mincamera;

	#endregion

	#region publicas
	public int Sho_MaxShots;
	public int Sho_CurrentShot;
	public float  Sho_LifeTime;
	public float Sho_Speed = 0.5f;
	public GameObject Sho_GameObject;
	public GameObject Sho_AliGameObject;
	
	public int Ast_RoundCount;
	public GameObject Ast_GameObject;
	public float Ast_MinSize = 1.0f;
	public float Ast_MaxSize = 2.0f;
	public float Ast_MinSpeed = 0.5f;
	public float Ast_MaxSpeed = 0.5f;
	public int Ast_ScorePoints = 100;
	public int Ast_ScorePointsSmall = 200;
	public List<GameObject> Ast_List ;
	public int Ast_Count = 0;
	
	public GameObject Shi_Holder;
	public GameObject Ali_Holder;
	public List<GameObject> Ali_List;
	public float Ali_MaxSpeed = 0.5f;
	

	private GameObject gen_gameover;
	private GameObject gen_pause;
	public bool Gen_ItsGameOver = false;
	public GameObject Gen_Explotion;

	public int Gen_Life = 0;
	public int Gen_MaxLife = 3;
	public int Sco_Value = 0;
	#endregion
	#region Propiedades
	public GameObject Gen_GameOver
	{
		get{ 
			if(gen_gameover == null)
				gen_gameover = GameObject.Find("Gen_GameOverHolder");
			return gen_gameover;
		}
	}

	public GameObject Gen_Pause
	{
		get{ 
			if(gen_pause == null)
				gen_pause = GameObject.Find("Gen_PauseHolder");
			return gen_pause;
		}
	}


	public Vector3 Cam_MaxCamera {
		get { 
			if (cam_maxcamera == Vector3.zero) { 
				cam_maxcamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, Camera.main.nearClipPlane)); 
				Debug.Log (cam_maxcamera);
			}
			return cam_maxcamera; 
		}
	}

	public Vector3 Cam_MinCamera {
		get { 
			if (cam_mincamera == Vector3.zero) {
				cam_mincamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.nearClipPlane)); 
				Debug.Log (cam_mincamera);
			}
			return cam_mincamera; 
		}
	}
	#endregion



	#region Funciones

	#endregion

}