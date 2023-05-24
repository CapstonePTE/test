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
        //�������� �ٲٱ�
        if (stageIndex < stages.Length-1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else //���� Ŭ����
        {
            Time.timeScale = 0;

            Debug.Log("���� Ŭ����");
        }
    }

    public void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, 0);
        player.VelocityZero();
    }
}
