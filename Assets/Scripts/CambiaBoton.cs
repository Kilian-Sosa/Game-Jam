using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaBoton : MonoBehaviour
{

    public Sprite spriteNormal;
    public Sprite spriteHover;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        // Cambiar el sprite cuando el ratón pasa por encima
        if (spriteHover != null)
        {
            spriteRenderer.sprite = spriteHover;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
