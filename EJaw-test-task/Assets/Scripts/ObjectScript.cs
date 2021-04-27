using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.IO;

public class ObjectScript:MonoBehaviour
{
    public CompositeDisposable disposables;
    private int clickCounter = 0;

    void Start () {
        GameData gameData = GameData.GetInstance();
        Debug.Log(gameData.observableTime);
        var sub = Observable
            .Timer (System.TimeSpan.FromSeconds (5)) 
            .Repeat()
            .Subscribe (_ => ChangeColor()).AddTo (disposables); 
    }

// change set color logic
    public void ChangeColor () 
    { 
        Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f );
        this.gameObject.GetComponent<Renderer>().material.color = randomColor;
    }

    public void Clicked () 
    { 
        if (++clickCounter == 5) {
            clickCounter = 0;
            ChangeColor ();
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