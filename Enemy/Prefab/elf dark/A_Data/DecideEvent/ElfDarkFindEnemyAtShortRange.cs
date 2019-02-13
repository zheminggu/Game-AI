using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
namespace Adamgu.Enemy
{
    [CreateAssetMenu (menuName = "AI/Enemy/ElfDark/DecideEvents/FindEnemyAtShortRange")]
    public class ElfDarkFindEnemyAtShortRange : DecideEvents
    {
       
        [SerializeField]
        [Tooltip("遇到时不能移动的动画")]
        private string[] matchAnimatorName;

        [SerializeField]
        [Tooltip("定义的近程距离")]
        private float shortRangeDistance;

        private Animator animator;
        private AnimatorStateInfo animStateInfomation;
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            animator = _Brain.GetComponent<Animator>();
            animStateInfomation = animator.GetCurrentAnimatorStateInfo(0);

            

            if (_Brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                float DistanceBetweenAIAndEnemy = (_Brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position - _Brain.m_CurrentTransform.position).sqrMagnitude;
                if (DistanceBetweenAIAndEnemy <= shortRangeDistance * shortRangeDistance)
                {
                    for (int i = 0; i < matchAnimatorName.Length; i++)
                    {
                        if ((animStateInfomation.IsName(matchAnimatorName[i])))
                        {
                           // Debug.Log("Stop because of" + matchAnimatorName[i]);
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;

        }
    }

}