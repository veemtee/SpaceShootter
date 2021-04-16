using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public ShootProfile shootProfile;

    private float totalSpread;
    private WaitForSeconds rate, interval;


    // Start is called before the first frame update
    void OnEnable ()
    {
        interval = new WaitForSeconds(shootProfile.interval);
        rate = new WaitForSeconds(shootProfile.firerate);

        if (bulletSpawn == null)
            bulletSpawn = transform;

        totalSpread = shootProfile.spread * shootProfile.amount;

        StartCoroutine(ShootingSequence());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator ShootingSequence()
    {
        yield return rate;

        while (true)
        {
            float angle = 0f;

            if(shootProfile.amount > 1)
            {
                for (int i = 0; i < shootProfile.amount; i++)
                    {
                    angle = totalSpread * (i / (float)shootProfile.amount);
                    //angle -= (totalSpread / 2f);

                    Shoot(angle);

                    if (shootProfile.firerate > 0)
                    yield return rate;
                    }
            }

            yield return interval;
        }
    }

    void Shoot(float angle)
    {
        GameObject temp = PoolingManager.poolingInstance.UseObject(bullet, bulletSpawn.position, bulletSpawn.rotation);
        temp.name = shootProfile.damage.ToString();
        temp.transform.Rotate(Vector3.up, angle);
    }
}
