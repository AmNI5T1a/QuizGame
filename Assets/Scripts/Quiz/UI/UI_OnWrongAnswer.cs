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
                StartCoroutine(this.gameObject.GetComponent<UI_ShakeItem_Animation>().Shake(this.gameObject));
                // TODO: Notification window "Wrong answer"
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