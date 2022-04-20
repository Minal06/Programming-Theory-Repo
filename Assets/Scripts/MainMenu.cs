using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [SerializeField] InputField player1Name;
    [SerializeField] InputField player2Name;
    [SerializeField] InputField timeSet;
        
    public void StartGame()
    {
        Debug.Log("Player 1 name is:" + player1Name.text);
        Debug.Log("Player 2 name is:" + player2Name.text);
        Debug.Log("Game will take:" + timeSet.text);
        GameManager.player1NameInGame = player1Name.text;
        GameManager.player2NameInGame = player2Name.text;
        GameManager.SetGameTime = timeSet.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
