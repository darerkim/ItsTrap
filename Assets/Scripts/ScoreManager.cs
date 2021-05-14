using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int currentScore;
    // 앞에 퍼블릭을 붙여도 돼지만 타함수로부터의 변수접근을 최소화 하기 위해서 함수를 만들어주자.
    public int GetCurretScore() { return currentScore; }
    public void ResetCurrentScore() { currentScore = 0; distanceScore = 0; maxDistance = 0; extraScore = 0; }
    int distanceScore;
    public static int extraScore;  //item score
    float maxDistance;
    float originPosZ;

    [SerializeField] Transform tf_Player; //information of player's location;
    [SerializeField] Text txt_Score;

    void Start() 
    {
        originPosZ = tf_Player.transform.transform.transform.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (tf_Player.position.z > maxDistance)
        {
            maxDistance = tf_Player.position.z;
            distanceScore = Mathf.RoundToInt(maxDistance - originPosZ);
        }
        currentScore = extraScore + distanceScore;
        txt_Score.text = string.Format("{0:000,000}", currentScore);
    }
}
