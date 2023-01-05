using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotateSpeedX = 3;
    private float rotateSpeedY = 5;
    private float limitMinX = -120;
    private float limitMaxX = 120;
    private float eulerAngleX;
    private float eulerAngleY;

    public void RotateTo(float mouseX, float mouseY)
    {
        //���콺�� �¿�� �����̴� mouseX ���� y�࿡ �����ϴ� ������ ���콺�� �¿�� ������ ��, ī�޶� �¿츦 ������ ī�޶� ������Ʈ�� y���� ȸ���Ǿ�� �ϱ� ����
        eulerAngleY += mouseX * rotateSpeedX;
        eulerAngleX -= mouseY * rotateSpeedY;//���콺�� �Ʒ��� ���� ���� -�̱� ������ ���ش�.
        //x�� ȸ�� ���� ��� �Ʒ�, ���� �� �� �ִ� ���� ������ �����Ǿ� �ִ�.
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);//min�� max ������ �ѱ��� �ʵ��� �����ϰ�, �̷��� �ϼ��� x, y ȸ�� ���� ī�޶��� rotation ������ ���� �̸� �������� ���콺�� �������� ��, ī�޶� ȸ��
    }
}
