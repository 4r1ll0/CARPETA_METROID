using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemies : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;

    private Vector3 posicionInicio;
    private bool moviendoAFin;

    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;
    }

    void Update()
    {
        Moverenemigo();
    }

    private void Moverenemigo()
    {
        //1. Calcular la posicion de destino.
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;
        //2. Mover enemigos.
        transform.position = Vector3.MoveTowards
            (transform.position, posicionDestino, velocidad * Time.deltaTime);

        //Cambio de dirrecion.
        if (transform.position == posicionFin) moviendoAFin = false;
        if (transform.position == posicionInicio) moviendoAFin = true;


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el objeto que a colisionado con el enemigo es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovPlayer>().FinJuego();
        }
    }


}
