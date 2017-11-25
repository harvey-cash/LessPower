using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelObject : MonoBehaviour {

    [SerializeField]
    protected ACTION moveReaction;

    public abstract ACTION MoveReaction(PlayerController player);
	
}
