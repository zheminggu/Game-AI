using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI {
    /// <summary>
    /// 巡逻
    /// </summary>
    [CreateAssetMenu (menuName ="AI/LearnedBehavior/Patrol")]
    public class Patrol : LearnedBehavior
    {
        [SerializeField]
        [Tooltip ("自动选择寻路离出生点的最远距离")]
        private float autoPatrolDistance=10f;

        [SerializeField]
        [Tooltip("自动选择点时选择的最远的距离")]
        private float autoChooseMaxDistance = 5f;
        [SerializeField]
        [Tooltip("自动选择点时选择的最近的距离")]
        private float autoChooseMinDistance = 3f;
        Queue<Vector3> patrolQueue=new Queue<Vector3>();
        private Vector3[] patrolTarget;
        private Transform[] patrolTargetTramsform;
        private Vector3 tempTarget;
        private float timeLag;
        private float timeLagRecorder = 0.5f;

        /// <summary>
        /// 初始化patrol
        /// </summary>
        /// <param name="_learnedBehaviorManager"></param>
        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            //Debug.Log("in here");
            //Debug.Log(_learnedBehaviorManager.m_PatrolTargets.Count);
            //Debug.Log(patrolTarget.Length);
            m_learnedBehaviorManager.m_baseMoveManager.m_NavMeshAgent.speed = _Brain.m_BaseMoveManager.m_WalkSpeed;
            timeLag = timeLagRecorder;
            for (int i = 0; i < m_learnedBehaviorManager.m_PatrolTargets.Count; i++)
            {
                //Debug.Log(m_learnedBehaviorManager.m_PatrolTargets[i]);
                patrolQueue.Enqueue(m_learnedBehaviorManager.m_PatrolTargets[i]);
            }
            //Debug.Log(patrolQueue.Count);
            m_Animator.SetFloat("Speed", 1);
        }

        public override void PlayLearnedBehavior()
        {
           
            timeLag -= Time.deltaTime;
            if (m_learnedBehaviorManager.m_PatrolTargets.Count==0&& SoFarAwayFromBornPlace())
            {
                m_brain.m_BaseMoveManager.ChangeMoveTarget(m_brain.m_OriginalPlace);
                timeLag = timeLagRecorder;
            }
            if (ReachedTarget())
            {

                if (timeLag <= 0)
                {
                    if (m_learnedBehaviorManager.m_PatrolTargets.Count == 0)
                    {
                        ChoosePatrolPointItself();
                    }
                    else
                    {
                        LoopChangeMoveTarget();
                    }
                   
                    timeLag = timeLagRecorder;
                }


            }
            
        }
        #region Choose Patrol Point Automatically
        private void ChoosePatrolPointItself()
        {
            Vector3 _TargetPosition = new Vector3();
            _TargetPosition.x = m_brain.m_CurrentTransform.position.x + Random.Range(autoChooseMinDistance,autoChooseMaxDistance);
            _TargetPosition.y = m_brain.m_CurrentTransform.position.y;
            _TargetPosition.z = m_brain.m_CurrentTransform.position.z + Random.Range(autoChooseMinDistance,autoChooseMaxDistance);
            m_learnedBehaviorManager.m_baseMoveManager.ChangeMoveTarget(_TargetPosition);
            m_brain.m_CurrentTargetPosition = _TargetPosition;
        }

        private bool SoFarAwayFromBornPlace()
        {
          if((m_brain.m_CurrentTransform.position- m_brain.m_OriginalPlace).sqrMagnitude>autoPatrolDistance*autoPatrolDistance)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Change Patrol Place When It Had beed Defined
        /// <summary>
        /// 循环改变目标地点
        /// </summary>
        private void LoopChangeMoveTarget()
        {
            //Debug.Log(patrolQueue.Count);
            Vector3 _TempTarget = patrolQueue.Dequeue();

            //Debug.Log(_TempTarget);
            m_learnedBehaviorManager.m_baseMoveManager.ChangeMoveTarget(_TempTarget);
            patrolQueue.Enqueue(_TempTarget);

            m_brain.m_CurrentTargetPosition = _TempTarget;
        }

        /// <summary>
        /// 判断是否到了目标地点
        /// </summary>
        private bool ReachedTarget()
        {
            if (m_learnedBehaviorManager.m_baseMoveManager.m_NavMeshAgent.remainingDistance<1)
            {
                return true;
            }
            return false;
        }
        #endregion 
    }
}


