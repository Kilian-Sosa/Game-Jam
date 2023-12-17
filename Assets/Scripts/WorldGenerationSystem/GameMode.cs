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
    [SerializeField] private GameObject previousLevelFrame;
    [SerializeField] private GameObject BackCollisionBox;

    [SerializeField] private GameObject Player;
    private int playerLevel;
    private int experience;

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
        experience = 0;
    }

    public void PlayerLevelUp()
    {
        playerLevel++;
        if (playerLevel > 2) playerLevel = 2;
        Player.GetComponent<PlayerController>().LevelUp();
    }

    public void PlayerDeath()
    {
        Player.GetComponent<PlayerController>().PlayerDeath();
    }

    public void GenerateNextLevelFrame()
    {
        if (previousLevelFrame != null) Destroy(previousLevelFrame.gameObject);
        BackCollisionBox.transform.position = currentLevelFrame.transform.position;
        Vector3 nextFrameAnchorPosition = currentLevelFrame.GetComponent<LevelFrame>().GetNextLevelAnchorPosition();
        previousLevelFrame = currentLevelFrame;
        currentLevelFrame = Instantiate(GetNextFrameClass(), nextFrameAnchorPosition, transform.rotation);
        AddExperience(10);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        int experienceNeeded = (playerLevel + 1 * 90);
        if (experience > experienceNeeded && playerLevel < 1)
        {
            PlayerLevelUp();
        }
    }


    public int getPlayerLevel()
    {
        return playerLevel;
    }

    public int getPlayerExperience()
    {
        return experience;
    }

    private GameObject GetNextFrameClass()
    {
        int randomIndex = Random.Range(0, LevelFrames[playerLevel].Count);
        //return LevelFrames[playerLevel][randomIndex];
        return LevelFrames[0][randomIndex];
    }
}
