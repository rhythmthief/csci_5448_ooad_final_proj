using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour
{
    public GameObject cube;

    public void CreateCube(int[] xyz)
    {
        Vector3 vec = new Vector3(xyz[0], xyz[1], xyz[2]);
        GameObject newCube = GameObject.Instantiate(cube);
        newCube.transform.Translate(vec, Space.World);
        newCube.SetActive(true);
    }

    void Start()
    {
        //CreateCube(0,0,0);
    }
}
