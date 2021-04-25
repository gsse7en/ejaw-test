using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    private DataResponse objectTypes;

    void Start()
    {
        string jsonData;
        using (StreamReader dr = new StreamReader("Assets/Scripts/Data/dataParts.json"))
        {
            jsonData = dr.ReadToEnd();
        }
        objectTypes = JsonUtility.FromJson<DataResponse>(jsonData);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Floor")
                {
                    GameObject pref = Instantiate(Resources.Load("Prefabs/"+objectTypes.prefabs[Random.Range(0, objectTypes.prefabs.Length)], typeof(GameObject)) as GameObject, hit.point, Quaternion.identity);
                    pref.GetComponent<Renderer>().material = Resources.Load("Materials/"+objectTypes.materials[Random.Range(0, objectTypes.materials.Length)], typeof(Material)) as Material;
                }
            }
        }
    }
}
