using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject objeSonuclar,objeZaman,objeDogruYanlis,ObjePlayer,ObjePuan;

    int kalanSure;
    bool sureSaysinmi;


    void Start()
    {
        kalanSure = 90;
        sureSaysinmi = true;

        sonucPaneli.SetActive(false);
        EkraniTemizle(true);

        StartCoroutine(SureTimerRoutine());
        
    }

    IEnumerator SureTimerRoutine()
    {
        

        while(sureSaysinmi){
        yield return new WaitForSeconds(1f);

          if(kalanSure < 10)
          {
              sureText.text = "0"+kalanSure.ToString();
          }
          else
          {
              sureText.text = kalanSure.ToString();
          }

          if(kalanSure <=0){
              sureSaysinmi = false;
              sureText.text = "";
              
              EkraniTemizle(false);
              sonucPaneli.SetActive(true);
          }
          kalanSure --;
          


        }
    }

    void EkraniTemizle(bool ekranTemizlensinmi){

        objeDogruYanlis.SetActive(ekranTemizlensinmi);
        objeSonuclar.SetActive(ekranTemizlensinmi);
        objeZaman.SetActive(ekranTemizlensinmi);
        ObjePlayer.SetActive(ekranTemizlensinmi);
        ObjePuan.SetActive(ekranTemizlensinmi);
        

    }


}
