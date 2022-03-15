using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AltMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject altMenuPaneli;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    void Start()
    {
        altMenuPaneli.GetComponent<RectTransform>().DOScale(1,1f);
        altMenuPaneli.GetComponent<CanvasGroup>().DOFade(1,1f).SetEase(Ease.OutBack);
    }

    public void HangiOyunAcilsin(string hangiOyun){
         if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);
        }

        PlayerPrefs.SetString("hangiOyun",hangiOyun);
        SceneManager.LoadScene("GameLevel");

        
    }

    public void GeriDon(){
         if(PlayerPrefs.GetInt("sesDurumu")==1){
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MenuLevel");
    }

private void OnTriggerEnter(Collider other) {
    Debug.Log(other.name);
}



}
