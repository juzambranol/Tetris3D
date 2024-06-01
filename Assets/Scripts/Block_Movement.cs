using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Movement : MonoBehaviour
{
    public Vector3 _position;
    public float _movePause;
    public float _horizonalMoveInput;
    public float _verticalMoveInput;
    public bool _movingHorizontally;
    public Quaternion _rotation;
    public bool _lockPosition;
    public bool _rotateButtonPressed;
    public float _rotateXInput;
    public float _rotateYInput;
    public float _rotateZInput;

    public Rigidbody _rigidbody;

    public int _xPosition;
    public int _zPosition;
    public int _negative=-1;
    public int _positive=+1;   

    public int _SetPosNegX;
    public int _SetPosNegZ;
    public string AxisDown;
    public int dirDown;

    // Start is called before the first frame update
    void Start()
    {
        _movingHorizontally=false;
        _lockPosition=false;
        _rotation=Quaternion.Euler(0,0,0);
        _position= transform.position; //Set equal to gameObject position
        _movePause=GameManager._timer; //a
        
    }

    // Update is called once per frame
    void Update()
    {   
        CountDown();
        
        

    }
    private void MoveBlock(){
        Debug.Log("Moving Block");
        if(_lockPosition==true){
            return;
        }
        RotateBlockVertical();
        RotateBlockHorizontal();
        MoveBlockHorizontally();
        MoveBlockVertical();
        
        if(Mathf.Abs(transform.position.y) <= 0.01f){
            FreezeConstraints();
            return;
        }
        if(_movingHorizontally==true){
            return;
        }
        _position= transform.position;
        moveDownBlock();
        _position.y-=1;
        transform.position=_position;
    }
    private void CountDown(){
        Debug.Log("Counting Down");
        _movePause -= GameManager._timer * Time.deltaTime;
        if(_movePause<0){
            _movePause=0;
        }
        if(_movePause==0 && _movingHorizontally==true){
            
            _movePause=GameManager._timer;
            _movingHorizontally=false;
        }
        if (_movePause==0){
            MoveBlock();
            _movePause=GameManager._timer;
            
        }
    }
    private void moveDownBlock(){


    }
    public void MoveBlockHorizontally(){
        Debug.Log("Moving Block Horizontally");
        _horizonalMoveInput = Input.GetAxis("MoveHorizontal");

        
        if(_horizonalMoveInput>0 && _movePause==0){
            _SetPosNegX = _positive;
            _xPosition= (int)Mathf.Clamp(_position.x+_SetPosNegX,-4,+4);
            _movingHorizontally=true;

            _position= transform.position;
            _position.x+=1;
            transform.position=_position;
        }
        if(_horizonalMoveInput<0 && _movePause==0){
            _SetPosNegX = _negative;
            _xPosition= (int)Mathf.Clamp(_position.x+_SetPosNegX,-4,+4);
            _movingHorizontally=true;
            _position= transform.position;
            _position.x=_xPosition;
            transform.position=_position;
        }
    }
    public void MoveBlockVertical(){
        Debug.Log("Moving Block Verticallly");
        _verticalMoveInput = Input.GetAxis("MoveVertical");
        
        if(_verticalMoveInput>0 && _movePause==0){
            _SetPosNegZ = _positive;
            _zPosition= (int)Mathf.Clamp(_position.z+_SetPosNegZ,-4,+4);
            _movingHorizontally=true;
            _position= transform.position;
            _position.z=_zPosition;
            transform.position=_position;
        }
        if(_verticalMoveInput<0 && _movePause==0){
            _SetPosNegZ = _negative;
            _zPosition= (int)Mathf.Clamp(_position.z+_SetPosNegZ,-4,+4);
            _movingHorizontally=true;
            _position= transform.position;
            _position.z=_zPosition;
            transform.position=_position;
        }
    }
    public void RotateBlockVertical(){
        Debug.Log("Rotating Block Vertically");
    _rotateXInput=Input.GetAxis("RotateVertical");
    if(_rotateXInput>0 && _movePause==0){
            transform.Rotate(transform.position.x+90,0,0,Space.Self);
        }
        if(_rotateXInput<0 && _movePause==0){
            transform.Rotate(transform.position.x-90,0,0,Space.Self);
        }
    }
    public void RotateBlockHorizontal(){
        Debug.Log("Rotating Block Horizontal");
    _rotateYInput=Input.GetAxis("RotateHorizontal");
    if(_rotateYInput>0 && _movePause==0){
            transform.Rotate(0, 0,90, Space.Self);
        }
        if(_rotateYInput<0 && _movePause==0){
            transform.Rotate(0,0,- 90,Space.Self);
        }
    }
    private void OnCollisionEnter(Collision collision){

        
        FreezeConstraints();
    }
    public void FreezeConstraints(){
        Debug.Log("Freezing Constraints");
        CreateBlock._createNewBlock=true;
        _lockPosition=true;
        _rigidbody=GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Block_Movement>().enabled=false;
    }
}
