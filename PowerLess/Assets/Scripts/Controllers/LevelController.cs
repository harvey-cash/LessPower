using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private LevelGrid levelGrid;
    public GameObject floor;

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
}
