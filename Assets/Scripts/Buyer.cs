using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buyer : MonoBehaviour
{
    private float speed = 3;

    private bool stop = false;

    private SpriteRenderer buyer;
    private Rigidbody2D showStorage;

    
    private CanvasGroup dialogIcon;
    private CanvasGroup showLike;
    private CanvasGroup showAngryFace;
    private CanvasGroup hideSellerDialog;
    

    public AudioSource hideDialogSound;
    public AudioSource reactionDialogSound;

    private Storage cleanMas;
    private Sell sell;
    private Sell showSellerDialog;

    StorageVisible dVis;
    StorageVisible sVis;
    ShowOrder show;

    private bool exit = false;
   
    private void Start()
    {
        showStorage = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Rigidbody2D>();

        buyer = GetComponent<SpriteRenderer>();


        dVis = GameObject.FindGameObjectWithTag("BuyerDialog").GetComponentInChildren<StorageVisible>();

        show = GameObject.FindGameObjectWithTag("BuyerDialog").GetComponentInChildren<ShowOrder>(); 

        sell = GameObject.FindGameObjectWithTag("SellerDialog").GetComponent<Sell>();

        cleanMas = GameObject.FindGameObjectWithTag("Items").GetComponent<Storage>();

        showSellerDialog = GameObject.FindGameObjectWithTag("SellerDialog").GetComponent<Sell>();
        dialogIcon = GameObject.FindGameObjectWithTag("Dialog").GetComponentInChildren<CanvasGroup>();
        showLike = GameObject.FindGameObjectWithTag("Good").GetComponentInChildren<CanvasGroup>();
        showAngryFace = GameObject.FindGameObjectWithTag("Bad").GetComponentInChildren<CanvasGroup>();
        hideSellerDialog = GameObject.FindGameObjectWithTag("SellerDialog").GetComponentInChildren<CanvasGroup>();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            StartCoroutine("ShowStorage");
            stop = true; //остановка движения покупателя
            speed = 0;
            transform.Translate(Vector2.up * 0 * Time.deltaTime);

            dVis.StartCanvasVisible(); //вызов диалогового окна у полкупателя
            show.showO(); //заказ
        }
  
    }

    //новый клиент
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            speed = 3;
            stop = false;
            buyer.flipX = false;
            exit = false;
        }
    }
    private void Update()
    {
        if (!stop)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.Translate(Vector2.up * 1 * Time.deltaTime);
        }
        if (exit == true)
        {
            buyer.flipX = true;
            transform.Translate(Vector3.left * Time.deltaTime);
        }

    }

    //анимация появления магазина
    IEnumerator ShowStorage()
    {
        yield return new WaitForSeconds(5);
        showStorage.velocity = Vector2.left * 100;
        Debug.Log("After 5 sec");

        yield return new WaitForSeconds(0);
        hideDialogSound.Play();

        Debug.Log("After 5 sec");
    }

    public void Reaction()
    {
        StartCoroutine("ShowReaction");
    }

    //реакция покупателя
    IEnumerator ShowReaction()
    {
        yield return new WaitForSeconds(1);
        showSellerDialog.sellerDialog.alpha = 1;
        yield return new WaitForSeconds(3);
        dialogIcon.alpha = 1;
        reactionDialogSound.Play();
        Debug.Log("1 sec");
        if (sell.checkReaction == true && GameObject.FindGameObjectWithTag("Good").GetComponentInChildren<CanvasGroup>())
        {
            showLike.alpha = 1;
        }
        else if (sell.checkReaction == false && GameObject.FindGameObjectWithTag("Bad").GetComponentInChildren<CanvasGroup>())
        {
            showAngryFace.alpha = 1;
        }

        yield return StartCoroutine(HideDialog());
        stop = false;
        exit = true;
    }

    //спрятать все диалоговые окна
    IEnumerator HideDialog()
    {
        yield return new WaitForSeconds(1);
        dialogIcon.alpha = 0;
        showLike.alpha = 0;
        showAngryFace.alpha = 0;
        hideSellerDialog.alpha = 0;
        showSellerDialog.sellerDialog.alpha = 0;
        hideDialogSound.Play();
    }

  
}