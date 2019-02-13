using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI {
    [CreateAssetMenu (menuName ="AI/Decidions")]
    public class Decisions : ScriptableObject
    {
        public enum DecideLevel
        {
          
            DoItRightNow,
            WaitingForSelect,
            LittleProbablity,
            MediumProbablity,
            LargeProbablity,
        }
        [System.Serializable]
        public struct NextDecision
        {
            /// <summary>
            /// 当前决定对应的接下来可能会做的决定
            /// </summary>
            [Tooltip("当前决定对应的接下来会做的决定")]
            public Decisions m_NextDecision;

            /// <summary>
            /// 做接下来的这个决定需要满足的条件
            /// </summary>
            [Tooltip ("做接下来的这个决定需要满足的条件")]
            public DecideEvents m_DecideEvents; 

            /// <summary>
            /// 达成做这个决定的条件时，做这个决定的可能性
            /// </summary>
            [Tooltip ("达成做这个决定的条件时，做这个决定的可能性")]
            public DecideLevel m_ProbabilityToDoThisDecision;
        }

        /// <summary>
        /// 当前的学习性行为
        /// </summary>
        public LearnedBehavior m_learnedBehavior { get { return learnedBehavior; } }

        /// <summary>
        /// 当前学习性行为所对应拥有的学习性行为
        /// </summary>
        public NextDecision[] m_NextDecisions{ get { return nextDecision; } }


        [SerializeField]
        private LearnedBehavior learnedBehavior;//当前决定是什么学习性行为

        [SerializeField]
        private NextDecision[] nextDecision;//将会有些什么决定
       
        /// <summary>
        /// 初始化决定以及相对应的学习性行为
        /// </summary>
        /// <param name="_Brain"></param>
        public void Initialize(AICharacterBrain _Brain)
        {
            learnedBehavior = Instantiate(learnedBehavior);
            learnedBehavior.Initialize(_Brain);
        }
    }

}


