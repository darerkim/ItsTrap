using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

    [SerializeField] Gun currentGun;
    [SerializeField] Text txt_CurrentGunBullet;

    float currentFireRate;
    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = 0;
        BulletUiSetting();
    }

    public void BulletUiSetting()
    {
        txt_CurrentGunBullet.text = "x " + currentGun.bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();
    }

    void FireRateCalc()
    {
        if (currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
    }

    void TryFire()
    {
        if (Input.GetButton("Fire1") && currentGun.bulletCount > 0 && PlayerController.canMove)
        {
            if (currentFireRate <= 0)
            {
                Fire();
                currentFireRate = currentGun.fireRate;
            }
        }
    }

    void Fire()
    {
        --currentGun.bulletCount;
        BulletUiSetting();
        currentGun.animator.SetTrigger("GunFire");
        SoundManager.instance.PlaySE(currentGun.sound_Fire);
        currentGun.ps_MuzzleFlash.Play();
        GameObject clone = Instantiate(currentGun.go_Bullet_Prefab, currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed); 

    }

    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }

}