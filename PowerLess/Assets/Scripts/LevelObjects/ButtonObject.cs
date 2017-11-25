using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : LevelObject {

    public override ACTION MoveReaction(PlayerController player) {
        Debug.Log("Pressed!");
        return moveReaction;
    }
}