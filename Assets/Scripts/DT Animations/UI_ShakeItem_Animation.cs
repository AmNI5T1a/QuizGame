using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Quiz.Animations
{
    public class UI_ShakeItem_Animation
    {
        [Header("Stats: ")]
        [SerializeField, Range(0f, 1f)] private float shakeTime = 1f;
        [SerializeField, Range(0f, 100f)] private float shakeStrength = 10;
        [SerializeField, Range(100f, 1000f)] private float vibrato = 1000;
        private Sequence _sequence;

        public UI_ShakeItem_Animation() { }
        public UI_ShakeItem_Animation(float shakeTime)
        {
            this.shakeTime = shakeTime;
        }
        public UI_ShakeItem_Animation(float shakeTime, float shakeStrength)
        {
            this.shakeTime = shakeTime;
            this.shakeStrength = shakeStrength;
        }
        public UI_ShakeItem_Animation(float shakeTime, float shakeStrength, float vibrato)
        {
            this.shakeTime = shakeTime;
            this.shakeStrength = shakeStrength;
            this.vibrato = vibrato;
        }



        public IEnumerator Shake(GameObject objToShake)
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(objToShake.transform.DOShakeRotation(shakeTime, 10, vibrato: 1000));
            yield return new WaitForSeconds(shakeTime);

            _sequence.AppendCallback(() => { DT_SequenceHandler.KillSequence(ref _sequence); });
        }
    }
}