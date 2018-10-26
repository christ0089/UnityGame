using UnityEngine;
using System.Collections;

public class CollissionCoin : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Survivor") {
            Destroy(gameObject);
            ScoreManager.coinCoint += 1;
        }
    }
}
