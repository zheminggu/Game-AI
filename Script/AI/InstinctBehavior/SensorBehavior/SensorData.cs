using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI {
    public class SensorData 
    {
        /// <summary>
        /// 敌对目标可选择攻打
        /// </summary>
        public GameObject m_EnemyTarget { get; set; }
      
        /// <summary>
        /// 判断当前是否有敌人
        /// </summary>
        public bool m_HaveEnemy { get; set; }

        /// <summary>
        /// 判断当前的邻居
        /// </summary>
        public List<GameObject> m_Neighbors = new List<GameObject>();

        /// <summary>
        /// 当前我需要逃离的目标
        /// </summary>
        public GameObject m_EvadeTarget { get; set; }

        /// <summary>
        /// 当前是否需要逃跑
        /// </summary>
        public bool m_NeedEvade { get; set; }

        /// <summary>
        /// 判断当前学习性行为是否完成
        /// </summary>
        public bool m_FinishedDoingCurrentLearnedBehavior { get; set; }
    }

}

