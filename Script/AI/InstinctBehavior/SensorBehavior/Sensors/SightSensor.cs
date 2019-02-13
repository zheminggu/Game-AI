using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    /// <summary>
    /// 视觉感觉
    /// </summary>
    [CreateAssetMenu (menuName ="AI/Sensor/SightSensor")]
    public class SightSensor : Sensor
    {
        private Collider[] colliders;
        private AICharacterBrain brain;
        private AISettings aiSettings;
        private JudgeOthers judgeOthers=new JudgeOthers();

        public override void InitializeSensor(AICharacterBrain _Brain)
        {
            brain=_Brain;
            aiSettings = _Brain.GetComponent<AISettings>();
        }
        public override void DetectTheWorld()
        {
            brain.m_SensorManager.m_SensorData.m_Neighbors.Clear();//每一次视觉感知清除原先侦测到的邻居
            colliders = Physics.OverlapSphere(brain.m_CurrentTransform.position, aiSettings.m_ViewDistance,aiSettings.m_LayerChacked);
            for(int i=0; i < colliders.Length; i++)
            {
                Vector3 neighborDirection = colliders[i].transform.position - brain.m_CurrentTransform.position;
 
                //假如在视角之内
                if (Vector3.Angle(neighborDirection, brain.m_CurrentTransform.forward)<aiSettings.m_FieldOfView)
                {
                    //假如不是自己
                    if (colliders[i].gameObject!=brain.m_CurrentTransform.gameObject)
                    {
                        RaycastHit[] _raycast;

                        //经检测raycastAll不会检测到自己
                        _raycast = Physics.RaycastAll(brain.m_CurrentTransform.position, neighborDirection, neighborDirection.magnitude);

                        //for(int j = 0; j < _raycast.Length; j++)
                        //{
                        //    Debug.Log(_raycast[j].collider.gameObject.name);
                        //}

                        //一条直线设过去只看见当前的物体，表示两者之间没有阻挡物，才能看见
                        if (_raycast.Length==1)
                        {
                            //加入neighbor列表
                            brain.m_SensorManager.m_SensorData.m_Neighbors.Add(colliders[i].gameObject);
                            //新邻居加入字典中
                            if (!brain.m_AIMemory.m_Acquaintance.ContainsKey(colliders[i].gameObject.name))
                            {
                                brain.m_AIMemory.m_Acquaintance.Add(colliders[i].gameObject.name, AISettings.RelationShip.Acquaintance);
                            }
                        }
                       
                    }
                }
            }
            judgeOthers.JudgeIfNeighborIsEnemy(brain);
            judgeOthers.JudgeIfNeighborIsWhoIFear(brain);
        }
        
    }
}

