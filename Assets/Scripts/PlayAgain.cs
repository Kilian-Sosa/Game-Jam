using UnityEngine;

public class PlayAgain : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SCManager.instance.LoadScene("GameScene");
    }
}
