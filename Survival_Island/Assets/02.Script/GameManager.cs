using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // enemy가 태어나는 로직과 더불어 게임 전체를 아우르는 기능. 즉, 조절하는 클래스
    // 1. 적 prefab
    // 2. 태어날 위치들
    // 3. 시간 간격
    // 4. 몇 마리 태어날지

    public GameObject zombiePrefab;
    public Transform[] Points;
    private float timePrev;
    private float spawnTime = 3.0f;
    private int maxCount = 10;
    void Start()
    {
        Points = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        //자기 자신을 포함해서 그 하위 오브젝트의 트랜스폼들을 Points 배열에 다 넣음

        timePrev = Time.time;
    }

    void Update()
    {    //현재시간 - 과거시간(= 지난시간) >= 3초
        if(Time.time - timePrev >= spawnTime)
        {
            int zombieCount = GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
            //하이라키에서 zombie태그를 가진 것들의 갯수를 카운트해서 넘긴다.

            if (zombieCount > maxCount)
            {
                int randPos = Random.Range(1, Points.Length);   //그 밑에 있는거 잡아야되는데 스판포인트 잡혀버리니까 1부터
                Instantiate(zombiePrefab, Points[randPos].position, Points[randPos].rotation);

                timePrev = Time.time;
            }

            timePrev = Time.time;
        }
    }
}
