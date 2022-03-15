using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText,yanlisText,puanText;

    [SerializeField]
    private GameObject tekrarOynaBtn,menuyeDonBtn;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private AudioSource audioSource;



    GameManager gameManager;


    float sureTimer;
    bool resimAcilsinmi;

    private void Awake() {
        gameManager = Object.FindObjectOfType<GameManager>();
    }


    private void OnEnable() {

        sureTimer = 0;
        resimAcilsinmi = true;

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";

        tekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        menuyeDonBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
       

        StartCoroutine(ResimAcRoutine());
        
    }




    IEnumerator ResimAcRoutine(){

        while (resimAcilsinmi){

            sureTimer += .15f;
            sonucImage.fillAmount = sureTimer;

            yield return new WaitForSeconds(0.1f);

            if(sureTimer >=1)
            {
                sureTimer = 1;
                resimAcilsinmi = false;

                dogruText.text = gameManager.dogruAdet.ToString() + "  DOĞRU";
                yanlisText.text = gameManager.yanlisAdet.ToString() + "  YANLIŞ";
                puanText.text = gameManager.puan.ToString() + "  PUAN";

                tekrarOynaBtn.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
                menuyeDonBtn.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);

            }
        }
    }

    public void TekrarOynaBtn(){
            if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);

            SceneManager.LoadScene("GameLevel");
        }
        

    }

    public void MenuyeDonBtn(){
            if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);
        }
        SceneManager.LoadScene("MenuLevel");

    }








}
