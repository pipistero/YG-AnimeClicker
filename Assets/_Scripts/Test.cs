using System.Collections;
using System.Collections.Generic;
using _Enums.Panels;
using _Scripts._Enums.Upgrades;
using _Scripts.Clicker;
using _Scripts.Shop.Item;
using _Scripts.Shop.Panel;
using _Scripts.Upgrades;
using PS.PanelsFeature.Controller;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    private ClickerData _clickerData;
    private UpgradesStorage _upgradesStorage;

    [Inject]
    public void Construct(ClickerData clickerData, UpgradesStorage upgradesStorage)
    {
        _clickerData = clickerData;
        _upgradesStorage = upgradesStorage;
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
