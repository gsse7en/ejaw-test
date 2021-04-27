using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    private DataResponse prefabNames;
    
    private DataResponse objectTypes;

    

    void Start()
    {
        string jsonData;
        using (StreamReader dataReader = new StreamReader("Assets/Scripts/Data/PrefabNames.json"))
        {
            jsonData = dataReader.ReadToEnd();
        }
        prefabNames = JsonUtility.FromJson<DataResponse>(jsonData);
    }

    void Update()
    {
        // change to unirx~!~
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Floor")
                {
                    GameObject pref = Instantiate(getRandPrefab(prefabNames.prefabs), hit.point, Quaternion.identity);
                    
                    pref.AddComponent<ObjectScript>();
                    pref.GetComponent<ObjectScript>().ChangeColor();
                }
                if (hit.transform.tag == "Element")
                {
                    hit.collider.GetComponent<ObjectScript>().Clicked();
                }
            }
        }
    }

    public GameObject getRandPrefab(List<string> prefabNames)
    {
        return Resources.Load("Prefabs/"+prefabNames[Random.Range(0, prefabNames.Count)], typeof(GameObject)) as GameObject;
    }
}
