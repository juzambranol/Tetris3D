using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{   
    public string _nextBlock; //Next block
    public GameObject _block; //Current block
    public static int _TOP=10; //Spawn high
    public string[] _blockshapes= new string[]{ //Shapes of blocks
        "Block-I","Block-J","Block-L","Block-O","Block-S","Block-T","Block-Z"
    };

    // Start is called before the first frame update
    void Start()
    {
        _nextBlock ="";
        _block = null;

    }

    // Update is called once per frame
    void Update()
    {
        if(_block==null){ //Needs new block
            getNextBlock();
        }
        if(Input.GetKeyDown("b")){ //Delete this
            Destroy(_block);
            getNextBlock();
        }
    }
    private void getNextBlock(){
        _nextBlock=_blockshapes[Random.Range(0,_blockshapes.Length)]; //Create new random block
        spawnBlock();
    }
    private void spawnBlock(){
         _block=Instantiate(Resources.Load(_nextBlock),new Vector3(0,10,0),Quaternion.identity) as GameObject;
        
        
    }
}
