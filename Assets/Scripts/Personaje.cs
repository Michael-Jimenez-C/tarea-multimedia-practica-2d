using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    Rigidbody2D caballeroRB;
    public float maximaVelocidad = 5f;


    //Voltear Caballero
    bool voltearCaballero = true;
    bool enSuelo = true;

    SpriteRenderer caballeroRender;

    public Animator anim;
    void Start()
    {
        caballeroRB = GetComponent<Rigidbody2D>();
	caballeroRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float mover = Input.GetAxis("Horizontal");
	float jump = Input.GetAxis("Jump");
	float salto  = 0;


	if(!enSuelo){
		anim.SetBool("Jump",true);
	}else{
		anim.SetBool("Jump",false);
		if (mover!=0){
			anim.SetBool("Run",true);
		}else{
			anim.SetBool("Run",false);
		}
	}

	if (mover > 0 &&  !voltearCaballero){
		Voltear();
	}else if(mover < 0 && voltearCaballero){
		Voltear();
	}

	if (jump > 0 && enSuelo){
		enSuelo = false;
		salto = 5f;
	}

	caballeroRB.velocity = new Vector3(mover*maximaVelocidad, caballeroRB.velocity.y+salto,0);

    }

    void Voltear(){
    	voltearCaballero = !voltearCaballero;
	caballeroRender.flipX = !caballeroRender.flipX;
    }

    void OnCollisionEnter2D(Collision2D colision){
	Debug.Log("colision");
    	if (colision.gameObject.CompareTag("Piso")){
		enSuelo = true;
		Debug.Log("piso");
	}
    }
}
