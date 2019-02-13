using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个类描述了一个例子
/// </summary>
public class TestOne : MonoBehaviour {
    /// <summary>
    /// 这是一个例子
    /// </summary>
    ///<remarks> 
    ///get表示可访问，set表示可赋值
    /// </remarks>
    public int m_Example { get { return example; }set { example = value; } }

     [SerializeField]
    private int example;//这是我私有的例子

    [SerializeField]
    private int anotherExample=20;//这是另一个私有的例子

	// Use this for initialization
	void Start () {
        example = 10;	
	}

    /// <summary>
    /// 函数例子
    /// </summary>
    /// <param name="_Example"> 变量</param>
    public void ExampleFunction(int _Example)
    {
        anotherExample = _Example;//赋值给另一个例子
    }
}
