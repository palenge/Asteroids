using UnityEngine;using System.Collections;

public class Ast_Script : MonoBehaviour {

	public float Ast_Speed;
	public int Ast_level = 0;
	public Vector3 Ast_Position;
	public Vector3 Ast_Scale;
	// Use this for initialization

	void Start () {
		Gen_GameMaster.instance.Ast_Count++;
		if (Ast_level == 0) {
			float x = Random.Range (Gen_GameMaster.instance.Cam_MaxCamera.x * 0.3f, Gen_GameMaster.instance.Cam_MaxCamera.x);
			x = Random.value > 0.5f ? x: -x;
			float y = Random.Range (Gen_GameMaster.instance.Cam_MaxCamera.y* 0.3f, Gen_GameMaster.instance.Cam_MaxCamera.y);
			y = Random.value > 0.5f ? y: -y;
			
			this.transform.position = (new Vector3 (x, y, 0));
			float Scale = Random.Range (Gen_GameMaster.instance.Ast_MinSize, Gen_GameMaster.instance.Ast_MaxSize);
			this.transform.localScale = new Vector3 (Scale, Scale, 1);
		
		} else {
			this.transform.position = Ast_Position;
			this.transform.localScale = Ast_Scale * 0.5f;
		}
		this.transform.Rotate (0, 0, Random.Range (0, 360));
		Ast_Speed = Random.Range (Gen_GameMaster.instance.Ast_MinSpeed, Gen_GameMaster.instance.Ast_MaxSpeed);

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.up * Ast_Speed * Time.deltaTime;
		this.transform.position = Gen_Funciones.Gen_CheckWarp(this.transform.position);
	}


	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.tag == "Sho_Layer") {
			Sou_SoundManager.instance.Ast_PlayDestroy();
			Gen_GameMaster.instance.Sho_CurrentShot --;
			Gen_GameMaster.instance.Ast_Count--;
			Destroy(other.gameObject);
			if(Ast_level == 0){
				GameObject clone;
				clone = Instantiate(Gen_GameMaster.instance.Ast_GameObject) as GameObject;
				Gen_GameMaster.instance.Ast_List.Add(clone);
				Ast_Script aux = clone.GetComponent<Ast_Script>();
				aux.Ast_level = 1;
				aux.Ast_Position = this.transform.position;
				aux.Ast_Scale = this.transform.localScale;
				clone = Instantiate(Gen_GameMaster.instance.Ast_GameObject) as GameObject;
				Gen_GameMaster.instance.Ast_List.Add(clone);
				aux = clone.GetComponent<Ast_Script>();
				aux.Ast_level = 1;
				aux.Ast_Position = this.transform.position;
				aux.Ast_Scale = this.transform.localScale;
				Gen_GameMaster.instance.Sco_Value += Gen_GameMaster.instance.Ast_ScorePoints;
			}
			if(Ast_level == 1){
				GameObject clone;
				clone = Instantiate(Gen_GameMaster.instance.Ast_GameObject) as GameObject;
				Gen_GameMaster.instance.Ast_List.Add(clone);
				Ast_Script aux = clone.GetComponent<Ast_Script>();
				aux.Ast_level = 2;
				aux.Ast_Position = this.transform.position;
				aux.Ast_Scale = this.transform.localScale;
				clone = Instantiate(Gen_GameMaster.instance.Ast_GameObject) as GameObject;
				Gen_GameMaster.instance.Ast_List.Add(clone);
				aux = clone.GetComponent<Ast_Script>();
				aux.Ast_level = 2;
				aux.Ast_Position = this.transform.position;
				aux.Ast_Scale = this.transform.localScale;
				Gen_GameMaster.instance.Sco_Value += Gen_GameMaster.instance.Ast_ScorePointsSmall;
			} 
			if(Ast_level == 2){
				Gen_GameMaster.instance.Sco_Value += Gen_GameMaster.instance.Ast_ScorePointsSmall;
				Gen_Funciones.Ast_Check();
			}

			Instantiate (Gen_GameMaster.instance.Gen_Explotion, this.transform.position,Quaternion.identity);
			
			Destroy (this.gameObject);
			
	
		}
	}




}
