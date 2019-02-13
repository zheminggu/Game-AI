using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnmi : MonoBehaviour {
    private Animator anim;
    private float time = 3f;
    private float changeTime = 5f;
    private int cnt = 0;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        time = changeTime;
	}
	
	// Update is called once per frame
	void Update () {
      
	}
}
