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
        DataStorage.Instance.objectTypes = objectTypes;
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
                    GameObject pref = Instantiate(objectTypes.getRandPrefab(), hit.point, Quaternion.identity);
                    pref.GetComponent<Renderer>().material = objectTypes.getRandMaterial();
                    pref.AddComponent<ObjectScript>();
                }
                if (hit.transform.tag == "Element")
                {
                    hit.collider.GetComponent<ObjectScript>().Clicked();
                }
            }
        }
    }
}
