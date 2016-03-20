using UnityEngine;
using System.Collections;

public class Shi_Controller : MonoBehaviour
{

	#region Publicos
	public Sprite Shi_On;
	public Sprite Shi_Off;
	public float Shi_RotationSpeed = 1.0f;
	public float Shi_MovementSpeed = 1.0f;
	public float Shi_MaxSpeed = 15.0f;
	public float Shi_Force = 1.0f;
	public Vector3 Shi_CurrentSpeed = Vector3.zero;
	public Vector3 Shi_CurrentForce = Vector3.zero;
	private bool Shi_CanShoot =false;
	PolygonCollider2D Shi_CurrentBox2D;
	SpriteRenderer Shi_Sprite;
	Vector3 aux;

	//Zona de Shoots
//	public int Sho_MaxShots = 5;
//	public int Cho_CurrentShot = 0;
	#endregion

	// Use this for initialization
	void Start ()
	{
		Shi_CurrentBox2D = this.GetComponent<PolygonCollider2D> ();
		Shi_Sprite = this.GetComponent<SpriteRenderer> ();
		Shi_CanShoot = false;
		StartCoroutine (startEngine ());
	}

	IEnumerator  startEngine()
	{
		Color color = renderer.material.color;
		yield return new WaitForSeconds (1.5f);
		Sou_SoundManager.instance.Shi_PlayRespawm ();
		Shi_Sprite .enabled = true;
		color.a = 0.4f;
		renderer.material.color = color;
		Shi_CanShoot = true;
		yield return new WaitForSeconds (1.5f);
		Shi_CurrentBox2D.enabled = true;
		color.a = 1.0f;
		renderer.material.color = color;
	}


	void ShotCheck(){
		if (Input.GetKeyDown (KeyCode.Space) && Shi_CanShoot) {
			if(Gen_GameMaster.instance.Sho_MaxShots > Gen_GameMaster.instance.Sho_CurrentShot){
				Instantiate(Gen_GameMaster.instance.Sho_GameObject, this.transform.position, this.transform.rotation);
			}
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Shi_CanShoot) {
			//Manejo del Movimiento de rotacion
			float shi_horizontal = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * Shi_RotationSpeed;
			this.transform.Rotate (new Vector3 (0, 0, -shi_horizontal));


			float shi_vertical = Input.GetAxisRaw ("Vertical") * Shi_MovementSpeed * Shi_Force;
			if (shi_vertical > 0.0)
			{
				Shi_CurrentForce += this.transform.up * shi_vertical;
				Shi_Sprite.sprite = Shi_On;
			}
			else
				Shi_Sprite.sprite = Shi_Off;

			//Validacion de Velocidad Maxima
			if (Shi_CurrentForce.magnitude > Shi_MaxSpeed)
				Shi_CurrentForce = Shi_CurrentForce.normalized * Shi_MaxSpeed;

			Shi_CurrentSpeed += Shi_CurrentForce * Time.deltaTime;

			Shi_CurrentSpeed = Gen_Funciones.Gen_CheckWarp (Shi_CurrentSpeed);
			this.transform.position = Shi_CurrentSpeed;
			//this.transform.position += this.transform.up * shi_vertical;
			ShotCheck ();
		}
		//Si se quiere mas cl'asico usando los senos y cosenos JueJueJue
		//this.transform.position += (new Vector3 (-Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad))) * shi_vertical;
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ast_Layer" || other.tag == "Sho_AliLayer") {
			if(other.tag == "Sho_AliLayer")
				Destroy(other.gameObject);
			Gen_GameMaster.instance.Gen_Life--;
			Sou_SoundManager.instance.Shi_PlayDestroy();
			if (Gen_GameMaster.instance.Gen_Life > 0) {
				Instantiate (Gen_GameMaster.instance.Shi_Holder);
			}
			else{
				Gen_Funciones.GameOver();
			}
				//Gen_GameMaster.instance.Gen_GameOver.enabled =true;
			Instantiate (Gen_GameMaster.instance.Gen_Explotion, this.transform.position,Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
