using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float _amplitude = 2f;
    public float _length = 0.5f;
    public float _speed = 0.5f;
    public float _offset = 1;

    public static WaveManager instance;
    private float _noiseWalk;
    private float _noiseStrength;

    private void Awake()
    {
        Debug.Log("Instance already exists, destroing object!");
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroing object!");
            Destroy(this);
        }
        
    }
    private void Update()
        {
        _offset += Time.deltaTime * _speed;
        
            Shader.SetGlobalFloat("_WaterScale", _amplitude);
            Shader.SetGlobalFloat("_WaterSpeed", _speed);
            Shader.SetGlobalFloat("_WaterDistance", _length);
            Shader.SetGlobalFloat("_WaterTime", Time.time);
            Shader.SetGlobalFloat("_WaterNoiseStrength", _noiseStrength);
            Shader.SetGlobalFloat("_WaterNoiseWalk", _noiseWalk);
        


    }
    public float GetWaveHight(float _x)
    {

        return _amplitude * Mathf.Sin((_x / _length) + _offset);

    }
}
