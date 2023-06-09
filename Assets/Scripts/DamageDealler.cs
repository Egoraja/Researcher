using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthSetting>().GotDamage(damage);
        }
        Destroy(gameObject);
    }
}
