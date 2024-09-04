using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    float speed;

    public int damage;
     Player player;

    public GameObject explossion;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        speed= Random.Range(minSpeed,maxSpeed);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= 0.70f)
        {
            // 85% de las veces caerá hacia abajo (ángulo de 0°)
            moveDirection = Vector2.down;
        }
        else
        {
            // 15% de las veces caerá con un ángulo aleatorio entre -45° y 45°
            float angle = Random.Range(-45f, 45f);
            float angleRad = angle * Mathf.Deg2Rad;
            moveDirection = new Vector2(Mathf.Sin(angleRad), -Mathf.Cos(angleRad)).normalized;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
       
        if (hitObject.tag == "Player")
        {
            player.TakeDamage(damage);
            Instantiate(explossion, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        if (hitObject.tag == "Ground")
        {
            Instantiate(explossion, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}

