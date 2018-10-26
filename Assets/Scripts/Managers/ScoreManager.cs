using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {


    // public Text coundownText;
    public Text zombieNumber;
    public Text coinText; 
    public GameObject Bar;
    public GameObject Skull;
    public GameObject Ammo;
    public GameObject roundNumber;

    public Canvas joysticCanvas;
    public Canvas canvas;
    public Transform SurvivorPos;

    public static int zombieCount = 0;
    public static int coinCoint = 0;
    public static int roundCount = 0;
    private bool disableCanvas;
    float health;

    bool decativate = false;

    void Start() {
        zombieCount = 0;
        roundCount = 0;
        roundNumber.GetComponent<Text>().text = "Round: " + roundCount;
        if (Respawn.tryAgain == true)
        {
            coinCoint = 0;
        } else {
            coinCoint = SaveAndLoad.control.coin;
        }
    }

    void Update() {
        health = Setups.survivor.getSurvivorHealth()/100;

        setHealthBar(health, Bar);
        setAmmoBar(Setups.survivor.getSurvivorWeapon().getAmmoPercentage(), Ammo);

        zombieNumber.text =  zombieCount.ToString();
        coinText.text =  coinCoint.ToString();

        if (GetZombieFromPool.endRound == true)
        {
            roundCount += 1;
            roundNumber.GetComponent<Text>().text = "Round: " + roundCount.ToString();
            AnimateRound();
            GetZombieFromPool.endRound = false;
        }
        if (health <= 0 && decativate == false) {
            joysticCanvas.GetComponent<Canvas>().enabled = false;
            Instantiate(Skull, SurvivorPos.transform.position, Quaternion.identity);
            roundNumber.SetActive(false);
            decativate = true;
        }
    }

    void setHealthBar(float value, GameObject Bar) { 
        if (value <= 0)
        {
            value = 0;
        }
        Bar.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, value);
        Bar.transform.localScale = new Vector3(value, Bar.transform.localScale.y, Bar.transform.localScale.z);
    }
    void setAmmoBar(float value, GameObject Bar)
    {
        if (value <= 0)
        {
            value = 0;
        }
        Bar.GetComponent<Image>().color = Color.Lerp(new Color(.35f,.4f,1f), new Color(.15f,.5f,1f), value);
        Bar.transform.localScale = new Vector3(value, Bar.transform.localScale.y, Bar.transform.localScale.z);
    }

    void AnimateRound() {
        canvas.GetComponent<Animator>().SetTrigger("Fade");
    }
    
}
