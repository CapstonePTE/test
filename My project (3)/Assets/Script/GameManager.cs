using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public int health;
    public int maxhp = 4;
    public CharacterController player;
    public GameObject[] stages;

    public GameObject[] UIhealth;
    public GameObject RestartBtn;




    public void Nextstage()
    {
        //스테이지 바꾸기
        if (stageIndex < stages.Length - 1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else //게임 클리어
        {
            Time.timeScale = 0;

            Debug.Log("게임 클리어");

            //재시작 버튼
            RestartBtn.SetActive(true);
        }
    }
    //재시작버튼을 눌렀을 때
    public void ReStart()
    {
        health = maxhp;
        PlayerReposition();
        RestartBtn.SetActive(false);
        HealthRecover();
        Time.timeScale = 1.0f;

    }

    //체력회복(재시작버튼 눌렀을때)
    public void HealthRecover()
    {
        for (int i = 0; i < maxhp; i++)
        {
            UIhealth[i].SetActive(true);
        }

    }

    // 피격으로 인한 체력수치와 UI 체력칸 변경
    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].SetActive(false);
            Debug.Log("체력이 1 감소했습니다.");

        }

        //체력이 0이 되어버린 경우
        else
        {
            health--;
            UIhealth[health].SetActive(false);
            Debug.Log("게임오버");
            Time.timeScale = 0;
            //재시작 버튼
            RestartBtn.SetActive(true);
            ;
        }


    }

    public void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }
}