using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // enemy�� �¾�� ������ ���Ҿ� ���� ��ü�� �ƿ츣�� ���. ��, �����ϴ� Ŭ����
    // 1. �� prefab
    // 2. �¾ ��ġ��
    // 3. �ð� ����
    // 4. �� ���� �¾��

    public GameObject zombiePrefab;
    public Transform[] Points;
    private float timePrev;
    private float spawnTime = 3.0f;
    private int maxCount = 10;
    void Start()
    {
        Points = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        //�ڱ� �ڽ��� �����ؼ� �� ���� ������Ʈ�� Ʈ���������� Points �迭�� �� ����

        timePrev = Time.time;
    }

    void Update()
    {    //����ð� - ���Žð�(= �����ð�) >= 3��
        if(Time.time - timePrev >= spawnTime)
        {
            int zombieCount = GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
            //���̶�Ű���� zombie�±׸� ���� �͵��� ������ ī��Ʈ�ؼ� �ѱ��.

            if (zombieCount > maxCount)
            {
                int randPos = Random.Range(1, Points.Length);   //�� �ؿ� �ִ°� ��ƾߵǴµ� ��������Ʈ ���������ϱ� 1����
                Instantiate(zombiePrefab, Points[randPos].position, Points[randPos].rotation);

                timePrev = Time.time;
            }

            timePrev = Time.time;
        }
    }
}
