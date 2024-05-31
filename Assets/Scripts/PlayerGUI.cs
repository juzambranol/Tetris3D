using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public GUISkin _playerGUISkin;
    public GUIStyle _playerGUIStyle;
    public Texture2D _guiBorder;
    public Texture2D _guiBackground;
    // Start is called before the first frame update
    void Start()
    {
        _playerGUISkin=(GUISkin) (Resources.Load("GUISkin"));
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GUI.Label(
            new Rect(0,0
            ,Screen.width / 5.1f,Screen.height / 4.5f),
            "Next Block", _playerGUIStyle
        );
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
