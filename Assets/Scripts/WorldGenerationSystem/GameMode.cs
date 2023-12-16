using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public static GameMode Instance { get; private set; }

    [SerializeField] private List<GameObject> Level1Frames = new List<GameObject>();
    [SerializeField] private List<GameObject> Level2Frames = new List<GameObject>();
    [SerializeField] private List<GameObject> Level3Frames = new List<GameObject>();
    private List<List<GameObject>> LevelFrames = new List<List<GameObject>>();

    [SerializeField] private GameObject currentLevelFrame;

    private int playerLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LevelFrames.Add(Level1Frames);
        LevelFrames.Add(Level2Frames);
        LevelFrames.Add(Level3Frames);

        playerLevel = 0;
    }

    public void PlayerLevelUp()
    {
        playerLevel++;
        if (playerLevel > 2) playerLevel = 2;
    }

    public void GenerateNextLevelFrame()
    {
        Vector3 nextFrameAnchorPosition = currentLevelFrame.GetComponent<LevelFrame>().GetNextLevelAnchorPosition();
        currentLevelFrame = Instantiate(GetNextFrameClass(), nextFrameAnchorPosition, transform.rotation);
    }

    public int getPlayerLevel()
    {
        return playerLevel;
    }

    private GameObject GetNextFrameClass()
    {
        int randomIndex = Random.Range(0, LevelFrames[playerLevel].Count);
        return LevelFrames[playerLevel][randomIndex];
    }
}
