using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public GUISkin _playerGUISkin;
    public GUIStyle _playerGUIStyle;
    public Texture2D _guiBorder;
    public Texture2D _guiBackground;

    public Texture2D _IShape;
    public Texture2D _JShape;
    public Texture2D _LShape;
    public    Texture2D _OShape;
    public Texture2D _SShape;
    public Texture2D _TShape;
    public Texture2D _ZShape;
    public Texture2D _nextBlockShape;

    // Start is called before the first frame update
    void Start()
    {
        _playerGUISkin=(GUISkin) (Resources.Load("GUISkin"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextBlockGUI(){
        Debug.Log("Setting Next Block");
        if(CreateBlock._nextBlock=="Block-I"){
            _nextBlockShape=_IShape;
        }
        if(CreateBlock._nextBlock=="Block-J"){
            _nextBlockShape=_JShape;
        }
        if(CreateBlock._nextBlock=="Block-L"){
            _nextBlockShape=_LShape;
        }
        if(CreateBlock._nextBlock=="Block-O"){
            _nextBlockShape=_OShape;
        }
        if(CreateBlock._nextBlock=="Block-S"){
            _nextBlockShape=_SShape;
        }
        if(CreateBlock._nextBlock=="Block-T"){
            _nextBlockShape=_TShape;
        }
        if(CreateBlock._nextBlock=="Block-Z"){
            _nextBlockShape=_ZShape;
        }
    }
    public void OnGUI(){
        _playerGUIStyle= _playerGUISkin.label;
        _playerGUIStyle.font=(Font) (Resources.Load("ARCADECLASSIC"));
        _playerGUIStyle.fontSize= GameManager._playerGUIFontSize;
        _playerGUIStyle.alignment= TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(0,0,Screen.width,Screen.height));
        GUI.DrawTexture( //Draw Border
            new Rect(0 + GameManager._screenWidthOffset
            ,0 + GameManager._screenHeightOffset
            ,Screen.width-(GameManager._screenWidthOffset*2),
            Screen.height-(GameManager._screenHeightOffset*2)
            ),_guiBorder
        );
        //Draw Background
        GUI.DrawTexture( //Draw Border
            new Rect(0 + GameManager._screenWidthOffset
            ,0 + GameManager._screenHeightOffset
            ,Screen.width-(GameManager._screenWidthOffset*2),
            Screen.height-(GameManager._screenHeightOffset*2)
            ),_guiBackground
        );

        //Lefts Side
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 5.1f,Screen.height / 4.5f),
            "Next Block", _playerGUIStyle
        );
        if(_nextBlockShape==_IShape || _nextBlockShape==_LShape || _nextBlockShape== _JShape){
            GUI.DrawTexture(
            new Rect(
                0+(GameManager._screenWidthOffset*5) ,
                0+(GameManager._screenHeightOffset*3),
            Screen.width / 14f,Screen.height / 6f),
            _nextBlockShape
        );
        }else{
            GUI.DrawTexture(
            new Rect(
                0+(GameManager._screenWidthOffset*5) ,
                0+(GameManager._screenHeightOffset*3),
            Screen.width / 14f,Screen.height / 12f),
            _nextBlockShape
        );
        }
        
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 5.1f,Screen.height / 1.5f),
            "Held Block", _playerGUIStyle
        );
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 5.1f,Screen.height / 0.8f),
            "Speed", _playerGUIStyle
        );
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 5.1f,Screen.height / 0.7f),
            "Lines", _playerGUIStyle
        );

        //Right Side
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 0.55f,Screen.height / 4.5f),
            "Score", _playerGUIStyle
        );
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 0.55f,Screen.height / 1.5f),
            "Time", _playerGUIStyle
        );
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 0.55f,Screen.height / 0.8f),
            "Hi-Score", _playerGUIStyle
        );
        GUI.EndGroup();
    }
}
