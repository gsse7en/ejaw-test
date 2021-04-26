using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.IO;

public class ObjectScript:MonoBehaviour
{
    public CompositeDisposable disposables;
    private DataResponse objectTypes;
    private int clickCounter = 0;

    void Start () {
        objectTypes = DataStorage.Instance.objectTypes;
        Observable
            .Timer (System.TimeSpan.FromSeconds (5)) 
            .Repeat()
            .Subscribe (_ => ChangeColor()).AddTo (disposables); 
    }

    public void Clicked () 
    { 
        if (++clickCounter == 5) {
            clickCounter = 0;
            this.gameObject.GetComponent<Renderer>().material = objectTypes.getRandMaterial();
        }
    }
    void ChangeColor() 
    {
this.gameObject.GetComponent<Renderer>().material = objectTypes.getRandMaterial();
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