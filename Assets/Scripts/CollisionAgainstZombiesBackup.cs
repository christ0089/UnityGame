using UnityEngine;
using System.Collections;

public class CollisionAgainstZombiesBackup : MonoBehaviour
{
    private ZombieMechanism zombieMechanismScript;
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            Debug.Log("Collission");
            zombieMechanismScript = col.gameObject.GetComponent<ZombieMechanism>();
            //Setups.survivor.onZombieCollisionPushback(zombieMechanismScript.getZombieClass());
        }
    }

    // Use this for initialization
}
