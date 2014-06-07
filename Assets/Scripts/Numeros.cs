using UnityEngine;
using System.Collections;

public class Numeros : MonoBehaviour {

	public int pontos = 10;
	public AudioClip clip;
	private float tempoVida;//do numero
	public float tempoMaximoVida;//do numero

	private ScoreBehaviour score;
	// Use this for initialization


	void Awake(){
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreBehaviour> () as ScoreBehaviour;
	}
	void Start () 
	{
		tempoVida = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempoVida += Time.deltaTime;
		if(tempoVida >= tempoMaximoVida){
			Destroy(gameObject);
			tempoVida = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player"){
			score.AddScore(pontos);
			Destroy(gameObject);
		}
	}
}
