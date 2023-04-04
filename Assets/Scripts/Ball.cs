using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject Splash = Instantiate(splashPrefab,transform.position + new Vector3(0f,-0.2f,0f),transform.rotation);
        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Splash.transform.SetParent(other.gameObject.transform);

        if (materialName == "Safe Color (Instance)")
        {
            
        }
        else if(materialName == "Unsafe Color (Instance)")
        {
            gm.RestartGame();
        }
        else if (materialName == "New Material (Instance)")
        {
            
        }
    }
}
