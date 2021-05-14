using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    GunController theGC;

    const int NORMAL_GUN = 0;

    void Start()
    {
        theGC =  FindObjectOfType<GunController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();

            int extra = 0;

            if (item.itemType == Item.ItemType.Score)
            {
                SoundManager.instance.PlaySE("Score");
                extra = item.extraScore;
                ScoreManager.extraScore += extra;
                Destroy(other.gameObject);
            }
            else if (item.itemType == Item.ItemType.NormalGun_Bullet)
            {
                SoundManager.instance.PlaySE("Bullet");
                extra = item.extraBullet;
                guns[NORMAL_GUN].bulletCount += extra;
                theGC.BulletUiSetting();
                Destroy(other.gameObject);
            }
            string message = "+" + extra;

            FloatingTextManager.instance.CreateFloatingText(other.transform.position, message);
        }
    }
}
