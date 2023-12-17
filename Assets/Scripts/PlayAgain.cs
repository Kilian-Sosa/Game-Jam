using UnityEngine;

public class PlayAgain : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SCManager.instance.LoadScene("GameScene");
    }
}
