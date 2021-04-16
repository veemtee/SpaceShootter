using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootProfile", menuName = "Shooting profile", order = 1)]


public class ShootProfile : ScriptableObject
{
    public float speed;
    public float damage;
    public float firerate;
    public float interval;
    public float destroyRate;
    public float spread;

    public int amount;

}
