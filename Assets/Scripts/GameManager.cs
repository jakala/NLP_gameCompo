using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [HideInInspector]
    public GameObject player;
    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] list = GameObject.FindGameObjectsWithTag("gui");
        foreach (GameObject panel in list) {
            panels.Add(panel.name, panel);
        }

    }

    public void Start()
    {
        EnableMenu("Menu");
    }

    public void Update()
    {
        if (Input.GetKey("escape"))
            ExitGame();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void EnableMenu(string menu)
    {
        print("GUI items: " + panels.Count);
        foreach (string key in panels.Keys) {
            print("key: " + key);
            panels[key].SetActive(key == menu);
        }
        print("enable menu: " + menu);
    }

    public void LoadScene(string scene) {
        try
        {
            SceneManager.LoadScene(scene);
        }
        catch (System.Exception e) {
            print("cant load scene with name: " + scene);
            print(e.Message);
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}