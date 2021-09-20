using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class Menu : MonoBehaviour
{
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitMenu()
    {
        Menu_Game.Load();
    }

    public void NewGame()
    {
        Game.Load();
    }
}
