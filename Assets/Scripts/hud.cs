using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hud : MonoBehaviour
{
    //LAS CREAMOS PUBLICAS Y ESTATICAS PARA USARLOS EN OTROS SCRIPTS
    public static int score = 0;
    public static int municion = 5;

    // Start is called before the first frame update
    void Start()
    {
        //score = GameMode.Instance.getPlayerExperience();
    }

    // Update is called once per frame
    void Update()
    {
        //RECUERDA QUE HEMOS LLAMADO LOS OBJETOS Score Y Balas EN LA VISTA
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "Score: " + GameMode.Instance.getPlayerExperience(); ;

        //PARA EVITAR EL ERROR EN LA ESCENA DE "LOSE"
        if (GameObject.Find("Puntos") != null)
        {
            //GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + municion;
            Debug.Log("PUNTOS");
        }
    }
}
