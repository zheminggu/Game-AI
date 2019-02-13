using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AI
{
    public class AISettings : MonoBehaviour
    {
        /// <summary>
        /// aiCharacter与其他角色之间的关系
        /// </summary>
        public enum RelationShip
        {
            /// <summary>
            /// 害怕的人
            /// </summary>
            Fear,
            /// <summary>
            /// 不熟悉的人
            /// </summary>
            Acquaintance,

            /// <summary>
            /// 熟悉但不讨厌的人
            /// </summary>
            Familiar,

            /// <summary>
            /// 恨的人
            /// </summary>
            Hate,

            /// <summary>
            /// 爱的人
            /// </summary>
            Love,
        }


        /// <summary>
        /// 用户在aisetting里面预设的ai角色与其他角色的关系表
        /// </summary>
        [System.Serializable]
        public struct PreSetAcquaintanceInfo
        {
            public GameObject PreSetObject;
            public RelationShip PreSetRelationship;
        }

        /// <summary>
        /// 初始选择的高级行为
        /// </summary>
        [Tooltip ("初始选择的高级行为")]
        public Decisions m_OriginalDecision;

        /// <summary>
        /// ai判断下一个决定时需要的判断思维
        /// </summary>
        [Tooltip ("选择AI拥有的表意识")]
        public SurfaceConscious m_SurfaceConscious;

        /// <summary>
        /// 巡逻地点
        /// </summary>
        [Tooltip ("巡逻的地点")]
        public List<Transform> m_PatrolPlace=new List<Transform>();

        /// <summary>
        /// ai对世界感受与分析的时间间隔
        /// </summary>
        [Tooltip("ai对世界感受与分析的时间间隔")]
        public float m_DelayTimer = 1.0f;

        #region sensor
        [Header ("Sensor Data")]
        /// <summary>
        /// AI拥有的感受器
        /// </summary>
        [Tooltip("AI拥有的感受器")]
        public Sensor[] m_Sensor;


        [Title("Sight Sensor Data")]
        /// <summary>
        /// 这个AI角色的视域范围
        /// </summary>
        [Tooltip ("这个AI角色的视域范围")]
        public float m_FieldOfView = 45f;

        /// <summary>
        /// 这个AI角色最远能够看到的距离
        /// </summary>
        [Tooltip ("这个AI角色最远能够看到的距离")]
        public float m_ViewDistance = 100f;

        /// <summary>
        /// 在ai角色进行视觉侦测时将会侦测的层
        /// </summary>
        [Tooltip(" 在ai角色进行视觉侦测时将会侦测的层")]
        public LayerMask m_LayerChacked=-1;

        #endregion

        #region relationship
        [Header ("Relationship data")]
        /// <summary>
        /// 预设ai与世界里其他角色的关系
        /// </summary>
        [Tooltip ("设置这个ai角色与其他角色的关系")]
        public List<PreSetAcquaintanceInfo> m_PreSetAcquaintanceInfo=new List<PreSetAcquaintanceInfo>();

        #endregion
        #region baseMove
        [Header("AI Speed")]
        public float m_WalkSpeed=2f;

        public float m_RunSpeed=5f;
        #endregion 

        private void OnDrawGizmos()
        {
            //Debug.Log(transform.position);

            Gizmos.DrawWireSphere(transform.position, m_ViewDistance);
            Debug.DrawRay(transform.position, transform.forward, Color.green);
        }
        public PreSetAcquaintanceInfo CreatePreSetAcquaintanceInfo(GameObject _People,RelationShip _Relationship)
        {
            PreSetAcquaintanceInfo _preSetAcquaintanceInfo = new PreSetAcquaintanceInfo();
            _preSetAcquaintanceInfo.PreSetObject = _People;
            _preSetAcquaintanceInfo.PreSetRelationship = _Relationship;
            return _preSetAcquaintanceInfo;
        }
    }
}

