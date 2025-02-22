using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public Vector2 direccion;

    [Header("Estadisticas")]
    private float velocidadDeMovimiento = 6;
    private float velocidadDeMovimientoReducida = 3;
    private float fuerzaDeSalto = 10;

    [Header("Booleanos")]
    private bool puedeMover = true;
    private bool grounded = false;

    public int contadorSalto = 0;

    [SerializeField] private GameObject AttackTriggerBox;
    private int playerDamage = 1;
    private int MaxSaltos = 1;

    [SerializeField] private Animator animator;
    [SerializeField] private RuntimeAnimatorController controller;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (animator == null )
            animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puedeMover) Movimiento();
        if (Input.GetKeyDown("space")) Saltar();
        if (Input.GetButtonDown("Fire1")) Atacar();
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 1.5f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Enemy"))
            {
                contadorSalto = 0;
                grounded = true;
                SetAnimation(GetComponent<Rigidbody2D>().velocity.x != 0 ? "run" : "idle");
            }else
            {
                SetAnimation("jump");
            }
        }
    }

    void SetAnimation(string name)
    {
        AnimatorControllerParameter[] parametros = GetComponent<Animator>().parameters;
        foreach (var item in parametros) GetComponent<Animator>().SetBool(item.name, false);
        GetComponent<Animator>().SetBool(name, true);
    }

    private void Atacar()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX("Attack");
        List<GameObject> Enemies = AttackTriggerBox.GetComponent<AttackTriggerBox>().GetEnemies();
        foreach(GameObject Enemy in Enemies)
        {
           if(Enemy) Enemy.GetComponent<EnemyStats>().TakeDamage(playerDamage);
        }
        SetAnimation("attack");
    }

    private void Movimiento()
    {
        float x = Input.GetAxis("Horizontal");

        direccion = new Vector2(x, 0);
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

    public void LevelUp()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX("LevelUp");
        puedeMover = false;
        StartCoroutine(LevelUpAnimation());
        MaxSaltos++;
    }

    private IEnumerator LevelUpAnimation() {
        animator.runtimeAnimatorController = controller;
        yield return new WaitForSeconds(0.5f);
        puedeMover = true;
        StopCoroutine(LevelUpAnimation());
    }

    public void PlayerDeath()
    {
        PlayerPrefs.SetInt("score", GameMode.Instance.getPlayerExperience());
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySFX("PlayerDeath");
        puedeMover = false;
        SceneManager.LoadScene("GameOver");
    }
}
