using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text bananasText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private int bananas=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Banana"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            bananas++;
            bananasText.text = "Points: " + bananas;
        }
    }


}
