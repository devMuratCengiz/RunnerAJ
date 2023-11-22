using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinEffect;
    private Score score;
    private MapController mapController1;
    private MapController mapController2;
    private AudioSource coinSound;
    
    void Start()
    {
        coinSound = GameObject.Find("Default").GetComponent<AudioSource>();
        mapController1 = GameObject.Find("Map1").GetComponent<MapController>();
        mapController2 = GameObject.Find("Map2").GetComponent<MapController>();
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        coinSound.Play();
        Instantiate(coinEffect, transform.position, Quaternion.identity);
        score.AddToScore();
        mapController1.mapSpeed += .1f;
        mapController2.mapSpeed += .1f;

        gameObject.SetActive(false);
        Invoke("CoinRespawn", 2f);
        Debug.Log("coinsc");
    }

    public void CoinRespawn()
    {
        gameObject.SetActive(true);
    }

}
