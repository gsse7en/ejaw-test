using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.IO;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    private CompositeDisposable disposables;
    private DataResponse prefabNames;

    void Start()
    {
        GetPrefabNames();
        SubscribeToClick();
    }
    void GetPrefabNames()
    {
        string jsonData;
        using (StreamReader dataReader = new StreamReader("Assets/Scripts/Data/PrefabNames.json"))
        {
            jsonData = dataReader.ReadToEnd();
        }
        prefabNames = JsonUtility.FromJson<DataResponse>(jsonData);
    }
    void SubscribeToClick()
    {
        Observable
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => CheckHit())
            .AddTo (disposables);
    }
    void CheckHit()
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
    GameObject getRandPrefab(List<string> prefabNames)
    {
        return Resources.Load("Prefabs/"+prefabNames[Random.Range(0, prefabNames.Count)], typeof(GameObject)) as GameObject;
    }
    void OnEnable () { 
        disposables = new CompositeDisposable();
    }

    void OnDisable () { 
        if (disposables != null) {
            disposables.Dispose ();
        }
    }
}
