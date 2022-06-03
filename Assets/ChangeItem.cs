using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeItem : MonoBehaviour
{
    public GameObject kutusise;
    public GameObject camsise;
    //private bool kullanim = false;
    void Start()
    {
       camsise.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sise")
        {
           
            kutusise.SetActive(false);
            camsise.SetActive(true);
        }
    }
    /*void Replace(GameObject obj1, GameObject obj2)
    {
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }*/
}
