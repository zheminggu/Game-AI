using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    /// <summary>
    /// 学习性行为，以基础行为(如move senor acts)作为基础进行的组合行为
    /// </summary>
    public class LearnedBehavior : ScriptableObject
    {
        protected AICharacterBrain m_brain;
        protected  LearnedBehaviorManager m_learnedBehaviorManager;
        protected Animator m_Animator;
        public virtual void Initialize(AICharacterBrain _Brain) {
            m_brain = _Brain;
            m_Animator = _Brain.GetComponent<Animator>();
            m_learnedBehaviorManager = _Brain.m_LearnedBehaviorManager;
        }
        /// <summary>
        /// 每一帧都会做的事情
        /// </summary>
        public virtual void PlayLearnedBehavior() { }
     
    }
}

