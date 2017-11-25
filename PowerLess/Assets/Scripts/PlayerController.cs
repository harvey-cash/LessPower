using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private InputController inputController = new InputController();

    private bool canMove = true;
    private float rollSpeed = 250;

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
        Quaternion startRotation = transform.rotation;
        
        Vector3 rollPoint = 
            (transform.position - (new Vector3(0, transform.localScale.y / 2, 0))) 
            + (direction / 2);
        Vector3 rollAxis = RollAxis(direction);

        float completion = 0;
        while (completion < 90) {
            float angle = Time.deltaTime * rollSpeed;
            transform.RotateAround(rollPoint, rollAxis, angle);
            completion += angle;
            yield return new WaitForEndOfFrame();
        }

        // Reset to uniform alignment. No actual roll happened, guys!        
        transform.rotation = startRotation;
        transform.RotateAround(rollPoint, rollAxis, 90);
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
