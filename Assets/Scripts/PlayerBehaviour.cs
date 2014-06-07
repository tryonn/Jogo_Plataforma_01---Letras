using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float speedMove;//velocidade do player
	public Transform player;//menino com a animation
	public bool isGrounded;//e chao
	public float force;//forca do pulo
	public float jumpTime = 0.4f;//tempo do pulo
	public float jumpDelay = 0.4f;//tempo da animacao
	public bool jumped;
	public Transform ground;


	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		movimento ();
	}

	void movimento(){
		isGrounded = Physics2D.Linecast(this.transform.position, ground.position, 1<<LayerMask.NameToLayer("Plataforma"));
		//chamando animacao do menino correndo
		animator.SetFloat("run", Mathf.Abs(Input.GetAxis("Horizontal")));

		//walk rigth
		if(Input.GetAxisRaw("Horizontal") > 0){
			transform.Translate(Vector2.right * speedMove * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		//walk lef
		if(Input.GetAxisRaw("Horizontal") < 0){
			transform.Translate(Vector2.right * speedMove * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}
		//jump
		if(Input.GetButtonDown("Jump") && isGrounded && !jumped){
			rigidbody2D.AddForce(transform.up * force);
			jumpTime = jumpDelay;
			//animacao pulando
			animator.SetTrigger("jump");
			jumped = true;
		}

		jumpTime -= Time.deltaTime;

		if(jumpTime <= 0 && isGrounded && jumped){
			animator.SetTrigger("ground");
			jumped = false;
		}
	}
}
