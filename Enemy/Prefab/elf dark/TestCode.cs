using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour {
    private Animator animator;
    private float timer=3f;
    private float recordTimer = 3f;
	// Use this for initialization初始化
    //在代码一开始运行的时候会调用这个函数
	void Start () {
        animator = GetComponent<Animator>();//获得当前gameobject的组件
        animator.SetFloat("Speed", 1);//让他走起来
	}
	
	// Update is called once per frame（帧）
    //游戏运行的时候每一帧都会调用
	void Update () {
        timer -= Time.deltaTime;
        //延时触发3s
        if (timer<0)
        {
            //animator.SetBool("MyAttack", true);

            Invoke("TurnFalse", 2f);//延时调用函数
            animator.SetTrigger("Attack");//set trigger equals to true
            //执行完以后会自动弹回去
            timer = recordTimer;
            return;
        }
        
	}
    void TurnFalse()
    {
        animator.SetBool("MyAttack", false);
    }
}
