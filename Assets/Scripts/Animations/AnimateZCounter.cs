using UnityEngine;
using System.Collections;

public class AnimateZCounter : MonoBehaviour {
    int tempZombCount;
    Animator anim;
    // Use this for initialization
    void Start () {
        tempZombCount = ScoreManager.zombieCount;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (tempZombCount < ScoreManager.zombieCount)
        {
            anim.SetTrigger("ZombieKilled");
            tempZombCount = ScoreManager.zombieCount;
        }
    }
}
