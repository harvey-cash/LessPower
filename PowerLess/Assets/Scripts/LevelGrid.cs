using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Level Grid is responsible for holding a representation
 * of the objects in the current level
 */
public class LevelGrid {
    
    private GameObject[,] grid;

    /* Construct a new LevelGrid, and populate with the objects in the level
     */
    public LevelGrid(GameObject floor, GameObject[] objects) {
        int x = Mathf.RoundToInt(floor.transform.localScale.x);
        int z = Mathf.RoundToInt(floor.transform.localScale.z);
        grid = new GameObject[x, z];
            
        PopulateGrid(objects);
    }


    /* Populate the grid with the given list of objects
     */
    public void PopulateGrid(GameObject[] objects) {
        for (int i = 0; i < objects.Length; i++) {
            int indexX = (int)Mathf.Floor(objects[i].transform.position.x);
            int indexZ = (int)Mathf.Floor(objects[i].transform.position.z);
            grid[indexX, indexZ] = objects[i];
        }
    }


    /* Return true if given co-ords are free
     */
    public bool CanMoveTo(int x, int z) {
        bool withinX = (x >= 0 && x < grid.GetLength(0));
        bool withinZ = (z >= 0 && z < grid.GetLength(1));

        if (withinX && withinZ && grid[x, z] == null) {
            return true;
        } else {
            return false;
        }
    }


    /* Add the given GameObject to the grid, provided the grid
     * space is free.
     */
    public bool AddObjectToGrid(GameObject objectToAdd) {
        int indexX = (int)Mathf.Floor(objectToAdd.transform.position.x);
        int indexZ = (int)Mathf.Floor(objectToAdd.transform.position.z);

        if (grid[indexX, indexZ] != null) {
            // That grid space is already populated
            return false;
        } else {
            grid[indexX, indexZ] = objectToAdd;
            return true;
        }
    }
	
}
