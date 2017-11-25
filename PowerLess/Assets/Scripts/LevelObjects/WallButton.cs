using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : LevelObject {
    public List<WallObject> walls;

    public override ACTION PressedReaction(PlayerController player) {
        for (int i = 0; i < walls.Count; i++) {
            walls[i].ToggleLowered();
        }
        return pressedReaction;
    }

    public override ACTION MoveReaction(PlayerController player) {
        return ACTION.MOVE;
    }


    /* Puppets can control walls!
     */
    public override ACTION PressedReaction(Puppet puppet) {
        for (int i = 0; i < walls.Count; i++) {
            walls[i].ToggleLowered();
        }
        return pressedReaction;
    }

    public override ACTION MoveReaction(Puppet puppet) {
        return ACTION.MOVE;
    }
}
