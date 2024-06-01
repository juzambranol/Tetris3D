using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public Transform[] _individualBlocks;
    public Vector3[] _individualBlockPositions;
    // Start is called before the first frame update
    void Start()
    {
        _individualBlocks= GetComponentsInChildren<Transform>();
        _individualBlockPositions=new Vector3[_individualBlocks.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate(){
        for (int i = 1; i < _individualBlocks.Length; i++)
            {
                _individualBlockPositions[i] = _individualBlocks[i].transform.position;
            }
    }
}
