using DG.Tweening;

namespace Quiz.Animations
{
    public static class DT_SequenceHandler
    {
        public static void KillSequence(ref Sequence sequenceToKill)
        {
            sequenceToKill.Kill();
        }
    }
}