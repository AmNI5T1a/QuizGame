using UnityEngine;

namespace Quiz.Quiz
{

    [CreateAssetMenu(fileName = "New Item", menuName = "Quiz/New item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private ushort ID;
        [SerializeField] private string description;
        [SerializeField] private Sprite image;



        public ushort GetID() => ID;
        public Sprite GetImage() => image;
        public string GetDescription() => description;
    }
}
