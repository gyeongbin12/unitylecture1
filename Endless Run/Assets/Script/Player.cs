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
    [SerializeField] float positionX;

    [SerializeField] RoadLine roadLine;

    void Update()
    {
        // 캐릭터 이동 함수
        Move();
        
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
}
