using UnityEngine;
using System.Collections;

public class SurvivorClassBackUp 
{
    private string s_name;
    private GameObject s_gameObject;
    private Transform s_transform;
    private float s_health;
    private float s_velocity;

    public SurvivorClassBackUp(string name, GameObject gameObject, float health, float velocity) {
        s_name = name;
        s_gameObject = gameObject;
        s_transform = gameObject.transform;
        s_health = health;
        s_velocity = velocity;
    }

    public void setSurvivorHealth(float health) { s_health = health; }
    public void setSurvivorVelocity(float velocity) { s_velocity = velocity; }

    public string getSurvivorName() { return s_name; }
    public float getSurvivorHealth() { return s_health; }
    public float getSurvivorVelocity() { return s_velocity; }


    public void onZombieCollisionPushback(ZombieClass zombieThatCollided) {
        s_health -= zombieThatCollided.getZombieAttackPoints();
        Debug.Log("A Zombie Touched You. Health = " + s_health);
        if (s_health <= 0) {
            youAreDead();
            Debug.Log("You are Dead ");
        }
        
    }

    public void youAreDead() {
            
    }

    // Use this for initialization
}
