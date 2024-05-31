using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static  float _timer;
    public static int _screenWidthOffset;
    public static int _screenHeightOffset;
    public static int _playerGUIFontSize;
    public float[] _droptimer=new float[]{
        0.2f,0.4f,0.6f,0.8f,1.0f,1.2f,1.4f,1.6f,1.8f,2.0f
    };
    void Start()
    {
        _timer=_droptimer[9];
       UpdateSettings();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSettings(); //Testing
    }
    private void UpdateSettings(){
        _screenWidthOffset=(int)(Screen.width/70);
        _screenHeightOffset=(int)(Screen.width/40);
        _playerGUIFontSize=(int)(Screen.width/40);
    }
}
