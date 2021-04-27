using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "Geometry Object Data", order = 25)]
public class GeometryObjectData : ScriptableObject
{
    [SerializeField]
    private List<ClickColorData> clicksData;
    private static GeometryObjectData s_Instance = null;
    public List<ClickColorData> ClicksData
    {
        get
        {
            return clicksData;
        }
    }
    public static GeometryObjectData GetInstance()
    {
        if (!s_Instance)
        {
            GeometryObjectData[] all = Resources.FindObjectsOfTypeAll<GeometryObjectData>();
            s_Instance = (all.Length > 0) ? all[0] : null;
        }
 
        if (!s_Instance)
        {
            s_Instance = CreateInstance<GeometryObjectData>();
            s_Instance.name = "GeometryObjectData";
        }
 
        return s_Instance;
    }
}