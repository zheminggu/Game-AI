using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 判断是否到达目标地点
    /// </summary>
    [CreateAssetMenu (menuName = "AI/DecideEvents/ReachedTarget")]
    public class ReachedTarget :DecideEvents
    {
        [SerializeField]
        private float arrivedDistance;
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            if (_Brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                float distanceBetweenEnemyAndAI = (_Brain.m_CurrentTransform.transform.position - _Brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position).sqrMagnitude;
                if (distanceBetweenEnemyAndAI <= arrivedDistance * arrivedDistance)
                {
                   // Debug.Log("Arrived Target" + _Brain.m_BaseMoveManager.m_NavMeshAgent.remainingDistance);
                    return true;
                }
            }

            return false;
            
        }
    }

}
