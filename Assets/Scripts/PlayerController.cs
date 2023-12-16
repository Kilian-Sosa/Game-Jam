using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Vector2 direccion;

    [Header("Estadisticas")]
    public float velocidaDeMovimiento = 10;
    public float fuerzaDeSalto = 5;

    [Header("Colisiones")]
    public LayerMask layerPiso;
    public float radioDeColision;
    public Vector2 abajo;

    [Header("Booleanos")]
    public bool puedeMover = true;
    public bool enSuelo = true; //para controlar el salto en el aire

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Agarres();

        if (Input.GetKeyDown("space"))
        {
           

            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 300f, 0));
            Debug.Log("Tecla espacio");
            //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("saltar");
            //GameObject.Find("Plataforma").GetComponent<TilemapCollider2D>().
        }
    }

    public void Movimiento()
    {
        float x = Input.GetAxis("Horizontal"); //da como resultado 1 o -1 segun la direccion que vayas
        float y = Input.GetAxis("Vertical");

        //Vector2 direccion = new Vector2(x, y); //te da la direccion del muñeco!!!
        direccion = new Vector2(x, y);

        //Caminar(direccion);
        Caminar();
        //MejorarSalto();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (enSuelo)
            //{
                //anim.SetBool("saltar", true); //modificamos el booleano saltar para las animaciones 13
                Saltar();
            //}
        }

        if (enSuelo)
        {
            float velocidad;
            if (rb.velocity.y >= 0) //14
                velocidad = 1;
            else
                velocidad = -1;
            //anim.SetBool("caer", false); //13 lo quitamos en el 14
            anim.SetFloat("velocidadVertical", velocidad);
        }
        //else
        //{
        //    anim.SetBool("saltar", true); //13 lo sustutiumos por un evento
        //}
    }

    public void finalizarSalto() //13
    {
        anim.SetBool("saltar", false);
        anim.SetBool("caer", true);
    }

    private void MejorarSalto()
    {
        // Si la velocidad es menor que cero estoy cayendo
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (5f - 1) * Time.deltaTime;
        }
        else if ((rb.velocity.y > 0) && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (5f - 1) * Time.deltaTime;
        }
    }

    public void Agarres() //para controlar el salto doble
    {
        //hacemos casting porque transform es un vector de 3 vectores
        //el tercer parametro para el suelo
        enSuelo = Physics2D.OverlapCircle((Vector2)transform.position + abajo, radioDeColision, layerPiso);
    }

    public void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        //rb.velocity += direccion * fuerzaDeSalto;
        rb.velocity += Vector2.up * fuerzaDeSalto;
    }

    public void Caminar()
    {
        if (puedeMover)
        {
            rb.velocity = new Vector2(direccion.x * velocidaDeMovimiento, rb.velocity.y);

            if (direccion != Vector2.zero)
            {
                if (!enSuelo)
                {
                    anim.SetBool("caer", true); // si no esta en suelo hago animacion caer, para animaciones 13
                }
                else
                {
                    anim.SetBool("caminar", true); //13
                }

                if (direccion.x < 0 && transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }

                else if (direccion.x > 0 && transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                anim.SetBool("caminar", false); //13
            }

        }
    }

}
