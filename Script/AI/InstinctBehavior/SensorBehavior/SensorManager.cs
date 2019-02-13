using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class SensorManager
    {
        /// <summary>
        /// 感受的数据
        /// </summary>
        public SensorData m_SensorData { get { return sensorData; } }

        /// <summary>
        /// 感受器
        /// </summary>
        public Sensor[] m_Sensor { get { return sensor; }set { sensor = value; } }

        private SensorData sensorData=new SensorData();

        private Sensor[] sensor;
        
        public void OnSensorUpdate()
        {
            for(int i = 0; i < sensor.Length; i++)
            {
                sensor[i].DetectTheWorld();
            }
        }

        #region sensorManager
        /// <summary>
        /// 获取当前的的敌对目标
        /// </summary>
        /// <returns></returns>
        public GameObject M_GetCurrentEnemyTarget()
        {
            return m_SensorData.m_EnemyTarget;
        }
        /// <summary>
        /// 判断当前是否拥有敌对目标
        /// </summary>
        /// <returns></returns>
        public bool M_JudgeIfAIHasEnemy()
        {
            return m_SensorData.m_HaveEnemy;
        }
        /// <summary>
        /// 获取当前的邻居
        /// </summary>
        /// <returns></returns>
        public List<GameObject> M_GetCurrentNeighbors()
        {
            return m_SensorData.m_Neighbors;
        }
        public GameObject M_GetCurrentEvadeTarget()
        {
            return m_SensorData.m_EvadeTarget;
        }
        #endregion
    }

}

