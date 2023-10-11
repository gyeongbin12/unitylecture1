using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
};


public class Player : MonoBehaviour
{
    [SerializeField] float positionX = 3.5f;
    [SerializeField] RoadLine roadLine;

    void Update()
    {
        // 캐릭터 이동 함수
        Move();

        // 캐릭터 이동 상태
        Status();
    }

    public void Move()
    {
        // 왼쪽 방향 키를 입력했을때
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else
            {
                roadLine--;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else
            {
                roadLine++;
            }
        }

    }

    public void Status()
    {
        switch (roadLine)
        {
            case RoadLine.LEFT : transform.position = new Vector3(-positionX, 0 , 0);
                break;
            case RoadLine.MIDDLE : transform.position = Vector3.zero;
                break;
            case RoadLine.RIGHT : transform.position = new Vector3(+positionX, 0 , 0);
                break;
        }
    }


}
