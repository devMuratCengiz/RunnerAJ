using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameManager gameManager;
    public float mapSpeed = 5f;

    void Update()
    {
        if (gameManager.isStart)
        {
            transform.Translate(Vector3.back * mapSpeed * Time.deltaTime);
            if (transform.position.z <= -100)
            {
                Vector3 reset = new Vector3(transform.position.x, transform.position.y, 100);
                transform.position = reset;
            }
        }
       
    }
}
