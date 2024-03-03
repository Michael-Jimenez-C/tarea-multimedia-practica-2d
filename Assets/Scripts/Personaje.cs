using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    Rigidbody2D caballeroRB;
    public float maximaVelocidad = 5f;


    //Voltear Caballero
    bool voltearCaballero = true;
    SpriteRenderer caballeroRender;
    
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
	Debug.Log(jump);

	if (mover > 0 &&  !voltearCaballero){
		Voltear();
	}else if(mover < 0 && voltearCaballero){
		Voltear();
	}

	caballeroRB.velocity = new Vector3(mover*maximaVelocidad, caballeroRB.velocity.y,0);

    }

    void Voltear(){
    	voltearCaballero = !voltearCaballero;
	caballeroRender.flipX = !caballeroRender.flipX;
    }
}
