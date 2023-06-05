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
        //�������� �ٲٱ�
        if (stageIndex < stages.Length - 1)
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

            //����� ��ư
            RestartBtn.SetActive(true);
        }
    }
    //����۹�ư�� ������ ��
    public void ReStart()
    {
        health = maxhp;
        PlayerReposition();
        RestartBtn.SetActive(false);
        HealthRecover();
        Time.timeScale = 1.0f;

    }

    //ü��ȸ��(����۹�ư ��������)
    public void HealthRecover()
    {
        for (int i = 0; i < maxhp; i++)
        {
            UIhealth[i].SetActive(true);
        }

    }

    // �ǰ����� ���� ü�¼�ġ�� UI ü��ĭ ����
    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].SetActive(false);
            Debug.Log("ü���� 1 �����߽��ϴ�.");

        }

        //ü���� 0�� �Ǿ���� ���
        else
        {
            health--;
            UIhealth[health].SetActive(false);
            Debug.Log("���ӿ���");
            Time.timeScale = 0;
            //����� ��ư
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