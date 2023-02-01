using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManager : MonoBehaviour
{
    public GameObject Settings;
    public GameObject close;
    public GameObject BackToMenu;
    public GameObject Player;
    public GameObject Play;
    public Texture2D Cursor1;
    public Texture2D Cursor2;
    public bool inLevel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inLevel)
            {
                Settings.SetActive(true);
                close.SetActive(true);
                BackToMenu.SetActive(true);
                Play.SetActive(true);
                Pause();
            }
        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void InScene()
    {
        inLevel = true;
    }
    public void inMenu()
    {
        inLevel = false;
    }
    public void Pause()
    {
        if (inLevel)
        {
            Player.GetComponent<Movement>().on = false;
        }
    }
    public void Go()
    {
        if (inLevel)
        {
            Player.GetComponent<Movement>().on = true;
        }
    }
    public void CursorFirst()
    {
        Cursor.SetCursor(Cursor1, new Vector2(156, 156),CursorMode.Auto);
    }   
    public void CursorSecound()
    {
        Cursor.SetCursor(Cursor2, new Vector2(0,0),CursorMode.Auto);
    }
}