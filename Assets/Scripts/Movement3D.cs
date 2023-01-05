using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 3.0f;
    private float gravity = -9.8f;

    [SerializeField]
    private Transform cameraTransform;
    private Vector3 moveDirection;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();   
    }

    void Update()
    {
        if(characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;//�߷� ����
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        //moveDirection = direction;
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);//x, z���� ī�޶� ȸ��, y���� �߷� ����
    }
    //Character Component�� �߷� ���� X ==> �߷��� �ڵ�� ��������� ��

    public void JumpTo()
    {
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
