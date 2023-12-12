using UnityEngine;

namespace _Scripts.Shop.Panel
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private GameObject _arrow;

        private readonly Vector3 _closedState = new Vector3(-1f, 1f, 1f);
        private readonly Vector3 _openedState = new Vector3(1f, 1f, 1f);
        
        public void SetState(bool state)
        {
            _arrow.transform.localScale = state ? _openedState : _closedState;
        }
    }
}