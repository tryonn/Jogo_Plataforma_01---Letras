using UnityEngine;
using System.Collections;

public class VidasBehaviour : MonoBehaviour {

	//array para a imagem de vidas coracao
	public Texture2D[] vidasAtuais;
	private int vidas;
	private int contador;

	// Use this for initialization
	void Start () {
		guiTexture.texture = vidasAtuais [0];
		vidas = vidasAtuais.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool ExcluirVida(){
		if(vidas < 0){
			return false;
		}

		if(contador < (vidas-1)){
			contador += 1;
			guiTexture.texture = vidasAtuais [contador];
			return true;
		} else{
			return false;
		}
	}
}
