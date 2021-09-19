using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sell : MonoBehaviour
{
    private Rigidbody2D hideStorage;

    private Storage buyerOrder;
    public RawImage[] showProducts;
    private ButtonManager sellerWork;

    private Money callMoneyFunc;

    private Buyer buyer;

    public CanvasGroup[] trueBadge = new CanvasGroup[3];
    public CanvasGroup[] falseBadge = new CanvasGroup[3];

    private GameObject[] tmp1 = new GameObject[3];
    private GameObject[] tmp2 = new GameObject[3];

    [HideInInspector]public CanvasGroup sellerDialog; //отобразить диалоговое окно продавца
    
    [HideInInspector]public bool checkReaction;
    [HideInInspector]public int countMistake;

    public AudioSource appearSound;

    private bool flag;
    private void Start()
    {
        hideStorage = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Rigidbody2D>();
        buyer = GameObject.FindGameObjectWithTag("Buyer").GetComponentInChildren<Buyer>();

        callMoneyFunc = GameObject.FindGameObjectWithTag("Sum").GetComponent<Money>();
                                                                                //доступ к массиву продуктов, которые выбрал покупатель
        buyerOrder = GameObject.FindGameObjectWithTag("Items").GetComponentInChildren<Storage>();
                                                                                //доступ к массиву продуктов, которые выбрал продавец
        sellerWork = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<ButtonManager>();

        sellerDialog = GetComponent<CanvasGroup>();

        tmp1 = GameObject.FindGameObjectsWithTag("OkBadge");
        tmp2 = GameObject.FindGameObjectsWithTag("NoBadge");

        for (int i = 0; i < 3; i++)
        {
            trueBadge[i] = tmp1[i].GetComponentInChildren<CanvasGroup>();
                                                                                //отображение положительной отметки
            falseBadge[i] = tmp2[i].GetComponentInChildren<CanvasGroup>();
                                                                                //отобрадение отрицательной отметки
        }
    }

    public void CompareMas()
    {
        countMistake = 0;
        //отображение выбраных продуктов в диалоговом окне
        for (int i = 0; i < buyerOrder.index.Length; i++)
        {
            showProducts[i].texture = buyerOrder.myTextures[sellerWork.foundProducts[i]];
        }
        //проверка на правильность выбранных продуктов

        appearSound.Play();

        for (int i = 0; i < buyerOrder.index.Length; i++)
        {
            flag = false;


            for (int j = 0; j < sellerWork.foundProducts.Count; j++)
            {
                if (sellerWork.foundProducts[j] == buyerOrder.index[i])
                {
                    flag = true;
                    trueBadge[i].alpha = 1;
                }
            }
            if (!flag)
            {
                checkReaction = false;
                countMistake++;
                falseBadge[i].alpha = 1;
            }
        }
        StartCoroutine("HideStorage");
        buyer.Reaction(); //вызов реакции покупателя
        callMoneyFunc.Pay();
    }
    IEnumerator HideStorage()
    {
        yield return new WaitForSeconds(1);
        hideStorage.velocity = Vector2.right * 100;

        yield return new WaitForSeconds(5);
        hideStorage.velocity = Vector2.left * 0;
        Debug.Log("5 sec");
    }

}
