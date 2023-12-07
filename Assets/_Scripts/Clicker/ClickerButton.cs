using System;
using System.Threading.Tasks;
using _Scripts.Clicker.UI;
using PS.ObjectPool.Controller;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Scripts.Clicker
{
    public class ClickerButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointerEventData> Clicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(eventData);
        }
    }
}