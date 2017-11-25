using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameObject> objectsInScene;
    public Rigidbody cameraObject;

    private PlayerController player;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < objectsInScene.Count; i++) {
            Destroy(objectsInScene[i]);
        }

        player = (Instantiate(Resources.Load("Player")) as GameObject).GetComponent<PlayerController>();
        player.Game = this;
        player.CameraObject = cameraObject;
        player.CameraOffset = player.transform.position - cameraObject.transform.position;

        LoadLevel();
    }

    /* Load the next level
     */
    private void LoadLevel() {
        LevelController level = (Instantiate(Resources.Load("Level1")) as GameObject).GetComponent<LevelController>();
        level.Game = this;

        player.Level = level;        
    }


    public void WinLevel() {
        Debug.Log("You Win This Level!");
    }
}
