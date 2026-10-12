using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Start()
    {
        DontDestroyOnLoad(GameObject.Find("HUD"));
        DontDestroyOnLoad(GameObject.Find("Menu"));
    }

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += loadState;
        DontDestroyOnLoad(gameObject);

    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public player player;
    // public player weapon
    public FloatingTextManager floatingTextManager;

    // Logic
    public int gold;
    public int experience;

    // Floating text
    public void ShowText(string msg, int fontSize, Color colour, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, colour, position, motion, duration);
    }

    // save state
    /*
     * INT preferredSkin
     * INT gold
     * INT experience
     * INT weaponLevel
     */

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void loadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // change player skin
        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // change weapon level

        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
