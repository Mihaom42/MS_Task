using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecCountOfBage : MonoBehaviour
{
    [HideInInspector] public int count = 0; //счётчик для проверки того, чтобы пользователь не выбрал больше продуктов, чем надо

    private CanvasGroup hideProducts; //скрыть множество продуктов в диалоговом окне персонажа

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
