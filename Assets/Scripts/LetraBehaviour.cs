using UnityEngine;
using System.Collections;

public class LetraBehaviour : MonoBehaviour {
	public int ponto = 2;
	public float tempoMaximoVida;
	public float tempoVida;

	private VidasBehaviour vida;
	private ScoreBehaviour score;
	// Use this for initialization


	void Awake(){
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreBehaviour> () as ScoreBehaviour;
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		tempoVida += Time.deltaTime;
		if(tempoVida >= tempoMaximoVida){
			Destroy(gameObject);
			tempoVida = 0;
		}
	}


	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			vida = GameObject.FindGameObjectWithTag("Vidas").GetComponent<VidasBehaviour>() as VidasBehaviour;
			if(vida.ExcluirVida()){
				score.TiraScore(ponto);
				Destroy(gameObject);
			} else{
				//tela de gameover
				//gerenciador do jogo
			}
		}
	}
}
