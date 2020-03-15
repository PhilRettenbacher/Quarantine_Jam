using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void Back_Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Time.timeScale = 1;
    }
    public void Back_Game(Canvas HUD)
    {
        HUD.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
