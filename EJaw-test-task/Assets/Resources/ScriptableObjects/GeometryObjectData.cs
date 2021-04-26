using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class GeometryObjectData : ScriptableObject
{
    [SerializeField]
    public List<ClickColorData> ClicksData;
    void Start()
    {
        string jsonData;
        try
        {
            using (StreamReader dr = new StreamReader("Assets/Scripts/Data/ClickColorData.json"))
            {
                jsonData = dr.ReadToEnd();
                ClicksData = JsonUtility.FromJson<List<ClickColorData>>(jsonData);
                Debug.Log(ClicksData.Count);
            }
        } 
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }
}