using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPCAI;
namespace AI
{
    [CreateAssetMenu (menuName ="AI/LearnedBehavior/Attack")]
    public class Attack : LearnedBehavior
    {
        public enum AttackMode {
            /// <summary>
            /// 整齐的
            /// </summary>
            Orderly,
            /// <summary>
            /// 随机的
            /// </summary>
            [Tooltip ("随机的攻击以最小时间延时为主")]
            Randomly,
        }

        public string m_Skill;
        
        private float timeLag;
        private GameObject currentBullet;
        
        [SerializeField]
        [Tooltip("当前的攻击延时模式")]
        private AttackMode currentAttackMode;
        [SerializeField]
        [Tooltip ("最小的攻击延时")]
        private float timeLagRecorderMin=2.5f;
        [SerializeField]
        [Tooltip ("最大的攻击延时")]
        private float timeLagRecorderMax = 3f;
        [Header ("LongRangeStrike")]
        [SerializeField]
        [Tooltip("当前的攻击模式")]
        private bool PlayLongRangeStrike;
        [SerializeField]
        [Tooltip("远程射击的东西")]
        private GameObject bulletPrefab;
        [SerializeField]
        [Tooltip("子弹速度")]
        private float bulletSpeed = 10f;
        [SerializeField]
        private Vector3 fixHight = new Vector3(0, 1.5f, 0);

        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
            _Brain.m_BaseMoveManager.ChangeMoveTarget(_Brain.m_CurrentTransform);
            m_Animator.SetFloat("Speed", 0);

            if (PlayLongRangeStrike)
            {
                ShootAtTarget();
            }
            m_Animator.SetTrigger(m_Skill);

            SetTimeLag();
        }
        public override void PlayLearnedBehavior()
        {
            if (m_brain.m_SensorManager.m_SensorData.m_HaveEnemy)
            {
                Vector3 _LookAtPosition = new Vector3(m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.x, m_brain.m_CurrentTransform.position.y, m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.z);
                m_brain.transform.LookAt(_LookAtPosition);
                
            }
            timeLag -= Time.deltaTime;
            if (timeLag < 0)
            {
                if (PlayLongRangeStrike)
                {
                    ShootAtTarget();
                }
                //Debug.Log(m_Animator);
                m_Animator.SetTrigger(m_Skill);
               
                SetTimeLag();
            }
          
        }
        /// <summary>
        /// 设置下一次射击的延时
        /// </summary>
        private void SetTimeLag()
        {
            if (currentAttackMode == AttackMode.Orderly)
            {
                timeLag = timeLagRecorderMin;
            }
            else
            {
                timeLag = Random.Range(timeLagRecorderMin, timeLagRecorderMax);
            }
        }

        /// <summary>
        /// 远程攻击向目标发射炮弹
        /// </summary>
        private void ShootAtTarget()
        {
            if (bulletPrefab)
            {
                currentBullet=Instantiate(bulletPrefab, m_brain.transform.position+fixHight, Quaternion.identity);

                if (m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.tag=="Player")
                {
                    Vector3 _PlayerHeadPos = m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position;
                    currentBullet.transform.forward = _PlayerHeadPos - m_brain.transform.position + fixHight;
                    _PlayerHeadPos.y =m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.transform.position.y+ m_brain.m_SensorManager.m_SensorData.m_EnemyTarget.GetComponent<CapsuleCollider>().height-0.5f;
                    Vector3 _TargetVelocity = (_PlayerHeadPos- currentBullet.transform.position).normalized * bulletSpeed;
                    currentBullet.GetComponent<Rigidbody>().velocity = _TargetVelocity;
                    currentBullet.GetComponent<Damager>().BeginDamage();
                    Destroy(currentBullet, 5f);
                }
               
                //currentBullet.GetComponent<DestoryBullet>().InvokeDestoryBullet(currentBullet);

            }
        }
        
    }
}

