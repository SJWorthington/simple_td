using System.Collections.Generic;
using UnityEngine;

public class RadiusTurret : MonoBehaviour
{
    [SerializeField] private float shotCooldown;
    [SerializeField] private int shotRange;
    private float timeSinceShot;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int shotForce;

    private List<Vector2> vectors;

    private void Start()
    {
        vectors = new List<Vector2>
        {
            new(0, -1),
            new(1, -1),
            new(1, 0),
            new(1, 1),
            new(0, 1),
            new(-1, 1),
            new(-1, -1),
            new(-1, 0),
            new(-1, -1),
        };
    }


    // Update is called once per frame
    void Update()
    {
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot > shotCooldown)
        {
            timeSinceShot = 0;
            fireShot();
        }
    }

    private void fireShot()
    {
        foreach (var shotDir in vectors)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<RangedBullet>().SetRangeParams(
                shotRange,
                transform.position
            );
            bullet.GetComponent<Rigidbody2D>().AddForce(shotDir * shotForce);
        }
    }
}