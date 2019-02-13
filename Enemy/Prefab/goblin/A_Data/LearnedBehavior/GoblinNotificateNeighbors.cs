using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

[CreateAssetMenu (menuName = "AI/Enemy/Goblin/LearnedBehavior/GoblinNotificateNeighbors")]
public class GoblinNotificateNeighbors : LearnedBehavior {
    [SerializeField]
    [Tooltip ("通知的范围")]
    private float notificateDistance = 10f;
    [SerializeField]
    [Tooltip ("通知的对象的Tag")]
    private string notificateCharacterTag;
    public override void Initialize(AICharacterBrain _Brain)
    {
        base.Initialize(_Brain);
        m_brain.m_SensorManager.m_SensorData.m_FinishedDoingCurrentLearnedBehavior = false;
    }
    public override void PlayLearnedBehavior()
    {
        base.PlayLearnedBehavior();
        
        Collider[] _Neighbors= Physics.OverlapSphere(m_brain.m_CurrentTransform.position, notificateDistance);
        for (int i = 0; i < _Neighbors.Length; i++)
        {
            if (_Neighbors[i].gameObject.tag==notificateCharacterTag)
            {
                MakeItKnowThereIsEnemy(_Neighbors[i].gameObject);
            }
        }
        m_brain.m_SensorManager.m_SensorData.m_FinishedDoingCurrentLearnedBehavior = true;
    }
    private void MakeItKnowThereIsEnemy(GameObject _Neighbor)
    {
        if (_Neighbor.GetComponent<AICharacterBrain >())
        {
            _Neighbor.GetComponent<AICharacterBrain>().m_SensorManager.m_SensorData.m_EnemyTarget =m_brain.m_SensorManager.m_SensorData.m_EnemyTarget;
            _Neighbor.GetComponent<AICharacterBrain>().m_SensorManager.m_SensorData.m_HaveEnemy = true;
        }
    }
}
