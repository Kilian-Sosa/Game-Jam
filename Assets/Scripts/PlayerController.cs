using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 direccion;

    [Header("Estadisticas")]
    public float velocidaDeMovimiento = 10;
    public float fuerzaDeSalto = 5;

    [Header("Booleanos")]
    public bool puedeMover = true;
    public bool enSuelo = true;

    public bool primerSalto = true;
    public bool salto = true;

    public int contadorSalto = 0;

    [SerializeField] private GameObject AttackTriggerBox;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        if (primerSalto)
        {
            Saltar();
        }

 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            contadorSalto = 0;
            primerSalto = true;
        }

        if (collision.gameObject.CompareTag("Enemigorl"))
        {
            AplicarDmg(collision.gameObject);
        }
    }


    private void AplicarDmg(GameObject jugador)
    {
        Debug.Log("DAMAGE");
    }

    public void Movimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        direccion = new Vector2(x, y);

        Caminar();

        if (Input.GetKeyDown(KeyCode.Space))
        {

                Saltar();
        }

        if (enSuelo)
        {
            float velocidad;
            if (rb.velocity.y >= 0) //14
                velocidad = 1;
            else
                velocidad = -1;
        }
    }


    public void Saltar()
    {
        if (Input.GetKeyDown("space") && contadorSalto < 2)
        {
            salto = true;
            primerSalto = false;

            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 15f, 0), ForceMode2D.Impulse);
            Debug.Log("Tecla espacio");
            contadorSalto++;
        }
    }


    public void Caminar()
    {
        if (puedeMover)
        {
            rb.velocity = new Vector2(direccion.x * velocidaDeMovimiento, rb.velocity.y);

            if (direccion != Vector2.zero)
            {
                if (direccion.x < 0 && transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }

                else if (direccion.x > 0 && transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }

}
