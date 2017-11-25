using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    
    public Vector3 StartPosition() {
        GameObject playerMarker = GetComponentsInChildren<PlayerController>()[0].gameObject;
        Vector3 startPosition = playerMarker.transform.localPosition;
        Destroy(playerMarker);
        return startPosition;
    }

    private LevelGrid levelGrid;
    public GameObject floor;

    private GameController gameController;
    public GameController Game {
        set { gameController = value; }
    }

    // Use this for initialization
    void Start () {        
        levelGrid = new LevelGrid(floor, GetChildren());     
        
	}

    /* Return a GameObject[] of all the child gameObjects
     */
    private GameObject[] GetChildren() {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < childTransforms.Length; i++) {
            if (childTransforms[i].gameObject.GetComponent<LevelObject>() != null) {
                children.Add(childTransforms[i].gameObject);
            }            
        }
        return children.ToArray();
    }

    /* Return true if given co-ords are free
     */
    public ACTION MoveTo(int x, int z, PlayerController player) {
        return levelGrid.MoveTo(x, z, player);
    }
    public ACTION MoveTo(Vector3 position, PlayerController player) {
        int x = (int)Mathf.Floor(position.x);
        int z = (int)Mathf.Floor(position.z);
        return MoveTo(x, z, player);
    }

    /* Press the object at the given position,
     * if it even exists.
     */
     public ACTION Press(Vector3 position, PlayerController player) {
        int x = (int)Mathf.Floor(position.x);
        int z = (int)Mathf.Floor(position.z);

        // If the press results in defeating the level, progress to next
        ACTION pressed = levelGrid.Press(x, z, player);
        if (pressed == ACTION.WIN) {
            gameController.LoadLevel();
        }

        return pressed; 
    }
}
