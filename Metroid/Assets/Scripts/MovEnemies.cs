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
        if (moviendoAFin)
        {
            transform.position = Vector3.MoveTowards
                (transform.position,posicionFin, velocidad * Time.deltaTime);
            //Cuando llegue al destino
            if (transform.position == posicionFin)
                moviendoAFin = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards
                (transform.position, posicionInicio, velocidad * Time.deltaTime);
            //Cuaqndo llegue al inicio
            if (transform.position == posicionInicio)
                moviendoAFin = true;
        }
    }
}