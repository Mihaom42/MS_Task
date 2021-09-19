using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Storage : MonoBehaviour
{
    public RawImage[] theImage;
    public Texture[] myTextures = new Texture[20];

   [HideInInspector] public int productsCount;
   [HideInInspector] public int[] index;
   

    private int count = 0;
    private bool flag;

    //проверка на уникальность индекса
    public void CheckIndex()
    {
        productsCount = Random.Range(1, 4); ; //присвоение рандомной длины

        index = new int[productsCount];

        index[0] = Random.Range(0, 20);
        if (productsCount > 1)
        {
            for (int i = 1; i < productsCount; i++)
            {
                count++;
                for (int j = 0; j < 20; j++)
                {
                    index[i] = Random.Range(0, 19);
                    for (int z = 0; z < count; z++)
                    {
                        if (index[i] != index[z])
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        index[i] = Random.Range(0, 19);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        FillArray();
    }

    //заполнение массива спрайтами, 
    public void FillArray()
    {
        theImage[0].texture = myTextures[index[0]];
        if (productsCount > 1)
        {
            theImage[1].texture = myTextures[index[1]];
            if (productsCount > 2)
            {
                theImage[2].texture = myTextures[index[2]];
            }
        }
    }

   

}
