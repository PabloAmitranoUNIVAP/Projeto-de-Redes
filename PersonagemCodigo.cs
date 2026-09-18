﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemCodigo : MonoBehaviour {
	float velocidadeYp;
	float velocidadeXp;
	float alvovelocidadeXp;
	Vector2 Vetorvelocidadepersonagem;
	Rigidbody2D CorpoRigidoPersonagem;
	bool Apertoupulo;

	float accel = 0, accelmax = 6;
	float Direcao;

	// Use this for initialization
	void Start () {
		 velocidadeXp = 0f;
		velocidadeYp = 0f;

		 CorpoRigidoPersonagem = GetComponent<Rigidbody2D>();
		 Apertoupulo = false;
		 Vetorvelocidadepersonagem = new Vector2 (velocidadeXp, velocidadeYp);
	}
	
	// Update is called once per frame
	void Update () {
		Voar();
	}

	void Voar(){
		Apertoupulo = Input.GetButton ("Jump");
		Direcao = Input.GetAxis("Horizontal");
		if (Apertoupulo == true) velocidadeYp = 5;
		else velocidadeYp = CorpoRigidoPersonagem.velocity.y;

		if (velocidadeYp < 0) velocidadeYp -= accel * 0.03f;
		
		velocidadeXp = Mathf.MoveTowards(CorpoRigidoPersonagem.velocity.x, (7 + accel) * Direcao, 14 * Time.deltaTime);
		if (velocidadeXp != 0 || velocidadeYp < 0){
			if (accel < accelmax) accel += Time.deltaTime*3;
			else accel = accelmax;
		}
		else accel = 0;

		Vetorvelocidadepersonagem = new Vector2 (velocidadeXp, velocidadeYp);
		CorpoRigidoPersonagem.velocity = Vetorvelocidadepersonagem;
	}
}