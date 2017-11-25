using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameObject> objectsInScene;
    public Rigidbody cameraObject;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < objectsInScene.Count; i++) {
            Destroy(objectsInScene[i]);
        }

        PlayerController player = (Instantiate(Resources.Load("Player")) as GameObject).GetComponent<PlayerController>();
        LevelController level = (Instantiate(Resources.Load("Level1")) as GameObject).GetComponent<LevelController>();

        player.SetLevel = level;
        player.SetCamera = cameraObject;
        player.SetOffset = player.transform.position - cameraObject.transform.position;
    }
}
