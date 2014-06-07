using UnityEngine;
using System.Collections;

public class InimigoNegroBehaviour : MonoBehaviour {

	public GameObject objeto;
	private bool isEsquerda = true;
	public float velocidade = 5f;
	public float mxDelay;
	private float timeMovimento = 0f;

	public Transform verticeInicial;
	public Transform verticeFinal;
	public bool isAlvo;


	private float mxDelayObject = 0.01f;
	private float timeObject = 8f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movimentar ();
		RayCasting ();
		Behaviours ();
	}

	void RayCasting(){
		Debug.DrawLine (verticeInicial.position, verticeFinal.position, Color.red);
		//implementacao para saber onde determinado objeto esta no jogo
		isAlvo = Physics2D.Linecast (verticeInicial.position, verticeFinal.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours(){
		if(isAlvo){
			if(timeObject <= mxDelayObject){
				timeObject+= Time.deltaTime;
				//instanciando objeto
				Instantiate(objeto, verticeInicial.position, objeto.transform.rotation);
			}
		} else{
			timeObject = 0;
		}
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
