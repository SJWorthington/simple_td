using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveBasicTurret : MonoBehaviour
{
    [SerializeField] private float shotCooldown;
    [SerializeField] private int range;
    private float timeSinceShot;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int shotForce;

    private GameObject targetEnemy;

    private bool HasEnemyTarget => targetEnemy != null && targetEnemy.gameObject.activeInHierarchy;

    // Update is called once per frame
    void Update()
    {
        timeSinceShot += Time.deltaTime;
        targetEnemy = SelectNearestTarget();
        if (timeSinceShot > shotCooldown && HasEnemyTarget)
        {
            timeSinceShot = 0;
            FireAtTarget();
        }
    }

    private GameObject SelectNearestTarget()
    {
        //TODO - this can absolutely be optimised
        var enemiesInRange = FindObjectsOfType<Enemy>().ToList()
            .Where(enemy => Vector2.Distance(transform.position, enemy.transform.position) < range).ToList();

        if (enemiesInRange.Count == 0)
        {
            return null;
        }

        return enemiesInRange
            .OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position)).First()?.gameObject;
    }

    private void FireAtTarget()
    {
        var bullet = Instantiate(bulletPrefab);
        var aimAngle = GetAngleToEnemy();
        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        bullet.transform.position = this.transform.position;
        //bullet.GetComponent<StandardBullet>().fire(aimDirection, launchForce);
        bullet.GetComponent<Rigidbody2D>().AddForce(aimDirection * shotForce);
    }

    private float GetAngleToEnemy()
    {
        var relativeVector = (Vector2) targetEnemy.transform.position - (Vector2) transform.position;

        var angle = Mathf.Atan2(relativeVector.y, relativeVector.x);
        if (angle < 0f)
        {
            angle += Mathf.PI * 2;
        }

        return angle;
    }
}