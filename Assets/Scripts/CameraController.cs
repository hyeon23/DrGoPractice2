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
        //마우스를 좌우로 움직이는 mouseX 값을 y축에 대입하는 이유는 마우스는 좌우로 움직일 때, 카메라도 좌우를 보려면 카메라 오브젝트의 y축이 회전되어야 하기 때문
        eulerAngleY += mouseX * rotateSpeedX;
        eulerAngleX -= mouseY * rotateSpeedY;//마우스는 아래로 가는 것이 -이기 때문에 빼준다.
        //x축 회전 값의 경우 아래, 위를 볼 수 있는 제한 각도가 설정되어 있다.
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);//min과 max 각도를 넘기지 않도록 설정하고, 이렇게 완성된 x, y 회전 값이 카메라의 rotation 정보에 들어가고 이를 바탕으로 마우스를 움직였을 때, 카메라가 회전
    }
}
