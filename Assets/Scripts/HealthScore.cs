using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScore : MonoBehaviour {

    public Text scoreText;
    public Text coundownText;
    public Text ZombieNumber;
    private SurvivorClass survivor;

    public float Countdown = 900.0f;
    public int zombieCount;
    public float health;

    void Start() {
    }

    void Update() {
        health = Setups.survivor.getSurvivorHealth();
        scoreText.text = health.ToString();

        zombieCount = GameObject.FindGameObjectsWithTag("Zombie").Length;

        ZombieNumber.text = zombieCount.ToString();

        Countdown -= Time.deltaTime * 10;
        coundownText.text = Countdown.ToString();

        if (Countdown <= 000 || health <= 0) {
            coundownText.text = "000";
            scoreText.text = "000";
      }
    }
}
