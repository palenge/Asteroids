using UnityEngine;
using System.Collections;

public class Gen_SpriteBackGround : MonoBehaviour {

	public Sprite[] aux;
	public int speed = 60;
	public int chosen = 1;
	public int iterator = 1;
	private SpriteRenderer spriter;
	// Use this for initialization
	void Start () {
		spriter = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 4) == 1) {
			spriter.sprite = aux [Random.Range(0,aux.Length -1)];
		}
	}
}
