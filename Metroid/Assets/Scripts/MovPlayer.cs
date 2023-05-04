using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public int velocidad;

    private Rigidbody2D fisica;

    private void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad,fisica.velocity.y);
    }
}
