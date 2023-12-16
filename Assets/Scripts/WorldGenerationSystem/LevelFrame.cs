using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFrame : MonoBehaviour
{
    [SerializeField] private GameObject NextLevelFrameAnchor;

    public Vector3 GetNextLevelAnchorPosition() {
        return NextLevelFrameAnchor.transform.position;
    }

    
}
