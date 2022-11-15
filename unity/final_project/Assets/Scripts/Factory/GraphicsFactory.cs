using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsFactory : MonoBehaviour
{
    public GameObject GridCell;
    public GameObject City;
    public GameObject Melee;
    public GameObject Ranged;
    public GameObject Airborne;

    public GameObject CreateGraphicalObject(int type, int[] coords_, Color color_)
    {
        GameObject prefab = null;
        string newName = null;

        switch (type)
        {
            case 0: prefab = GridCell; newName = "GridCell_" + string.Join("-", coords_); break;
            case 1: prefab = City; newName = "city_" + string.Join("-", coords_); break;
            case 2: prefab = Melee; newName = "melee_" + string.Join("-", coords_); break;
            case 3: prefab = Ranged; newName = "ranged_" + string.Join("-", coords_); break;
            case 4: prefab = Airborne; newName = "airborne_" + string.Join("-", coords_); break;
        }

        // find a way to change material color


        Vector3 vec = new Vector3(coords_[0], coords_[1], coords_[2]);
        GameObject newObject = GameObject.Instantiate(prefab);
        newObject.transform.Translate(vec, Space.World);
        newObject.name = newName;
        newObject.transform.SetParent(this.transform);
        newObject.SetActive(true);

        return newObject;
    }
}
