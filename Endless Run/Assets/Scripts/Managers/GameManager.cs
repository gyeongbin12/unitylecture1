using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 15f;
    [SerializeField] GameObject layoutPanel;

    [SerializeField] Animator textAnimator;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;

    WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(1f);

    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;  
    }

    public IEnumerator StartRoutine(int count)
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");

        layoutPanel.SetActive(false);

        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������
        // ���� Time.Scale�� 0 �̹Ƿ�, WaitForSecondsRealtime�� �����մϴ�.

        while (count > 0)
        {
            textAnimator.GetComponent<TextMeshProUGUI>().text = count.ToString();

            textAnimator.Play("Count Down");

            yield return waitForSecondsRealtime;

            count--;
        }

        textAnimator.gameObject.SetActive(false);

        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;      
    }
}
