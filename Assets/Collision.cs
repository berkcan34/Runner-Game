using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sise" || other.gameObject.tag == "CamSise")
        {
            if (!ATMRush.instance.siseler.Contains(other.gameObject)) // otherlarimiz ATMRush'in icinde olmamasi gerektiginden other.gameobhect false yapiyoruz bu fonksiyonumuzla. Ayni siseler ic ice girmesin diye.
            {
                other.GetComponent<BoxCollider>().isTrigger = false; // Her toplanilan nesne diger nesneleri de toplayabilecek. Yeni butunluge dahil olabilecekler.False yapmamizdaki amac karisikligi onlemek ve toplayabilmek icin.
                other.gameObject.tag = "Untagged";
                other.gameObject.tag = "Sise";
                other.gameObject.AddComponent<Collision>(); // Yeni topladigimiz nesneler diger nesneler ile collide olmasi icin.
                other.gameObject.AddComponent<Rigidbody>(); // Collide olabilmesi icin rb ekliyoruz.
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true; // rb kinematic ozelligi ekliyoruz.

                ATMRush.instance.StackSise(other.gameObject, ATMRush.instance.siseler.Count - 1); // -1 yapmamizin amaci indexler 0'dan baslar ama countlar 1'den. Bu sebeple.

            }
        }
    }
}
