using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelObject : MonoBehaviour {

    [SerializeField]
    protected ACTION pressedReaction;

    protected LevelController levelController;
    public void SetLevelController(LevelController controller) { levelController = controller; }

    public abstract ACTION PressedReaction(PlayerController player);
    public abstract ACTION MoveReaction(PlayerController player);

    public abstract ACTION PressedReaction(Puppet puppet);
    public abstract ACTION MoveReaction(Puppet puppet);

}
