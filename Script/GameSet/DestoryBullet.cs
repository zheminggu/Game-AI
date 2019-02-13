using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI {
    public class DestoryBullet : MonoBehaviour
    {
        [SerializeField]
        [Tooltip ("摧毁子弹延时")]
        private float destoryInterval = 3f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                OnDestroyBullet();
            }
           // Destroy(gameObject);
        }
        public void InvokeDestoryBullet(GameObject _gameObject)
        {
            Invoke("OnDestroyBullet", destoryInterval);
        }
        private void OnDestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}


