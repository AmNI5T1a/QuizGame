using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Quiz
{
    [CreateAssetMenu(fileName = "New stack of items", menuName = "Quiz/New stack of items")]
    public class StackOfItems : ScriptableObject
    {
        [SerializeField] public List<Item> stack;
    }
}