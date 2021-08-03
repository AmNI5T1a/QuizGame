using System.Collections;
using UnityEngine;
using DG.Tweening;
using Quiz.Modules;

namespace Quiz.Animations
{
    // TODO: revert logic -> Add 2 new interfaces IShakeAnimation, IAppearAnimation and realize it
    public class UI_ShakeItem_Animation : Singleton<UI_ShakeItem_Animation>
    {
        [Header("Stats: ")]
        [SerializeField, Range(0f, 1f)] private float shakeTime = 1f;
        [SerializeField, Range(0f, 100f)] private float shakeStrength = 10;
        [SerializeField, Range(100f, 1000f)] private float vibrato = 1000;
        private Sequence _sequence;

        public IEnumerator Shake(GameObject objToShake)
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(objToShake.transform.DOShakeRotation(shakeTime, 10, vibrato: 1000));
            yield return new WaitForSeconds(shakeTime);

            _sequence.AppendCallback(() => { KillSequence(ref _sequence); });
        }

        public static void KillSequence(ref Sequence sequence)
        {
            sequence.Kill();
        }
    }
}