using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButton : MonoBehaviour {
    public void CambiarSprite(Sprite nuevoSprite)
    {
        // Aseg�rate de que el objeto tiene un componente Image
        Image imagenDelBoton = GetComponent<Image>();

        if (imagenDelBoton != null)
        {
            // Cambiar el sprite del bot�n
            imagenDelBoton.sprite = nuevoSprite;
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un componente Image.");
        }
    }
}
