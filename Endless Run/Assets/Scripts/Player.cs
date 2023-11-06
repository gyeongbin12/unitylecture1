using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RoadLine
{ 
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] UnityEvent playerEvent;
    [SerializeField] ObjectSound objectSound = new ObjectSound();

    void Update()
    {
        // ĳ���� �̵� �Լ�
        Move();

        // ĳ���� �̵� ����
        Status();
    }

    public void Move()
    {
        // ���� ���� Ű�� �Է����� ��
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0)
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

            if (roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else
            {
                roadLine--;
            }
        }

        // ������ ���� Ű�� �Է����� ��
        if(Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0)
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

            if (roadLine == RoadLine.RIGHT)
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
            case RoadLine.LEFT : transform.position = new Vector3( -positionX, 0, 0);
                break;
            case RoadLine.MIDDLE : transform.position = Vector3.zero;
                break;
            case RoadLine.RIGHT : transform.position = new Vector3( +positionX, 0, 0);
                break;
        }
    }

    public void OnDie()
    {
        playerEvent.Invoke();

        animator.Play("Die");
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if(item != null)
        {
            item.Use();
            other.GetComponent<MeshRenderer>().enabled = false;
        }

        if(other.CompareTag("Obstacle"))
        {
            OnDie();
        }
    }
}
