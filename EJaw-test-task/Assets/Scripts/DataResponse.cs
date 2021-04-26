using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataResponse
{
    public string[] prefabs;
    public string[] materials;
    public GameObject getRandPrefab()
    {
        return Resources.Load("Prefabs/"+prefabs[Random.Range(0, prefabs.Length)], typeof(GameObject)) as GameObject;
    }
    public Material getRandMaterial()
    {
        return Resources.Load("Materials/"+materials[Random.Range(0, materials.Length)], typeof(Material)) as Material;
    }
}