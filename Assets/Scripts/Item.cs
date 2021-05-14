using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Score,
        NormalGun_Bullet,
    }

    public ItemType itemType;
    public int extraScore; //추가 점수
    public int extraBullet; //추가 획득 총알

    private void Update()
    {
        if (itemType == ItemType.NormalGun_Bullet)
        {
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime); 
        }
    }

}
