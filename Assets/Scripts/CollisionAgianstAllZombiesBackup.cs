using UnityEngine;
using System.Collections;

public class CollisionAgianstAllZombiesBackup : MonoBehaviour
{
    private ZombieMechanism zombieMechanismScript;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            Debug.Log("Collission");
            zombieMechanismScript = col.gameObject.GetComponent<ZombieMechanism>();
//            zombieMechanismScript.thisZombieIsInSafeZone();
           
        }
    }
}

