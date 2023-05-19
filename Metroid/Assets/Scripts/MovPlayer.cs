using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovPlayer : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;

    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private Animator animacion;

    private void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad,fisica.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Tocarsuelo
            ())
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        //si va hacia la derech FlipX = false (no volteo)
        if (fisica.velocity.x > 0) sprite.flipX = false;
        //si va hacia la izquierda volteo flipX = true
        else if (fisica.velocity.x < 0) sprite.flipX = true;

        animarJugador();
    }

    private void animarJugador()
    {
        //Jugador saltando
        if (!Tocarsuelo()) animacion.Play("jugadorsalto");
        //Jugador Corriendo
        else if ((fisica.velocity.x > 1 || fisica.velocity.x < -1)
            && fisica.velocity.y == 0) animacion.Play("jugadorcorriendo");
        //Jugador parado
        else if ((fisica.velocity.x < 1 || fisica.velocity.x > -1)
            && fisica.velocity.y == 0) animacion.Play("jugadorparado");
    }


    private bool Tocarsuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3
            (0, -2, 0), Vector2.down, 0.2f);
        return toca.collider != null;
        
    }

    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
