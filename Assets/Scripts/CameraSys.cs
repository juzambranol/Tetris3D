using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSys : MonoBehaviour
{
    public Vector3  _camPivotPoint;
    public int _gameHeight;
    public int _cameraHeightPoint;

    public float _horSpeed=100f; //Horizontal Speed
    public float _verSpeed=10f;
    public float _horInput;
    public float _verInput;

    public Vector3 _camStartPos;
    public Vector3 _camStartRot;
    // Start is called before the first frame update
    void Start()
    {
        _gameHeight=20;
        _cameraHeightPoint=_gameHeight/2;
        _camPivotPoint=new Vector3(0,_cameraHeightPoint,0);
        _camStartPos=new Vector3(0,15,-10);
        transform.position=_camStartPos;
        _camStartRot=new Vector3(25,0,0);
        transform.rotation=Quaternion.Euler(_camStartRot);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            
        }
        _horInput= _horSpeed * Input.GetAxis("CamHorizontal");
            transform.RotateAround(_camPivotPoint,Vector3.up,_horInput*Time.deltaTime);
            _verInput= _verSpeed * Input.GetAxis("CamVertical"); 
            //transform.RotateAround(_camPivotPoint,Vector3.forward,_verInput*Time.deltaTime); 
            transform.Translate(Vector3.up * (_verInput * Time.deltaTime),Space.World);
    }
}
