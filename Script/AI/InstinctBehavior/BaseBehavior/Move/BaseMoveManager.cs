using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AI
{
    public class BaseMoveManager
    {
        public NavMeshAgent m_NavMeshAgent { get { return navMeshAgent; } }
        public float m_WalkSpeed { get { return walkSpeed; }set { walkSpeed = value; } }
        public float m_RunSpeed { get { return runSpeed; }set { runSpeed = value; } }


        private float currentMoveSpeed;//当前的移动速度
        private NavMeshAgent navMeshAgent;//使用的navMash
        private AICharacterBrain brain;//ai的大脑

        private float walkSpeed;
        private float runSpeed;
        /// <summary>
        /// 用于传入参数
        /// </summary>
        /// <param name="_Brain">接收外部传入的aicharacterBrain </param>
        public void Initialize(AICharacterBrain _Brain)
        {
            brain = _Brain;
            navMeshAgent = brain.GetComponent<NavMeshAgent>();
        }

        /// <summary>
        /// 改变移动的目标
        /// </summary>
        /// <param name="_Position">获取的位置</param>
        public void ChangeMoveTarget(Vector3 _Position)
        {
            navMeshAgent.destination = _Position;
        }

        /// <summary>
        /// 使用transform给变移动的目标
        /// </summary>
        /// <param name="_Transform">获取的Transform</param>
        public void ChangeMoveTarget(Transform _Transform)
        {
            navMeshAgent.destination = _Transform.position;
        }
    }

}
