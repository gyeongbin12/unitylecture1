using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int createCount;
    [SerializeField] Button buttonPrefab;

    [SerializeField] List<Button> buttons;
    [SerializeField] Transform createPosition;

    void Start()
    {
        buttons.Capacity = 10;

        CreateButton();
    }

    private void CreateButton()
    {
        for(int i = 0; i < createCount; i++)
        {
            Button button = Instantiate(buttonPrefab);
            
            button.transform.SetParent(createPosition);

            buttons.Add(button);

            Debug.Log(button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        }
    }

    private void Register() 
    {
        buttons[0].onClick.AddListener(A);
        buttons[1].onClick.AddListener(B);
        buttons[2].onClick.AddListener(C);
        buttons[3].onClick.AddListener(D);
    }

    public void A()
    {
        Debug.Log("A");
    }

    public void B()
    {
        Debug.Log("B");
    }

    public void C()
    {
        Debug.Log("C");
    }

    public void D()
    {
        Debug.Log("C");
    }

}
