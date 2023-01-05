using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNavMesh : MonoBehaviour
{
    private Movement3DNavMesh movement3DNavMesh;

    private void Awake()
    {
        movement3DNavMesh = GetComponent<Movement3DNavMesh>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Camera.main: tag가 Camera인 오브젝트 = "Main Camera"
            //View port[화면 = 스크린]으로 부터 마우스 좌표(Input.mousePosition)을 관통하는 광선 생성
            //ray.origin: 광선의 시작 위치
            //ray.direction: 광선의 진행 방향

            //Physics.Raycast(): Ray를 위에서 만들고, 그 광선을 발사해 부딪힌 오브젝트가 있으면 true, 없으면 false
            //ray.origin 위치에서 ray.direction 방향으로 무한 길이의 광선 발사
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))// 광선과 광선의 길이를 1, 3번째 인자로 넣어주면 부딪힌 오브젝트는 out에 담고, bool 형태의 리턴 값을 리턴한다.
            {
                //hit.transform.position: 부딪힌 오브젝트의 위치
                //hit.point: 광선과 오브젝트가 부딪힌 세부 위치
                //hit.point를 목표 위치로 이동
                movement3DNavMesh.MoveTo(hit.point);
            }
        }
    }
}
