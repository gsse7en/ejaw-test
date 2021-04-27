using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 25)]
public class GameData : ScriptableObject
{
    [SerializeField]
    private int observableTime;
    private static GameData s_Instance = null;

    public int ObservableTime
    {
        get
        {
            return observableTime;
        }
    }
 
    public static GameData GetInstance()
    {
        if (!s_Instance)
        {
            GameData[] all = Resources.FindObjectsOfTypeAll<GameData>();
            s_Instance = (all.Length > 0) ? all[0] : null;
        }
 
        if (!s_Instance)
        {
            s_Instance = CreateInstance<GameData>();
            s_Instance.name = "GameData";
        }
 
        return s_Instance;
    }
}