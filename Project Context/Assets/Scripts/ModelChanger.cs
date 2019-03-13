using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChanger : MonoBehaviour
{
    public MeshFilter CurrentMesh;

    public List<Mesh> Meshes;

    private int MeshNumber;

    private void Start()
    {
        CurrentMesh = GetComponent<MeshFilter>();
        MeshNumber = 0;
    }

    public void ChangeMesh()
    {
        if(MeshNumber < Meshes.Count - 1)
        {
            MeshNumber++;
            CurrentMesh.mesh = Meshes[MeshNumber];
        }
        else
        {
            return;
        }
    }
}
