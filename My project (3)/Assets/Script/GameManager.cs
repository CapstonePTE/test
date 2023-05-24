using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public int health;
    public CharacterController player;
    public GameObject[] stages;




    public void Nextstage()
    {
        //스테이지 바꾸기
        if (stageIndex < stages.Length-1)
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
        }
    }

    public void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, 0);
        player.VelocityZero();
    }
}
