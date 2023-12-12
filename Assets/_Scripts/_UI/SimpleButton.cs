using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.UI;

namespace _Scripts._UI
{
    public class SimpleButton : Button
    {
        protected override void Awake()
        {
            base.Awake();
            
            AddAnimation();
        }

        public void AddListener(UnityAction call)
        {
            onClick.AddListener(call);
        }

        public void RemoveListener(UnityAction call)
        {
            onClick.RemoveListener(call);
        }

        public void RemoveAllListeners()
        {
            onClick.RemoveAllListeners();

            AddAnimation();
        }

        private void AddAnimation()
        {
            AddListener(() =>
            {
                PlayAnimation();
            });
        }

        private async Task PlayAnimation()
        {
            var stepDuration = 0.1f;

            transform.DOScale(0.92f, stepDuration).SetEase(Ease.Linear);

            await Task.Delay(TimeSpan.FromSeconds(stepDuration));

            transform.DOScale(1f, stepDuration).SetEase(Ease.Linear);
        }
    }
}