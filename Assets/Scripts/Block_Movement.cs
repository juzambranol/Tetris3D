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

    // Start is called before the first frame update
    void Start()
    {
        _movingHorizontally=false;
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
        MoveBlockHorizontally();
        RotateBlockVertical();
        if(_movingHorizontally==true){
            return;
        }
        _position= transform.position;
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
    public void MoveBlockHorizontally(){
        Debug.Log("Moving Block Horizontally");
        _horizonalMoveInput = Input.GetAxis("MoveHorizontal");
        if(_horizonalMoveInput>0 && _movePause==0){
            _movingHorizontally=true;
            _position= transform.position;
            _position.x+=1;
            transform.position=_position;
        }
        if(_horizonalMoveInput<0 && _movePause==0){
            _movingHorizontally=true;
            _position= transform.position;
            _position.x-=1;
            transform.position=_position;
        }
    }
    public void RotateBlockVertical(){
        Debug.Log("Rotating Block Vertically");
    _verticalMoveInput=Input.GetAxis("MoveVertical");
    if(_verticalMoveInput>0 && _movePause==0){
            transform.Rotate(transform.position.x+90,0,0,Space.Self);
        }
        if(_verticalMoveInput<0 && _movePause==0){
            transform.Rotate(transform.position.x-90,0,0,Space.Self);
        }
    }
}
