using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "AI/LearnedBehavior/Stop")]

    public class Stop : LearnedBehavior
    {
        Vector3 lookAtTarget=new Vector3();
        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            m_Animator.SetFloat("Speed", 0);
            //m_brain.m_BaseMoveManager.m_NavMeshAgent.speed = 0.01f;
            _Brain.m_BaseMoveManager.ChangeMoveTarget(_Brain.m_CurrentTransform);
        }
        public override void PlayLearnedBehavior()
        {
            if (m_brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                lookAtTarget.x = m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.x;
                lookAtTarget.y = m_brain.m_CurrentTransform.position.y;
                lookAtTarget.z = m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.z;

                m_brain.m_CurrentTransform.LookAt(lookAtTarget);
            }
            
            
        }
    }

}
