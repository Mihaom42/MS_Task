using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProductChoice : MonoBehaviour
{

    public RawImage badge;
    public Button buttonSprite;
    [HideInInspector] public CanvasGroup vis;
    private ChecCountOfBage checkBadgeCount;
    private Storage buyerOrder;
    private ButtonManager activateButton;

    public CanvasGroup hide;

    [HideInInspector]public int count;

    public AudioSource buttonSound;
    private void Start()
    {
        buyerOrder = GameObject.FindGameObjectWithTag("Items").GetComponentInChildren<Storage>(); //доступ к массиву пололжительных отметок

        checkBadgeCount = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<ChecCountOfBage>(); 
                                                                                        //достпуп к классу для записи кол-ва отмеченных продуктов

        activateButton = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<ButtonManager>(); //активирование кнопки SELL

        vis = GetComponentInChildren<CanvasGroup>();
        vis.alpha = 0;

        hide = GetComponentInChildren<CanvasGroup>();
    }

    //отображение отметок на кнопках и регулирование кол-ва нажатий
    public void ShowBadge()
    {
        buttonSound.Play();
        if (checkBadgeCount.count < buyerOrder.index.Length && count == 0)
        {
            if (count == 0)
            {
                vis.alpha = 1;
                buttonSprite.image.color = new Color(255f, 255f, 255f, .70f);
                count = 1;
                checkBadgeCount.count++;
            }
        }
        else if(checkBadgeCount.count > 0 && count == 1)
        {
            vis.alpha = 0;
            buttonSprite.image.color = new Color(255f, 255f, 255f, 5f);
            count = 0;
            checkBadgeCount.count--;
        }

        if(checkBadgeCount.count == buyerOrder.index.Length)
        {
            activateButton.sellButton.image.color = new Color(255f, 255f, 255f, 5f);
            activateButton.sellButton.enabled = true;
        }
        else
        {
            activateButton.sellButton.image.color = new Color(255f, 255f, 255f, .50f);
            activateButton.sellButton.enabled = false;
        }
    }

    public void Clean()
    {
        count = 0;
        checkBadgeCount.count = 0;
    }
}
