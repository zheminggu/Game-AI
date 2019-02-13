using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu (menuName = "AI/DecideEvents/EnemyGoAway")]
    public class EnemyGoAway : DecideEvents
    {
        [Tooltip ("遇到时不能移动的动画")]
        [SerializeField]
        private string[] matchAnimatorName;
        [SerializeField]
        private float farAwayDistance = 5f;
        private Animator animator;
        private AnimatorStateInfo animStateInfomation;
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            animator = _Brain.GetComponent<Animator>();
            animStateInfomation = animator.GetCurrentAnimatorStateInfo(0);
            if ((_Brain.m_SensorManager.M_GetCurrentEnemyTarget().transform.position - _Brain.m_CurrentTransform.position).sqrMagnitude > farAwayDistance * farAwayDistance)
            {
                bool _flagOfMove=true;
                for (int i = 0; i < matchAnimatorName.Length; i++)
                {
                    if ((animStateInfomation.IsName(matchAnimatorName[i])))
                    {
                      _flagOfMove=false;
                        break;
                    }
                }
                if (_flagOfMove)
                {
                    return true;
                }     
            }
            return false;
        }

    }

}
