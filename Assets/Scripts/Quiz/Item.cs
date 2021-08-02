using UnityEngine;

namespace Quiz.Quiz
{

    [CreateAssetMenu(fileName = "New Item", menuName = "Quiz/New item")]
    public class Item : ScriptableObject
    {
        [SerializeField] public ushort ID;
        [SerializeField] private string description;
        [SerializeField] private Sprite image;


        public Sprite GetImage() => image;
    }
}
