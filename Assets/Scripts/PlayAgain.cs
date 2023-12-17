using System.Xml;
using TMPro;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SCManager.instance.LoadScene("GameScene");
    }


}
