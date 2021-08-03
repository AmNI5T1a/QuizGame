using UnityEngine;
using UnityEngine.UI;

public class UI_OnWrongAnswer : MonoBehaviour
{
    void Awake()
    {
        Button gameObjectButton = this.gameObject.transform.GetChild(1).GetComponent<Button>();
        gameObjectButton.onClick.AddListener(delegate { WrongAnswer(); });
    }

    private void WrongAnswer()
    {
        Debug.Log("Clicked on wrong answer");
    }
}
