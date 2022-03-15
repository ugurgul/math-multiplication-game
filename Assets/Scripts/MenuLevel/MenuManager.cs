using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject btnOyna,btnAyarlar,btnCikis;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikmi;


    void Start()
    {
        sesPaneliAcikmi = false;

        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(0,50,0);

        menuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack);
    }

    public void ikinciLeveleGec(){

        if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);
        }

        

        SceneManager.LoadScene("ikinciMenuLevel");


    }

    public void AyarlariYap(){
        if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);
        }

        if(sesPaneliAcikmi == false){

            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-110,.7f);
            sesPaneliAcikmi = true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(50,.7f);
            sesPaneliAcikmi = false;
        }
        
        



    }

    public void Cikis(){
        if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);
        }
        Application.Quit();
    }










}
