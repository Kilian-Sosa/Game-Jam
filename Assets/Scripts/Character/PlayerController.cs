using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public Vector2 direccion;

    [Header("Estadisticas")]
    private float velocidadDeMovimiento = 6;
    private float velocidadDeMovimientoReducida = 3;
    public float fuerzaDeSalto = 5;

    [Header("Booleanos")]
    private bool puedeMover = true;
    private bool grounded = false;

    public int contadorSalto = 0;

    [SerializeField] private GameObject AttackTriggerBox;
    private int playerDamage = 1;
    private int MaxSaltos = 1;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(puedeMover) Movimiento();
        if (Input.GetKeyDown("space")) Saltar();
        if (Input.GetButtonDown("Fire1")) Atacar();
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 1f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Enemy"))
            {
                contadorSalto = 0;
                grounded = true;
            }
        }
    }

    private void Atacar()
    {
        List<GameObject> Enemies = AttackTriggerBox.GetComponent<AttackTriggerBox>().GetEnemies();
        foreach(GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<EnemyStats>().TakeDamage(playerDamage);
        }
    }

    private void Movimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        direccion = new Vector2(x, y);
        rigidBody.velocity = new Vector2(direccion.x * GetVelocity(), rigidBody.velocity.y);
        if (x != 0) transform.localScale = CalculaDireccionPlayer(x);
    }
    private float GetVelocity()
    {
        return grounded ? velocidadDeMovimiento : velocidadDeMovimientoReducida;
    }
    private Vector3 CalculaDireccionPlayer(float direccion)
    {
        if(direccion < 0) return new Vector3(-1, transform.localScale.y, transform.localScale.z);
        else return new Vector3(1, transform.localScale.y, transform.localScale.z);
    }


    private void Saltar()
    {
        if (contadorSalto < MaxSaltos)
        {
            grounded = false;
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(direccion * velocidadDeMovimiento + Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
            contadorSalto++;
        }
    }
}
