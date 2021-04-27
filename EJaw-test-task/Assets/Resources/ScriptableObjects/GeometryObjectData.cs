using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "Geometry Object Data", order = 25)]
public class GeometryObjectData : ScriptableObject
{
    [SerializeField]
    public List<ClickColorData> clicksData;
}