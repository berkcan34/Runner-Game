using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuanToplama : MonoBehaviour
{
    int puan = 0;
    public Text PuanGoster;
    void Start()
    {
        PuanGoster.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sise")
        {
            puan++;
            PuanGoster.text = "KAZANILAN PUAN: " + puan;
            //kutusise.SetActive(false);
            //camsise.SetActive(true);
        }
        if (other.gameObject.tag == "FinishLine")
        {
            PuanGoster.enabled = true;
        }
    }
}
