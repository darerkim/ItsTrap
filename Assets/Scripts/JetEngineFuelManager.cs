using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetEngineFuelManager : MonoBehaviour
{
    [SerializeField] float maxFuel; //최대 연료
    float currentFuel; //현재 연료

    [SerializeField] Slider slider_JetEngine;
    [SerializeField] Text txt_JetEngine;

    [SerializeField] float waitRechargeFuel;
    float currentwaitRechargeFuel;
    [SerializeField] float rechargeSpeed;

    public bool IsFuel;

    PlayerController thePC;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = currentFuel;
        thePC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UsedFuel();
        CheckFuel();

        slider_JetEngine.value = currentFuel;
        txt_JetEngine.text = Mathf.Round((currentFuel / maxFuel * 100f)).ToString() + " %";
    }

    void FuelRecharge()
    {
        if (currentFuel < maxFuel)
        {
            currentwaitRechargeFuel += Time.deltaTime;
            if (currentwaitRechargeFuel >= waitRechargeFuel)
            {
                currentFuel += Time.deltaTime * rechargeSpeed;
            }
        }
        else
        {
            slider_JetEngine.gameObject.SetActive(false);
        }
    }

    void CheckFuel()
    {
        if (currentFuel > 0)
            IsFuel = true;
        else
            IsFuel = false;
    }

    void UsedFuel()
    {

        if (thePC.IsJet)
        {
            slider_JetEngine.gameObject.SetActive(true);
            currentFuel -= Time.deltaTime;
            currentwaitRechargeFuel = 0;
            if (currentFuel <= 0)
                currentFuel = 0;
        }
        else
        {
            FuelRecharge();
        }
    }
}
