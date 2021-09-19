using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecCountOfBage : MonoBehaviour
{
    [HideInInspector] public int count = 0; //������� ��� �������� ����, ����� ������������ �� ������ ������ ���������, ��� ����

    private CanvasGroup hideProducts; //������ ��������� ��������� � ���������� ���� ���������

    private void Start()
    {
        hideProducts = GameObject.FindGameObjectWithTag("BuyerDialog").GetComponentInChildren<CanvasGroup>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SellerDialog")
        {
            hideProducts.alpha = 0;
        }
    }
}
