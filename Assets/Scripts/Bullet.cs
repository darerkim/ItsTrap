using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이팩트")]
    [SerializeField] GameObject go_RicochetEffect;

    [Header("총알 데미지")]
    [SerializeField] int demage;

    [Header("피격 효과음")]
    [SerializeField] string sound_Ricochet;

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        SoundManager.instance.PlaySE(sound_Ricochet);
        var clone = Instantiate(go_RicochetEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));

        if (other.transform.CompareTag("Mine"))
        {
            other.transform.GetComponent<Mine>().Demaged(demage);
        }

        Destroy(clone, 0.5f);
        Destroy(gameObject);
    }
}
