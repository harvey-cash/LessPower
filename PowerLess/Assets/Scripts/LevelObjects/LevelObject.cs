using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelObject : MonoBehaviour {

    [SerializeField]
    protected ACTION pressedReaction;

    public abstract ACTION PressedReaction(PlayerController player);
    public abstract ACTION MoveReaction(PlayerController player);

}
