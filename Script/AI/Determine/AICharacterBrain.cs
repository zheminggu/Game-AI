using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [RequireComponent (typeof(AISettings))]
    [RequireComponent (typeof(NavMeshAgent))]
    /// <summary>
    /// 获取自身拥有的属性
    /// 根据潜意识和表意识做出决定
    /// </summary>
    public class AICharacterBrain : MonoBehaviour
    {
        #region publics
        /// <summary>
        /// managers and information
        /// </summary>
        public BaseMoveManager m_BaseMoveManager { get { return baseMoveManager; } }
        public SensorManager m_SensorManager { get { return sensorManager; } }
        public Transform m_CurrentTransform { get { return brain.transform; } }
        public AIMemory m_AIMemory { get { return aiMemory; } }
        public SurfaceConsciousManager m_SurfaceConsicousManager { get { return surfaceConsciousManager; } }
        public LearnedBehaviorManager m_LearnedBehaviorManager { get { return learnedBehaviorManager; } }
        public Vector3 m_OriginalPlace { get { return originalPlace; } }
        public Vector3 m_CurrentTargetPosition { get; set; }
        public bool isDied = false;
        public bool isPaused = false;
        #endregion

        #region private
        //brain
        private AICharacterBrain brain;
        private float delayTimer;
        private float recordDelayTimer;//记录延迟时间

        //basic property of AI
        private AISettings aiSettings;
        private BaseMoveManager baseMoveManager = new BaseMoveManager();
        private LearnedBehaviorManager learnedBehaviorManager = new LearnedBehaviorManager();
        private SensorManager sensorManager = new SensorManager();//管理感知
        private AIMemory aiMemory = new AIMemory();
        private SurfaceConsciousManager surfaceConsciousManager = new SurfaceConsciousManager();
        private List<Decisions> decisionsWaitingForSelect = new List<Decisions>();

        private Animator anim;
        private bool onDecesionEnabled = true;
        private Vector3 originalPlace;
        #endregion


        #region initializeData
        // Use this for initialization
        void Start()
        {
            brain = GetComponent<AICharacterBrain>();
            aiSettings = GetComponent<AISettings>();
            originalPlace = new Vector3(m_CurrentTransform.position.x, m_CurrentTransform.position.y, m_CurrentTransform.position.z);

            if (aiSettings.m_PreSetAcquaintanceInfo.Count==0)
            {
                aiSettings.m_PreSetAcquaintanceInfo.Add(aiSettings.CreatePreSetAcquaintanceInfo(GameObject.FindGameObjectWithTag("Player"), AISettings.RelationShip.Hate));
                //Debug.Log(aiSettings.m_PreSetAcquaintanceInfo[0].PreSetObject + " " + aiSettings.m_PreSetAcquaintanceInfo[0].PreSetRelationship);
            }
            //anim = GetComponent<Animator>();
            delayTimer = aiSettings.m_DelayTimer;
            recordDelayTimer = aiSettings.m_DelayTimer;

            InitializeProperty();
            
        }

        /// <summary>
        /// 获取自身拥有的属性
        /// </summary>
        private void InitializeProperty()
        {
            InitializeBaseMove();
            aiSettings.m_OriginalDecision = Instantiate(aiSettings.m_OriginalDecision);
            //获取当前的学习性行为属性
            learnedBehaviorManager.Initialize(brain);
            InitializeSensor();
            aiMemory.InitializeDictionary(brain);

            InitializeSurfaceConsicious();
            
        }
        private void InitializeSurfaceConsicious()
        {
            //Debug.Log(brain.aiSettings.m_SurfaceConscious);
            if (brain.aiSettings.m_SurfaceConscious)
            {
                brain.aiSettings.m_SurfaceConscious= Instantiate(brain.aiSettings.m_SurfaceConscious);
                surfaceConsciousManager.m_AISurfaceConscious = Instantiate(brain.aiSettings.m_SurfaceConscious);
            }
          
            surfaceConsciousManager.Initialize(brain);

        }
        private void InitializeBaseMove()
        {
            //获取自身的移动属性
            baseMoveManager.Initialize(brain);
            baseMoveManager.m_WalkSpeed = brain.aiSettings.m_WalkSpeed;
            baseMoveManager.m_RunSpeed = brain.aiSettings.m_RunSpeed;
        }
        /// <summary>
        /// 初始化sensor
        /// </summary>
        private void InitializeSensor()
        {
            sensorManager.m_Sensor = aiSettings.m_Sensor;
            for (int i = 0; i < sensorManager.m_Sensor.Length; i++)
            {
                sensorManager.m_Sensor[i] = Instantiate(sensorManager.m_Sensor[i]);
                sensorManager.m_Sensor[i].InitializeSensor(brain);
            }
        }

       
        #endregion

        // Update is called once per frame
        void Update()
        {
            if(isDied || isPaused)
            {
                return;
            }
      
            delayTimer -= Time.deltaTime;
            //定时侦测世界
            if (delayTimer <= 0)
            {               
                sensorManager.OnSensorUpdate();//侦测世界         

                delayTimer = recordDelayTimer;
            }
            JudgeIfMadeNextDecision();
            learnedBehaviorManager.OnUpdate(); //进行相对应的学习性行为
         
        }

        /// <summary>
        /// 改变当前的决定
        /// </summary>
        /// <param name="_Decision">要改编为的决定</param>
        public void ChangeDecision(Decisions _Decision)
        {
            //Debug.Log(gameObject.name+"Decision Change Had Been Called");
            //决定可以在不同的ai角色中共用
            brain.m_LearnedBehaviorManager.m_Decisions = Instantiate(_Decision);
            brain.m_LearnedBehaviorManager.m_Decisions.Initialize(brain);
            //Debug.Log(gameObject.name+"Current Decision is"+brain.m_LearnedBehaviorManager.m_Decisions);
        }
 
        private void JudgeIfMadeNextDecision() {
            //Debug.Log("brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions.Length is" + brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions.Length);     
            //if (brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecision.Length==0)
            //{
            //    return;
            //}
            //对每一个可能的改变分析侦测结果，如果需要改变相对应的学习性行为，则改变
            for (int i = 0; i < brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions.Length; i++)
            {
                if (brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_DecideEvents==null)
                {
                    Debug.Log("Decide Events can't be Null, Current Decision is"+brain.m_LearnedBehaviorManager.m_Decisions);
                    return;
                }
                else if (brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_NextDecision==null)
                {
                    Debug.Log("Next Decision can't be Null, Current Decision is"+ brain.m_LearnedBehaviorManager.m_Decisions);
                    return;
                }

                //Debug.Log("brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_DecideEvents is" + brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_DecideEvents);
                //Debug.Log("brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_NextDecision is" + brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_NextDecision);

                if (brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_DecideEvents.MatchedChangeCondition(brain))
                {
                    //Debug.Log("Mached Change Condition");
                    //如果遇到立马就要改变的就改变
                    if (brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_ProbabilityToDoThisDecision == Decisions.DecideLevel.DoItRightNow)
                    {
                        //Debug.Log("coming here");
                        ChangeDecision(brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_NextDecision);
                        break;
                    }
                    else if (brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_ProbabilityToDoThisDecision == Decisions.DecideLevel.WaitingForSelect)
                    {
                        decisionsWaitingForSelect.Add(brain.m_LearnedBehaviorManager.m_Decisions.m_NextDecisions[i].m_NextDecision);
                    }
                }
            }

            //如果遇到一个以上需要改变的进行分析评分
            if (decisionsWaitingForSelect.Count != 0&&onDecesionEnabled)
            {

                Debug.Log("meet multiple decisions");
                surfaceConsciousManager.OnCalled(decisionsWaitingForSelect);
                //Debug.Log(gameObject.name+ "Atfer Surface Consious the length is" + decisionsWaitingForSelect.Count);
                onDecesionEnabled = false;
                Invoke("MakeOtherDecisionEnabled", 2f);
            }
        }

        private void MakeOtherDecisionEnabled()
        {
            onDecesionEnabled = true;
        }

        
    }


}
