using UnityEngine;
using System.Collections;

public class Sou_SoundManager : MonoBehaviour
{
	private static Sou_SoundManager _instance;
		
	public AudioClip Ast_Destroy;
	public AudioClip Shi_Shot;
	public AudioClip Shi_Destroy;
	public AudioClip Shi_Respawm;
	public AudioSource gen_background;
	public AudioClip Gen_BackGround;
	public AudioClip Gen_MenuBackGround;

	public static Sou_SoundManager instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<Sou_SoundManager> ();
					
				//DontDestroyOnLoad (_instance.gameObject);
			}
				
			return _instance;
		}
	}
		
	void Awake ()
	{
		if (_instance == null) {
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad (this);
		} else {
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if (this != _instance)
				Destroy (this.gameObject);
		}
	}

	public AudioSource Gen_Background
	{
		get{ 
			if(gen_background == null)
				gen_background = GameObject.Find("SoundBackGround").GetComponent<AudioSource>();
			return gen_background;
		}
	}

	public void Gen_PlayBackgorund(){
		Gen_Background.clip = Gen_BackGround;
		Gen_Background.volume = 0.05f;
		Gen_Background.Play ();
	}

	public void Gen_StopBackgorund(){
		Gen_Background.clip = Gen_MenuBackGround;
		Gen_Background.volume = 1.0f;
		Gen_Background.Play ();
	}
		
	public void Shi_PlayShot()
	{
		audio.PlayOneShot(Shi_Shot,1.0f);
	}

	public void Shi_PlayRespawm()
	{
		audio.PlayOneShot(Shi_Respawm,1.0f);
	}

	public void Ast_PlayDestroy()
	{
		audio.PlayOneShot(Ast_Destroy,1.0f);
	}

	public void Shi_PlayDestroy()
	{
		audio.PlayOneShot(Shi_Destroy,1.0f);
	}

}
