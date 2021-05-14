using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_CurrentScore;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManager theSM;
    [SerializeField] Rigidbody playerRigid;
    [SerializeField] GameObject[] go_Stages;
    [SerializeField] Transform tf_originPos;
    int currentStage = 0;
     
    public void ShowClearUI()
    {
        go_UI.SetActive(true);
        playerRigid.isKinematic = true;
        PlayerController.canMove = false;
        txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurretScore());
    }

    public void NextBtn()
    {
        if (currentStage < go_Stages.Length - 1)
        {
            theSM.ResetCurrentScore();
            go_UI.SetActive(false);
            playerRigid.isKinematic = false;
            playerRigid.transform.position = tf_originPos.position;
            if (currentStage > go_Stages.Length) return;
            go_Stages[currentStage++].SetActive(false);
            go_Stages[currentStage].SetActive(true);
            PlayerController.canMove = true;
        }
        else
        {
            Debug.Log("모든 스테이지를 클리어 함");
        }
    }
}
