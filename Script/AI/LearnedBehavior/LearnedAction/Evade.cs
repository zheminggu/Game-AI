using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{

    /// <summary>
    /// 用于遇见害怕对象的逃跑
    /// </summary>
    [CreateAssetMenu (menuName = "AI/LearnedBehavior/Evade")]
    public class Evade : LearnedBehavior
    {
        private Transform evadeTarget;//需要逃离的目标
        private Vector3 evadePosition=new Vector3();//逃离到的地点
        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            evadeTarget = _Brain.m_SensorManager.M_GetCurrentEvadeTarget().transform;
        }
        public override void PlayLearnedBehavior()
        {
            CalculateEvadePostion();
            MoveToEvadePosition();
        }
        private void CalculateEvadePostion()
        {
            evadePosition.x = m_brain.m_CurrentTransform.position.x * 2 - evadeTarget.position.x;
            evadePosition.y = m_brain.m_CurrentTransform.position.y * 2 - evadeTarget.position.y;
            evadePosition.z = m_brain.m_CurrentTransform.position.z * 2 - evadeTarget.position.z;

        }
        private void MoveToEvadePosition()
        {
           // m_brain.transform.forward = evadePosition;
            m_brain.m_BaseMoveManager.ChangeMoveTarget(evadePosition);

            m_brain.transform.LookAt(new Vector3(evadePosition.x,m_brain.m_CurrentTransform.position.y,evadePosition.z));
            if (m_brain.m_BaseMoveManager.m_NavMeshAgent.remainingDistance == 0)
            {
                m_Animator.SetFloat("Speed", 0);
            }
            else
            {
                m_Animator.SetFloat("Speed", 2);
            }
        }
    }
}

