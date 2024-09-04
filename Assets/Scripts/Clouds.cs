using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float scrollSpeed = 5f; // Velocidad a la que se mueve la nube
    public float floatLength = 10f; // Distancia que la nube recorre antes de desaparecer y reaparecer

    private Vector2 startPos;
    private float direction = 1f; // Dirección del movimiento, 1 para derecha y -1 para izquierda

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calcula la nueva posición en un bucle continuo
        float newPos = Mathf.PingPong(Time.time * scrollSpeed, floatLength);
        transform.position = new Vector2(startPos.x + (newPos * direction), startPos.y);
    }
}
