using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHp;
    int currentHp;

    [SerializeField] Text[] txt_HpArray;

    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCound;
    [SerializeField] MeshRenderer mesh_PlayerGraphics;

    bool isInvincibleMode = false;

    private void Start()
    {
        currentHp = maxHp;
        UpdateHpStatus();
    }

    void UpdateHpStatus()
    {
        for (int i = 0; i < txt_HpArray.Length; i++)
        {
            if (i < currentHp)
                txt_HpArray[i].gameObject.SetActive(true);
            else
                txt_HpArray[i].gameObject.SetActive(false);
        }
    }

    public void DecreaseHP(int _num)
    {
        if (!isInvincibleMode)
        {
            currentHp -= _num;
            UpdateHpStatus();
            if (currentHp <= 0)
                PlayerDead();
            SoundManager.instance.PlaySE("Hurt");
            StartCoroutine(BlinkCoruoutine());
        }
    }

    public void IncreaseHP(int _num)
    {
        if (currentHp == maxHp)
            return;

        currentHp += _num;

        if (currentHp > maxHp)
            currentHp = 3;

        UpdateHpStatus();
    }

    IEnumerator BlinkCoruoutine()
    {
        isInvincibleMode = true;
        for (int i = 0; i < blinkCound * 2; i++)
        {
            mesh_PlayerGraphics.enabled = !mesh_PlayerGraphics.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        isInvincibleMode = false;
    }

    void PlayerDead()
    {
        SceneManager.LoadScene("Title");
    }

}
