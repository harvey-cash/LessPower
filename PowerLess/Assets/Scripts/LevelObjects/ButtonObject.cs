using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : LevelObject {

    public override ACTION PressedReaction(PlayerController player) {
        Debug.Log("Pressed!");
        return pressedReaction;
    }

    public override ACTION MoveReaction(PlayerController player) {
        return ACTION.MOVE;
    }
}