using UnityEngine;
using System.Collections;

public class SetupsBackup : MonoBehaviour {

    public static SurvivorClass survivor;

    public GameObject survivorGameObject;

	// Use this for initialization
	void Start () {
        initializeObject();
	}

    void initializeObject() {
 //       survivor = new SurvivorClass("Mike", survivorGameObject, 100.0f, 1.0f);
    }

    public SurvivorClass getSurivivorClass() { return survivor; }


}
