using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody BulletRigidbody;
    public Transform newBulletTransform;
    public float speed = 100f;
    public float bulletReloadTime = 0.1f;
    public float magazineReloadTime = 1.5f;
    public bool reloadBullet = false;
    public int numberOfBulletsFired = 0;
    public int magazineSize = 30;


    private IEnumerator AfterShoot()
    {
        if (numberOfBulletsFired == magazineSize)
        {
            yield return new WaitForSeconds(magazineReloadTime);
            numberOfBulletsFired = 0;
        }
        else
        {
            yield return new WaitForSeconds(bulletReloadTime);
        }

        reloadBullet = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !reloadBullet)
        {
            Shoot();
            StartCoroutine(AfterShoot());
        }
    }

    void Shoot()
    {
        reloadBullet = true;
        numberOfBulletsFired++;
        GameObject newBullet = Instantiate(
            bullet, newBulletTransform.position, newBulletTransform.rotation);
        BulletRigidbody = newBullet.GetComponent<Rigidbody>();
        // Debug.Log(newBulletTransform.position);
        BulletRigidbody.AddForce(newBulletTransform.transform.forward * speed, ForceMode.Impulse);
    }
}
