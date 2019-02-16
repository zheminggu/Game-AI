using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI {
    [CreateAssetMenu (menuName ="AI/LearnedBehavior/Pursuit")]
    public class Pursuit : LearnedBehavior
    {
        private Transform pursuitTatget;
        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            m_learnedBehaviorManager.m_baseMoveManager.m_NavMeshAgent.speed = _Brain.m_BaseMoveManager.m_RunSpeed;

            pursuitTatget = _Brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform;
        }

        public override void PlayLearnedBehavior()
        {

            m_Animator.SetFloat("Speed", 2);
            Vector3 _PursuitTarget = new Vector3(pursuitTatget.position.x, m_brain.m_CurrentTransform.position.y, pursuitTatget.position.z);
            m_brain.m_CurrentTransform.LookAt(_PursuitTarget);
            m_brain.m_CurrentTargetPosition = pursuitTatget.position;
          //  m_brain.m_CurrentTransform.forward = pursuitTatget.position;
            m_learnedBehaviorManager.m_baseMoveManager.ChangeMoveTarget(pursuitTatget);
        }
    }

}

