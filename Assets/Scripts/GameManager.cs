using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string SetGameTime;
    public static string player1NameInGame;
    public static string player2NameInGame;
    public int gameTime
    {
        get { return m_gameTime; }
        set
        {
            if (1 <= value && value <= 9) { m_gameTime = value; }
            else { Debug.LogError("Use nrs between 1-9!"); }
        }
    }
    private int m_gameTime = int.Parse(SetGameTime);
}
