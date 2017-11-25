using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetButton : LevelObject {
    public List<Puppet> puppets;

    public DIRECTION direction;
    private Vector3 VectorDirection () {
        if (direction == DIRECTION.FORWARD) { return Vector3.forward; }
        else if (direction == DIRECTION.RIGHT) { return Vector3.right; }
        else if (direction == DIRECTION.BACK) { return Vector3.back; }
        else { return Vector3.left; }
    }

    public override ACTION PressedReaction(PlayerController player) {
        for (int i = 0; i < puppets.Count; i++) {           
            puppets[i].Move(VectorDirection());
        }
        return pressedReaction;
    }

    public override ACTION MoveReaction(PlayerController player) {
        return ACTION.MOVE;
    }

    /* PUPPETS CAN'T INTERACT WITH PUPPET CONTROLLERS (for now)
     * Could see that leading to some terrible, albeit interesting effects...
     */
    public override ACTION PressedReaction(Puppet puppet) {
        return ACTION.NOPE;
    }
    public override ACTION MoveReaction(Puppet puppet) {
        return ACTION.NOPE;
    }
}
