using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class JudgeOthers
    {
        private AICharacterBrain brain;

        /// <summary>
        /// 判断当前邻居是否是敌人，一次只有一个敌人
        /// judge if current neighbors are enemy
        /// </summary>
        /// <param name="_Brain"></param>
        public void JudgeIfNeighborIsEnemy(AICharacterBrain _Brain)
        {
            brain = _Brain;
            for(int i = 0; i < brain.m_SensorManager.m_SensorData.m_Neighbors.Count; i++)
            {
                if (brain.m_AIMemory.m_Acquaintance[brain.m_SensorManager.m_SensorData.m_Neighbors[i].name] == AISettings.RelationShip.Hate)
                {
                    brain.m_SensorManager.m_SensorData.m_HaveEnemy = true;
                    brain.m_SensorManager.m_SensorData.m_EnemyTarget = brain.m_SensorManager.m_SensorData.m_Neighbors[i];
                    return;
                }
            }

        }
        public void JudgeIfNeighborIsWhoIFear(AICharacterBrain _Brain)
        {
            brain = _Brain;
            for (int i = 0; i < brain.m_SensorManager.m_SensorData.m_Neighbors.Count; i++)
            {
                if (brain.m_AIMemory.m_Acquaintance[brain.m_SensorManager.m_SensorData.m_Neighbors[i].name] == AISettings.RelationShip.Fear)
                {
                    brain.m_SensorManager.m_SensorData.m_NeedEvade = true;
                    brain.m_SensorManager.m_SensorData.m_EvadeTarget = brain.m_SensorManager.m_SensorData.m_Neighbors[i];
                    return;
                }
            }
        }
    }

}
