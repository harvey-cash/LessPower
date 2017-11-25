using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour {

    public ACTION moveReaction;

    public ACTION MoveReaction(PlayerController player) {
        return moveReaction;
    }
	
}
