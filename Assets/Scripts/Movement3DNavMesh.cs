using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3DNavMesh : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 goalPosition)
    {
        StopCoroutine("OnMove");//이동 정지
        navMeshAgent.speed = moveSpeed;//속도 설정
        navMeshAgent.SetDestination(goalPosition);//목적지 설정
        StartCoroutine("OnMove");//목적지로 이동
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            //목표 위치에 근접 시, 플레이어의 위치를 목표 위치로 설정하고, ResetPath()함수를 호출해 설정된 이동 경로를 초기화(이동 중지)
            if(Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination;
                navMeshAgent.ResetPath();

                break;
            }
            yield return null;
        }
    }
}
