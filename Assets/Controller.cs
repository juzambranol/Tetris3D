using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public static  float _timer;
    public float[] _droptimer=new float[]{
        0.2f,0.4f,0.6f,0.8f,1.0f,1.2f,1.4f,1.6f,1.8f,2.0f
    };
    void Start()
    {
        _timer=_droptimer[9];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
