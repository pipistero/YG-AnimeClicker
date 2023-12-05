using System.Collections;
using System.Collections.Generic;
using _Enums.Panels;
using _Scripts.Clicker;
using PS.PanelsFeature.Controller;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private ClickerData _clickerData;

    [Inject]
    public void Construct(ClickerData clickerData)
    {
        _clickerData = clickerData;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _clickerData.SetLevel(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _clickerData.SetLevel(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _clickerData.SetLevel(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            _clickerData.SetLevel(4);

    }
}
