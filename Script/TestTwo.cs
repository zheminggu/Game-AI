using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTwo : MonoBehaviour {
    private TestOne testOne;//测试testone
	// Use this for initialization
	void Start () {
        testOne = GetComponent<TestOne>();//获取testone组件
 
        testOne.ExampleFunction(10);//调用testone中的函数
	}
	
	// Update is called once per frame
	void Update () {
        testOne.m_Example = 20;//给testone中的example赋值
    }
}
