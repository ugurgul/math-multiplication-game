using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private Text soruText,birinciSonucText,ikinciSonucText,UcuncuSonucText;

    [SerializeField]
    private Text dogruAdetiText,yanlisAdetiText,puanAdetiText;

    [SerializeField]
    private GameObject dogruImage,yanlisImage;

    PlayerManager playerManager;
    AdmobManager admobManager;


    string hangiOyun;
    int birinciCarpan;
    int ikinciCarpan;
    int dogruSonuc,birinciYanlisSonuc,ikinciYanlisSonuc;
    public int dogruAdet,yanlisAdet,puan;

    private void Awake() {
        playerManager = Object.FindObjectOfType<PlayerManager>();
        admobManager = Object.FindObjectOfType<AdmobManager>();
    }



    void Start()
    {

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        



        if(PlayerPrefs.HasKey("hangiOyun")){

            hangiOyun = PlayerPrefs.GetString("hangiOyun");
        }

        StartCoroutine(baslaYaziRoutine());

        
       
    }

    IEnumerator baslaYaziRoutine(){

        baslaImage.GetComponent<RectTransform>().DOScale(1.5f,0.5f);
        yield return new WaitForSeconds(0.6f);

        baslaImage.GetComponent<RectTransform>().DOScale(0f,0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f,1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();

    }

    void OyunaBasla(){
        playerManager.rotaDegissinmi = true;
        BirinciCarpaniAyarla();
        admobManager.ShowBanner();

    }

    public void BirinciCarpaniAyarla(){

        switch(hangiOyun)
        {
            case "iki":
            birinciCarpan = 2;
            break;

             case "üç":
            birinciCarpan = 3;
            break;

             case "dört":
            birinciCarpan = 4;
            break;

             case "beş":
            birinciCarpan = 5;
            break;

             case "altı":
            birinciCarpan = 6;
            break;

             case "yedi":
            birinciCarpan = 7;
            break;

             case "sekiz":
            birinciCarpan = 8;
            break;

             case "dokuz":
            birinciCarpan = 9;
            break;

             case "on":
            birinciCarpan = 10;
            break;

             case "karışık":
            birinciCarpan = Random.Range(2,11);
            break;

        }

        SoruyuYazdir();

        
        
    }

    void SoruyuYazdir(){


        ikinciCarpan = Random.Range(2,11);

        int rastgeleDeger = Random.Range(2,100);

        if (rastgeleDeger <= 50)
        {
            soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }else
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
        }

        dogruSonuc = birinciCarpan * ikinciCarpan;
        birinciYanlisSonuc = dogruSonuc - birinciCarpan;
        ikinciYanlisSonuc = dogruSonuc + ikinciCarpan;

        


        SonuclariYazdir();

    }
    
    void SonuclariYazdir(){

        int rastgeleDeger = Random.Range(1,100);

        if (rastgeleDeger <= 33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            UcuncuSonucText.text = ikinciYanlisSonuc.ToString();

            
        }
        else if (rastgeleDeger <= 66)
        {
            ikinciSonucText.text = dogruSonuc.ToString();
            birinciSonucText.text = birinciYanlisSonuc.ToString();
            UcuncuSonucText.text = ikinciYanlisSonuc.ToString();

        }
        else
        {
            UcuncuSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            birinciSonucText.text = ikinciYanlisSonuc.ToString();
        }



    }
    

    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonucu == dogruSonuc){
            dogruAdet++;
            puan += 10;
            dogruAdetiText.text = dogruAdet.ToString() + "  DOĞRU";
            puanAdetiText.text = puan.ToString() + "  PUAN";

            dogruImage.SetActive(true);
            dogruImage.GetComponent<RectTransform>().DOScale(1f,0.3f).SetEase(Ease.OutBack);
            
            
            
        }else
        {
            yanlisAdet++;
            yanlisAdetiText.text = yanlisAdet.ToString() + "  YANLIŞ";
            yanlisImage.SetActive(true);
            yanlisImage.GetComponent<RectTransform>().DOScale(1f,0.3f).SetEase(Ease.OutBack);


        }
    }
}
