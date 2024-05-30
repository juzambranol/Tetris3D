using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D[] _colorTextures;
    public Renderer[] _renderer;
    public Texture _mainTexture;
    void Start()
    {
        _renderer= GetComponentsInChildren<Renderer>();
        Texture2D _rTexture = _colorTextures[Random.Range(0,_colorTextures.Length)];
        _mainTexture = _rTexture;
        foreach(Renderer _auxRender in _renderer){
            _auxRender.material.SetTexture("_MainTex",_mainTexture);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
