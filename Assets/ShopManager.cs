using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour {
    
    public static ShopManager shop;

    public Text Coins;

    public GameObject weapon_Shop, character_Shop, mainShop, referenceShopClose;
    public GameObject shopConfirm;
    public GameObject Yes, No;
    public GameObject LoadingScene;
    public Slider loadBar;

    public List<Text> gunShopPrice;
    public List<Text> characterShopPrice;

    GameObject currentScene;

    private AsyncOperation async;
    private int[] gunShopPrice_int;
    private int[] characterShopPrice_int;
    private float startPosition;
    private bool closeShop = false;

    //  public Transform weaponShop_anim, characterShop_anim;

    void Start() {
        Coins.text = SaveAndLoad.control.coin.ToString();
        currentScene = mainShop;
        initialize();
    }

    void initialize() {

        gunShopPrice_int = new int[5] { 200, 300, 500, 550, 660 };
        characterShopPrice_int = new int[5] { 200, 300, 500, 550, 660 };

        for (int i = 0; i < gunShopPrice_int.Length; i++)
        {
            if (SaveAndLoad.control.guns_bought[i] == 0)
            {
                gunShopPrice[i].text = gunShopPrice_int[i].ToString();
            }
            else {
                gunShopPrice[i].text = gunShopPrice_int[i].ToString() + (SaveAndLoad.control.guns_bought[i] * 100).ToString();
            }
        }

        for (int i = 0; i < characterShopPrice_int.Length; i++)
        {
            if (SaveAndLoad.control.character_bought[i] == false)
            {
                characterShopPrice[i].text = characterShopPrice_int[i].ToString();
            }
            else {
                characterShopPrice[i].text = "Select";
            }
        }
    }

    void Update() {
        if (currentScene.GetComponent<RectTransform>().position.y >= 600 && closeShop == true)
        {
            currentScene.SetActive(false);
            currentScene.transform.position = new Vector3(currentScene.transform.position.x, 600);
            currentScene = mainShop;
            closeShop = false;
        }
    }

    public void WeaponsShop() {
        weapon_Shop.SetActive(true);
        currentScene = weapon_Shop;
        startPosition = weapon_Shop.transform.position.x;
        currentScene.GetComponent<Rigidbody2D>().gravityScale = 24;
    }

    public void CharacterShop() {
        character_Shop.SetActive(true);
        currentScene = character_Shop;
        currentScene.GetComponent<Rigidbody2D>().gravityScale = 24;
        startPosition = weapon_Shop.transform.position.x;
    }

    public void CloseShop() {
        currentScene.GetComponent<Rigidbody2D>().gravityScale = -24;
        closeShop = true;
        SaveAndLoad.control.Save();
    }


    public void Main_Menu()
    {
        try
        {
            SaveAndLoad.control.Save();
            LoadingScene.SetActive(true);
            StartCoroutine(loadAsync(0));
        }
        catch (Exception ex)
        {
        }
    }

    IEnumerator loadAsync(int level)
    {
        async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
            loadBar.value = async.progress;
            yield return null;
        }

    }
    public void selctionConfirm()
    {
        if (SaveAndLoad.control.character_bought[ScrollRectSnap.currentBttn] == false)
        {
            shopConfirm.SetActive(true);
        }
        else {
            if (character_Shop.activeSelf == true)
            {
                characterShopPrice[SaveAndLoad.control.selectedCharacter].text = "Select";
                SaveAndLoad.control.selectedCharacter = ScrollRectSnap.currentBttn;
                characterShopPrice[ScrollRectSnap.currentBttn].text = "Selected";
            }
        }
    }

    public void yesConfirm()
    {
        int i = ScrollRectSnap.currentBttn;
        shopConfirm.SetActive(false);
        if (weapon_Shop.activeSelf == true) {
            if (SaveAndLoad.control.coin >= gunShopPrice_int[i])
            {
                Coins.text = (SaveAndLoad.control.coin - gunShopPrice_int[i]).ToString();
                SaveAndLoad.control.guns_bought[i] += 1;
                gunShopPrice[i].text = (gunShopPrice_int[i] + (SaveAndLoad.control.guns_bought[i] * 100)).ToString();
            }
        }

        else if (character_Shop.activeSelf == true) {
            if (SaveAndLoad.control.coin >= characterShopPrice_int[i])
            {
                Debug.Log(characterShopPrice_int[i] + "and " + SaveAndLoad.control.coin);
                SaveAndLoad.control.coin = (SaveAndLoad.control.coin - characterShopPrice_int[i]);
                SaveAndLoad.control.character_bought[i] = true;

                Coins.text = (SaveAndLoad.control.coin).ToString();

                characterShopPrice[i].text = "Select";
            }
        }
    
    }
    public void noConfirm() {
        shopConfirm.SetActive(false);
    }


}
