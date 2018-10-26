using UnityEngine;
using System.Collections;

public class ZombieMechanismBackup : MonoBehaviour {

    private ZombieClass thisZombieClass;
    public Transform survivorTransform;

    // Use this for initialization
    void Start() {
        thisZombieClass = new ZombieClass(this.gameObject, 1f, 55f, .5f);
    }

	// Update is called once per frame
	void FixedUpdate () {
        thisZombieClass.moveAndLookAtSurvivor(survivorTransform);
	}
    public ZombieClass getZombieClass() { return thisZombieClass; }


    public void thisZombieIsInSafeZone()
    {
        thisZombieClass.getDestroyed();
    }


}
