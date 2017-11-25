using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private LevelGrid levelGrid;

	// Use this for initialization
	void Start () {
        levelGrid = new LevelGrid(gameObject, GetChildren());
	}

    /* Return a GameObject[] of all the child gameObjects
     */
    private GameObject[] GetChildren() {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < childTransforms.Length; i++) {
            if (childTransforms[i].gameObject != gameObject) {
                children.Add(childTransforms[i].gameObject);
            }            
        }
        return children.ToArray();
    }

    /* Return true if given co-ords are free
     */
    public bool CanMoveTo(int x, int z) {
        return levelGrid.CanMoveTo(x, z);
    }
    public bool CanMoveTo(Vector3 position) {
        int x = (int)Mathf.Floor(position.x);
        int z = (int)Mathf.Floor(position.z);
        return CanMoveTo(x, z);
    }
}
