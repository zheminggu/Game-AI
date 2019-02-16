using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 用于遇见敌人时的暂时撤退
    /// </summary>
    [CreateAssetMenu(menuName = "AI/LearnedBehavior/Backward")]
    public class Backward :LearnedBehavior
    {
        private Transform evadeTarget;//需要逃离的目标
        private Vector3 evadePosition;//逃离到的地点
        private float timeLag;
        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            timeLag = 2f;
            m_Animator.SetFloat("Speed", 2);
        }
        public override void PlayLearnedBehavior()
        {
            evadeTarget = m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform;
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
            if (timeLag>0)
            {
                timeLag -= Time.deltaTime;
            }
            else
            {
                m_brain.transform.LookAt(new Vector3(evadePosition.x, m_brain.transform.position.y, evadePosition.z));
            }

            // m_brain.transform.forward = evadePosition;
            //Debug.Log("EvadePosition is " + evadePosition);
            m_brain.m_BaseMoveManager.ChangeMoveTarget(evadePosition);
            //m_brain.transform.LookAt(new Vector3(evadePosition.x, 0, evadePosition.z));
            

        }
    }

}

