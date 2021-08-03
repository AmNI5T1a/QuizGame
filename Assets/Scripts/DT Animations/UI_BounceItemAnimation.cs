using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Quiz.Animations
{
    public class UI_BounceItemAnimation
    {
        [Header("Stats: ")]
        [SerializeField] private float appearTime = 0.5f;
        [SerializeField] private float leapTime = 0.25f;
        private Sequence _sequence;

        public UI_BounceItemAnimation() { }
        public UI_BounceItemAnimation(float appearTime)
        {
            this.appearTime = appearTime;
        }
        public UI_BounceItemAnimation(float appearTime, float leapTime)
        {
            this.appearTime = appearTime;
            this.leapTime = leapTime;
        }


        public IEnumerator Bounce(GameObject obj)
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(obj.transform.DOScale(0f, 0f));
            obj.SetActive(true);
            _sequence.Append(obj.transform.DOScale(1.2f, appearTime));
            yield return new WaitForSeconds(appearTime);
            _sequence.Append(obj.transform.DOScale(1f, leapTime));
            yield return new WaitForSeconds(leapTime);

            _sequence.AppendCallback(() => { DT_SequenceHandler.KillSequence(ref _sequence); });
        }
    }
}
