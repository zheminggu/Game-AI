using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

namespace AI {
    /// <summary>
    /// 学习性行为管理，管理相关的学习性行为，并使其工作
    /// </summary>
    public class LearnedBehaviorManager
    {
        #region LearnedBehaviorMessage
        public BaseMoveManager m_baseMoveManager { get { return baseMoveManager; } }
       
        /// <summary>
        /// 用于外部改变当前的决定
        /// </summary>
        public Decisions m_Decisions { get { return decisions; } set { decisions = value; } }

        /// <summary>
        /// 巡逻的地点
        /// </summary>
        public List<Vector3> m_PatrolTargets=new List<Vector3>();

        #endregion

        private BaseMoveManager baseMoveManager;//基础移动      

        private AISettings aiSettings;
        private Decisions decisions;//当前的决定
        private AICharacterBrain brain;
        //private LearnedBehavior currentLearnedBehavior;//当前决定所对应的学习性行为

        /// <summary>
        /// 初始化LearnedBehaviorManager
        /// </summary>
        /// <param name="_Brain">传入的AIbrain</param>
        public void Initialize(AICharacterBrain _Brain)
        {
            brain = _Brain;
            aiSettings = _Brain.GetComponent<AISettings>();
           // Debug.Log(aiSettings.m_PatrolPlace[0].position);
            baseMoveManager = _Brain.m_BaseMoveManager;
            for(int i = 0; i < aiSettings.m_PatrolPlace.Count; i++)
            {
                if (aiSettings.m_PatrolPlace[i]!=null)
                {
                    m_PatrolTargets.Add(aiSettings.m_PatrolPlace[i].position);
                }
            }
            InitializeDecision();
        }

        /// <summary>
        /// 初始化决定
        /// </summary>
        public void InitializeDecision()
        {
            decisions = aiSettings.m_OriginalDecision;

            //Debug.Log(decisions);
            //Debug.Log("Next decisions' number is : "+decisions.m_NextDecisions.Length);
            //for (int i = 0; i < decisions.m_NextDecisions.Length; i++)
            //{
            //    Debug.Log("decisions.m_NextDecisions[i].m_NextDecision is:"+decisions.m_NextDecisions[i].m_NextDecision);
            //    Debug.Log("decisions.m_NextDecisions[i].m_DecideEvents is:" + decisions.m_NextDecisions[i].m_DecideEvents);
            //}
            //初始化dicision
            decisions.Initialize(brain);

        }

        /// <summary>
        /// 每一帧进行相对应的学习性行为
        /// </summary>
        public void OnUpdate()
        {
            if (decisions.m_learnedBehavior==null)
            {
                Debug.Log("LearnedBehavior can't be null");
            }
            //进行相对应的学习性行为
            decisions.m_learnedBehavior.PlayLearnedBehavior();
        }


    }


}

