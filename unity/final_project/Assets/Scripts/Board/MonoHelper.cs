using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHelper : MonoBehaviour
{
    // Some Unity functionality is very stubborn and requires inheritance from MonoBehavior
    // this script acts as a helper for code sections that don't inherit mono, but still need
    // to perform related tasks

    public void DestroyObjectHelper(GameObject obj)
    {
        Destroy(obj);
    }

}
