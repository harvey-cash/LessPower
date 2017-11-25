using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : LevelObject {

    public override ACTION MoveReaction(PlayerController player) {
        return moveReaction;
    }
}