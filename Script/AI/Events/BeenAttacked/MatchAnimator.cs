using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu (menuName = "AI/DecideEvents/BeenAttacked/MatchAnimator")]
    public class MatchAnimator : DecideEvents
    {
        
        [SerializeField]
        private string[] matchAnimatorName;
        private Animator animator;
        private AnimatorStateInfo animStateInfomation;
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            animator = _Brain.GetComponent<Animator>();
            animStateInfomation = animator.GetCurrentAnimatorStateInfo(0);
            for (int i = 0; i < matchAnimatorName.Length; i++)
            {
                if (animStateInfomation.IsName(matchAnimatorName[i]))
                {
                    return true;

                }
            }
            
            return false;
        }

    }


}
