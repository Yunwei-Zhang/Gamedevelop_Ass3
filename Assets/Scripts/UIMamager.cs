using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMamager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ExitGame()
    {
        // UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("StartScene");
        Destroy(this.gameObject);
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level1"){
            Button exitbtn = GameObject.FindWithTag("ExitButton").GetComponent<Button>();
            exitbtn.onClick.AddListener(ExitGame);

            // healthbarImg = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Image>();
            // player = GameObject.FindWithTag("Player").transform;
        }
    }
}
