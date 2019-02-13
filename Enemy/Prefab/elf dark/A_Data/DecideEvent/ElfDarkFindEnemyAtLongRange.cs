using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
namespace Adamgu.Enemy
{
    [CreateAssetMenu (menuName = "AI/Enemy/ElfDark/DecideEvents/FindEnemyAtLongRange")]
    public class ElfDarkFindEnemyAtLongRange : DecideEvents
    {
        [SerializeField]
        [Tooltip ("定义的远程距离")]
        private float longRangeDistance;
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            if (_Brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                float DistanceBetweenAIAndEnemy = (_Brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position - _Brain.m_CurrentTransform.position).sqrMagnitude;
                if (DistanceBetweenAIAndEnemy>longRangeDistance*longRangeDistance)
                {
                    return true;
                }
            }
            return false;

        }
    }

}
