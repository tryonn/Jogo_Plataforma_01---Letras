﻿using UnityEngine;
using System.Collections;

public class InstanciadorBehaviour : MonoBehaviour {

	private bool isEsquerda = true;
	public float velocidade = 5f;
	public float mxDelay;

	public float instanciadorTempo = 5f;
	public float instanciadorDelay = 3f;

	private float timeMovimento = 0f;

	public GameObject[] objectPrefabs;
	public int valorMinimoRandom = 0;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", instanciadorTempo, instanciadorDelay);
	}
	
	// Update is called once per frame
	void Update () {
		movimentar ();
	}

	//
	void Spawn()
	{
		int index = Random.Range (valorMinimoRandom, objectPrefabs.Length);
		Instantiate (objectPrefabs [index], transform.position, objectPrefabs [index].transform.rotation);
	}

	void movimentar(){
		timeMovimento += Time.deltaTime;
		if(timeMovimento <= mxDelay){
			if(isEsquerda){
				transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,0);
			} else{
				transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,180);
			}
		} else{
			isEsquerda = !isEsquerda;
			timeMovimento = 0;
		}
	}
}
