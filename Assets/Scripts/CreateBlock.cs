using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{   
    public string _currentBlock; //Next block
    public static string _nextBlock;
    public GameObject _block; //Current block
    public static int _TOP=10; //Spawn high

    public static bool _createNewBlock; //Create new block 

    
    public string[] _blockshapes= new string[]{ //Shapes of blocks
        "Block-I","Block-J","Block-L","Block-O","Block-S","Block-T","Block-Z"
    };

    // Start is called before the first frame update
    void Start()
    {
        _currentBlock ="";
        _nextBlock ="";
        _block = null;
        _createNewBlock=false;
        if(_nextBlock==null){
            _nextBlock= _blockshapes[Random.Range(0,_blockshapes.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_block==null){ //Needs new block
            getNextBlock();
        }

        if(_createNewBlock==true){
            getNextBlock();
            _createNewBlock=false;
        }

        if(Input.GetKeyDown("b")){ //Delete this
            Destroy(_block);
            getNextBlock();
        }
    }
    private void getNextBlock(){
        if(_nextBlock!=null){
            _currentBlock= _nextBlock;
        }
        spawnBlock();
        _nextBlock=_blockshapes[Random.Range(0,_blockshapes.Length)]; //Create new random block

        PlayerGUI _playerTempGUI= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerGUI>();
        _playerTempGUI.SetNextBlockGUI();
    }
    private void spawnBlock(){
        if(_currentBlock!=null && _currentBlock!=""){
            _block=Instantiate(Resources.Load(_currentBlock),new Vector3(0,10,0),Quaternion.identity) as GameObject;
        }

         
    }
}
