using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private InputController inputController = new InputController();

    private GameController gameController;
    public GameController Game {
        set { gameController = value; }
    }

    private Rigidbody cameraObject;
    public Rigidbody CameraObject {
        set { cameraObject = value; }
    }
    private Vector3 cameraOffset;
    public Vector3 CameraOffset {
        set { cameraOffset = value; }
    }

    private LevelController levelController;
    public LevelController Level {
        set { levelController = value; }
    }

    private bool canMove = true;
    private float rollDuration = 0.3f;

    /*
     * Called every frame
     */
    private void Update() {        
        Move();
        ControlCamera();
    }

    /*
     * For a given direction, roll the player.
     */
    private void Move() {
        if (canMove) {
            Vector3 direction = inputController.GetInput();

            // If trying to move...            
            if (direction != Vector3.zero) {
                
                ACTION moveReaction = levelController.MoveTo(transform.position + direction, this);
                if(moveReaction != ACTION.NOPE) {
                    StartCoroutine(Roll(transform.position, direction));
                }                
            }            
        }
    }

    /* Add forces to the camera in order
     * to move it around. Duh.
     */
    private void ControlCamera() {
        if(cameraOffset != null) {
            cameraObject.AddForce((transform.position - cameraOffset) - cameraObject.transform.position);
        }        
    }


    /*
     * Begin rolling, prevent any further movement until roll
     * is complete.
     */
    private IEnumerator Roll(Vector3 start, Vector3 direction) {
        canMove = false;

        float rollThrough = 90;
        Quaternion startRotation = transform.rotation;
        
        Vector3 rollPoint = 
            (transform.position - (new Vector3(0, transform.localScale.y / 2, 0))) 
            + (direction / 2);
        Vector3 rollAxis = RollAxis(direction);

        float completion = 0;
        while (completion < rollThrough) {
            float angle = Time.deltaTime * (rollThrough / rollDuration);
            transform.RotateAround(rollPoint, rollAxis, angle);
            completion += angle;
            yield return new WaitForEndOfFrame();
        }

        // Snap to correct position and angle
        GameObject temp = new GameObject("Temp");
        temp.transform.rotation = startRotation;
        temp.transform.RotateAround(rollPoint, rollAxis, rollThrough);
        transform.rotation = temp.transform.rotation;
        Destroy(temp);

        transform.position = start + direction;
        canMove = true;

        // Press upon landing
        levelController.Press(transform.position, this);
    }

    /*
     * For the given direction, return the correct roll axis.
     */ 
     private Vector3 RollAxis(Vector3 direction) {
        if (direction.normalized == Vector3.forward) {
            return Vector3.right;
        }
        else if (direction.normalized == Vector3.right) {
            return Vector3.back;
        }
        else if (direction.normalized == Vector3.back) {
            return Vector3.left;
        }
        else {
            return Vector3.forward;
        }
    }
}
