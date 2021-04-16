using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager poolingInstance;

    private void Awake()
    {
        poolingInstance = this;
    }

    public GameObject UseObject(GameObject obj, Vector3 pos, Quaternion rot)
    {
        return Instantiate(obj, pos, rot);
    }

    public void ReturnObject(GameObject obj)
    {
        Destroy(obj);
    }
}
