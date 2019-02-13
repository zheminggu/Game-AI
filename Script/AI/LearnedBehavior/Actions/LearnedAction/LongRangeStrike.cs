using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class LongRangeStrike :LearnedBehavior
    {
        public string m_Skill;
        private float timeLag;
        [SerializeField]
        [Tooltip("当前的攻击延时模式")]
        private  Attack.AttackMode currentAttackMode;
        [SerializeField]
        [Tooltip("最小的攻击延时")]
        private float timeLagRecorderMin = 1f;
        [SerializeField]
        [Tooltip("最大的攻击延时")]
        private float timeLagRecorderMax = 1.5f;

        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            _Brain.m_BaseMoveManager.ChangeMoveTarget(_Brain.m_CurrentTransform);
            m_Animator.SetFloat("Speed", 0);
            m_Animator.SetTrigger(m_Skill);
            SetTimeLag();

        }
        public override void PlayLearnedBehavior()
        {
            if (m_brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                Vector3 _LookAtPosition = new Vector3(m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.x, m_brain.m_CurrentTransform.position.y, m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.z);
                m_brain.transform.LookAt(_LookAtPosition);

            }
            timeLag -= Time.deltaTime;
            if (timeLag < 0)
            {
                Debug.Log(m_Animator);
                m_Animator.SetTrigger(m_Skill);
                SetTimeLag();
            }
        }
        private void SetTimeLag()
        {
            if (currentAttackMode == Attack.AttackMode.Orderly)
            {
                timeLag = timeLagRecorderMin;
            }
            else
            {
                timeLag = Random.Range(timeLagRecorderMin, timeLagRecorderMax);
            }
        }
    }

}
