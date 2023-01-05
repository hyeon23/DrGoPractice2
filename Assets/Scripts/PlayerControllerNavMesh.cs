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
            //Camera.main: tag�� Camera�� ������Ʈ = "Main Camera"
            //View port[ȭ�� = ��ũ��]���� ���� ���콺 ��ǥ(Input.mousePosition)�� �����ϴ� ���� ����
            //ray.origin: ������ ���� ��ġ
            //ray.direction: ������ ���� ����

            //Physics.Raycast(): Ray�� ������ �����, �� ������ �߻��� �ε��� ������Ʈ�� ������ true, ������ false
            //ray.origin ��ġ���� ray.direction �������� ���� ������ ���� �߻�
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))// ������ ������ ���̸� 1, 3��° ���ڷ� �־��ָ� �ε��� ������Ʈ�� out�� ���, bool ������ ���� ���� �����Ѵ�.
            {
                //hit.transform.position: �ε��� ������Ʈ�� ��ġ
                //hit.point: ������ ������Ʈ�� �ε��� ���� ��ġ
                //hit.point�� ��ǥ ��ġ�� �̵�
                movement3DNavMesh.MoveTo(hit.point);
            }
        }
    }
}
