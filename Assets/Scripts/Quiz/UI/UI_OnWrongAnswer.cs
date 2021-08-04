using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Quiz.Animations;

namespace Quiz.Quiz
{
    public class UI_OnWrongAnswer : MonoBehaviour
    {
        [SerializeField] public float ClickCooldown { private get; set; }

        [Header("Info box")]
        [SerializeField] private bool isShaking = false;



        void Awake()
        {
            Button gameObjectButton = this.gameObject.transform.GetChild(1).GetComponent<Button>();
            gameObjectButton.onClick.AddListener(delegate { WrongAnswer(); });
        }

        private void WrongAnswer()
        {
            if (!isShaking)
            {
                StartCoroutine(UnavaliableForClick());
                UI_ItemAnimations animations = this.gameObject.GetComponent<UI_ItemAnimations>();
                animations.ShakeAnimation = new UI_ShakeItem_Animation();
                StartCoroutine(animations.ShakeAnimation.Shake(this.gameObject));
            }
        }

        private IEnumerator UnavaliableForClick()
        {
            isShaking = !isShaking;
            yield return new WaitForSeconds(ClickCooldown);
            isShaking = !isShaking;
        }
    }
}