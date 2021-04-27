using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.IO;

public class ObjectScript:MonoBehaviour
{
    private CompositeDisposable disposables;
    private ClickColorData clickColorData;
    private int clickCounter = 0;

    void Start () {
        SubscribeToTimeChange();
        GetClicksData();
    }

    void SubscribeToTimeChange() 
    {
        GameData gameData = GameData.GetInstance();
        Observable
            .Timer (System.TimeSpan.FromSeconds (gameData.ObservableTime)) 
            .Repeat()
            .Subscribe (_ => ChangeColor())
            .AddTo (disposables); 
    }

    void GetClicksData()
    {
        GeometryObjectData geometryObjectData = GeometryObjectData.GetInstance();
        foreach(ClickColorData clicksData in geometryObjectData.ClicksData)
        {
            if (this.gameObject.name.Contains(clicksData.ObjectType))
            {
                clickColorData = clicksData;
            }
        }
    }
    public void ChangeColor() 
    { 
        Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f );
        this.gameObject.GetComponent<Renderer>().material.color = randomColor;
    }
    void SetColor(Color color) 
    { 
        this.gameObject.GetComponent<Renderer>().material.color = color;
    }

    bool IsBetween(int testValue, int min, int max)
    {
        return (testValue >= min && testValue <= max);
    }
    public void Clicked () 
    { 
        if (IsBetween(++clickCounter, clickColorData.MinClicksCount, clickColorData.MaxClicksCount)) 
        {
            SetColor(clickColorData.Color);
        }
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