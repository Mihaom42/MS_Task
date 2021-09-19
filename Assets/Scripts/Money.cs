using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    private Sell sell;
    private Storage count;
    [SerializeField] Text money;

    private int startSum = 500;

    public AudioSource paySound;
    void Start()
    {
        sell = GameObject.FindGameObjectWithTag("SellerDialog").GetComponent<Sell>();
        count = GameObject.FindGameObjectWithTag("Items").GetComponentInChildren<Storage>(); ;
    }

    public void Pay() //проверка на сумму оплаты
    {
        if(sell.checkReaction == true)
        {
            switch (count.productsCount)
            {
                case 1:
                    money.text = "$  " + (startSum + 20).ToString();
                    break;
                case 2:
                    money.text = "$  " + (startSum + 40).ToString();
                    break;
                case 3:
                    money.text = "$  " + (startSum + 60).ToString();
                    break;

            }
            paySound.Play();
        }
        else
        {
            switch (sell.countMistake)
            {
                case 1:
                    if (count.productsCount == 1)
                    {
                        paySound.volume = 0;
                        break;
                    }
                    else if(count.productsCount == 2)
                    {
                        money.text = "$  " + (startSum + 10).ToString();
                    }
                    else if (count.productsCount == 3)
                    {
                        money.text = "$  " + (startSum + 20).ToString();
                    }
                    break;

                case 2:
                    if (count.productsCount == 2)
                    {
                        paySound.volume = 0;
                        break;
                    }
                    else if (count.productsCount == 3)
                    {
                        money.text = "$  " + (startSum + 10).ToString();
                    }
                    break;

                case 3:
                    paySound.volume = 0;
                    break;
            }
            paySound.Play();
        }
    }

    
}
