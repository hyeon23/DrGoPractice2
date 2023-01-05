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
        StopCoroutine("OnMove");//�̵� ����
        navMeshAgent.speed = moveSpeed;//�ӵ� ����
        navMeshAgent.SetDestination(goalPosition);//������ ����
        StartCoroutine("OnMove");//�������� �̵�
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            //��ǥ ��ġ�� ���� ��, �÷��̾��� ��ġ�� ��ǥ ��ġ�� �����ϰ�, ResetPath()�Լ��� ȣ���� ������ �̵� ��θ� �ʱ�ȭ(�̵� ����)
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
