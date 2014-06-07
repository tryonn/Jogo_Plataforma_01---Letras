using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {

	public static int ponto;
	public static ScoreBehaviour instance;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiText.text = "Scores: " + ponto;
	}

	public void AddScore(int score){
		ponto += score;
		guiText.text = "Scores: " + ponto;
	}

	public void TiraScore(int score){
		ponto -= score;
		guiText.text = "Scores: " + ponto;
	}

	public static void InicializarPonto(){
		ponto = 0;
	}
}
