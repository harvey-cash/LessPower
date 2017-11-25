using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private const int LEVEL_COUNT = 3;
    private int currentLevel = 0;

    public List<GameObject> objectsInScene;
    public Rigidbody cameraObject;

    private PlayerController player;
    LevelController level;

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
    public void LoadLevel() {
        currentLevel++;
        if (currentLevel < LEVEL_COUNT) {
            string levelName = "Level" + currentLevel;
            Debug.Log("Loading " + levelName);

            if (level != null) { Destroy(level); }
            level = (Instantiate(Resources.Load(levelName)) as GameObject).GetComponent<LevelController>();
            RenderSettings.skybox = Instantiate(Resources.Load("Materials/Backgrounds/" + levelName)) as Material;
            DynamicGI.UpdateEnvironment();
            level.Game = this;

            player.transform.position = level.startPosition(currentLevel);
            player.Level = level;
        }
        else {
            Debug.Log("Win!");
        }
             
    }
}
