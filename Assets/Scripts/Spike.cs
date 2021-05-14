using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] int demage;
    [SerializeField] float force;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log(demage + "를 입혔습니다.");
            other.transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5f);
            other.rigidbody.GetComponent<StatusManager>().DecreaseHP(demage);
        }
    }
}
