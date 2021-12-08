using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermanager : MonoBehaviour
{
    private MeshFilter _meshFilter;
    public WaveManager _WaveManager;
    public GameObject _Worldgenerator;
    private bool fistUpdate;

    private void Awake()
    {
        fistUpdate = false;
        _meshFilter = this.GetComponent<MeshFilter>();
        _WaveManager = _Worldgenerator.GetComponent<WaveManager>();




    }
    private void Update()
    {
       



       // Vector3[] vertices = _meshFilter.mesh.vertices;
       // for (int i = 0; i < vertices.Length; i++)
       // {
       //     vertices[i].y = _WaveManager.GetWaveHight(transform.position.x + vertices[i].x);
       //     //Debug.Log(transform.position.x + vertices[i].x);

       // }
       //_meshFilter.mesh.vertices = vertices;
       //_meshFilter.mesh.RecalculateNormals();

    }
}
