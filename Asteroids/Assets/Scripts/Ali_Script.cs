using UnityEngine;
using System.Collections;

public class Ali_Script : MonoBehaviour {

	public float Ali_RotationSpeed = 1.0f;
	public float Ali_MovementSpeed = 1.0f;
	public float Ali_MaxSpeed = 15.0f;
	public float Ali_Force = 1.0f;
	public Vector3 Ali_CurrentSpeed = Vector3.zero;
	public Vector3 Ali_CurrentForce = Vector3.zero;
	private bool Ali_CanShoot =false;
	BoxCollider2D Ali_CurrentBox2D;
	SpriteRenderer Ali_Sprite;
	Vector3 aux;


	// Use this for initialization
	void Start ()
	{
		Gen_GameMaster.instance.Ast_List.Add (this.gameObject);
		Ali_CurrentBox2D = this.GetComponent<BoxCollider2D> ();
		Ali_Sprite = this.GetComponent<SpriteRenderer> ();
		Ali_CanShoot = false;
		StartCoroutine (startEngine ());
		StartCoroutine (ChangeRotation());
		StartCoroutine (Shot());
	}
	
	IEnumerator  startEngine()
	{

		yield return new WaitForSeconds (Random.Range (5.0f, 10.0f));
		Ali_CurrentBox2D.enabled = true;
		Ali_Sprite.enabled = true;
		Ali_CanShoot = true;
		Vector3 aux = Gen_GameMaster.instance.Cam_MinCamera;
		aux.y = Random.Range (Gen_GameMaster.instance.Cam_MinCamera.y, Gen_GameMaster.instance.Cam_MaxCamera.y);
		aux.z = 0.0f;
		this.transform.position = aux;
		
	}

	IEnumerator  ChangeRotation()
	{
		yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		this.transform.Rotate(0f,0f,Random.Range (-45,45));
		StartCoroutine (ResetRotation());
	}

	IEnumerator  ResetRotation()
	{
		yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		Quaternion tmp = Quaternion.Euler (0, 0, 0);
		this.transform.rotation = tmp; //(0f,0f,Random.Range (-45,45));
		StartCoroutine (ChangeRotation());
	}

	IEnumerator Shot(){
		yield return new WaitForSeconds (Random.Range (2.0f, 3.0f));
		Quaternion tmp = Quaternion.Euler (0, 0, Random.Range (0, 360));
		if(Ali_CanShoot)
			Instantiate(Gen_GameMaster.instance.Sho_AliGameObject, this.transform.position, tmp);
		StartCoroutine (Shot());
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.right * Gen_GameMaster.instance.Ali_MaxSpeed * Time.deltaTime;
		this.transform.position = Gen_Funciones.Gen_CheckWarp(this.transform.position);

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ast_Layer" || other.tag == "Sho_Layer") {
			if(other.tag == "Sho_Layer"){
				Destroy (other.gameObject);
				Gen_GameMaster.instance.Sco_Value += 500;
				Gen_GameMaster.instance.Sho_CurrentShot--;
			}
			Sou_SoundManager.instance.Shi_PlayDestroy();
			Instantiate (Gen_GameMaster.instance.Ali_Holder);
			Instantiate (Gen_GameMaster.instance.Gen_Explotion, this.transform.position,Quaternion.identity);

			Destroy (this.gameObject);
		}
	}
}
