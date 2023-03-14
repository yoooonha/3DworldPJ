using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _follwer;
    [SerializeField] Transform _realCam;

    float rotX;
    float rotY;
    //각도 제한 변수
    float minClapAngle = 25;
    float maxClapAngle = 45;

    //감도
    [SerializeField] float sensitivity = 200;

    [SerializeField] float followSpeed = 5;

    Vector3 finalDir;
    [SerializeField] float maxDistance = 5;  //최대거리
    [SerializeField] float minDistance = 2;

    Vector3 dirNormal;
    float finalDis;

    [SerializeField] float smoothness = 3;

    bool _isMoveVisible;


    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormal = _realCam.localPosition.normalized; //부모로부터 (내가)어느방향으로 떨어져있다. 
       
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //마우스커서 GameScene에서 안보이게함
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isMoveVisible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
          
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isMoveVisible= true;
        }

        if (_isMoveVisible) return;
        rotX += Input.GetAxis("Mouse Y") * -1 * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -minClapAngle, maxClapAngle);

        Quaternion rot = Quaternion.Euler(rotX, rotY, 0); //transform.rotation = Quaternion 쓰는 방법만(rotation에서 사용한다)
        transform.rotation = rot;
        //transform.position= _follwer.position;



    }

    private void LateUpdate()
    {
        //MoveTowards??
        transform.position = Vector3.MoveTowards(transform.position, _follwer.position, Time.deltaTime * followSpeed);

        finalDir = transform.TransformPoint(dirNormal * maxDistance);

        RaycastHit hit;
        //Debug.DrawLine(transform.position, finalDir, Color.green, 5);
        if (Physics.Linecast(transform.position, finalDir, out hit))//hit안에 값(transform.position,finalDir)을 넣어준다
        {
            finalDis = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDis = maxDistance;
        }

        _realCam.localPosition = Vector3.Lerp(_realCam.localPosition, dirNormal * finalDis, Time.deltaTime * smoothness);//Lerp 보간방법으로 찾아냄 


    }


}
