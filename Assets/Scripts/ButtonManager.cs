using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public Button[] masButton = new Button[19];
    [HideInInspector] public List<int> foundProducts = new List<int>();

    private Storage buyerOrder;
    private Sell showIcon;

    public CanvasGroup[] hideBadge = new CanvasGroup[19];

    public Button sellButton;

    public AudioSource sellButtonSound;

    private ProductChoice cleanClickCount;

    private int count = 0;

    private void Start()
    {
        buyerOrder = GameObject.FindGameObjectWithTag("Items").GetComponentInChildren<Storage>(); //доступ к массиву пололжительных отметок
        showIcon = GameObject.FindGameObjectWithTag("SellerDialog").GetComponent<Sell>(); //доступ к эл-там Sell

        cleanClickCount = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<ProductChoice>();

        sellButton.image.color = new Color(255f, 255f, 255f, .50f);
        sellButton.enabled = false;

       for(int i = 0; i<19; i++)
        {
            hideBadge[i].alpha = 0; ;
        }
    }

    //проверка, какие продукты были выбраны и добаления их в список
    public void Sell()
    {
        sellButtonSound.Play();
        for(int i = 0; i <= 19; i++)
        {
            if (count <= buyerOrder.index.Length)
            {
                if (masButton[i].image.color == new Color(255f, 255f, 255f, .70f))
                {
                    foundProducts.Add(i);
                    masButton[i].image.color = new Color(255f, 255f, 255f, 5f);
                    count++;
                    hideBadge[i].alpha = 0;
                    cleanClickCount.Clean();
                }
                
            }
            if(count == buyerOrder.index.Length)
            {
                break;
            }
        }
        
        showIcon.CompareMas(); //вызов диалогового окна у продавца
    }
}
