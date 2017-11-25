using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private InputController inputController = new InputController();

    private bool canMove = true;
    private float rollDuration = 0.3f;


    /*
     * Called every frame
     */
    private void Update() {        
        Move();
    }

    /*
     * For a given direction, roll the player.
     */
    private void Move() {
        if (canMove) {
            Vector3 direction = inputController.GetInput();

            if (direction != Vector3.zero) {
                StartCoroutine(Roll(transform.position, direction));
            }            
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
