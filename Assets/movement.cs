using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;

    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            Move();
        }


    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x = cam.transform.localPosition.x;

        Ray ray = cam.ScreenPointToRay(mousePos); 

        RaycastHit hit; //Carpilan noktayi alabilmek icin
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //Carpip carpmama durumunu kontrol etmek icin, out hit ise degisken icine depolamayi sagliyor.
        {
            GameObject ilknesne = ATMRush.instance.siseler[0]; //siselerin ilk indexini ilk nesneye esitliyoruz. Lerp mekaniginde alinan nesneler, ilk nesnenin onunde stacklensin.
            Vector3 hitVec = hit.point; //Hit pointte y ve z degerleri degistirilemiyor. Bu yüzden hitvec adinda bir degisken tanimlayip bunu hit point'e esitliyoruz. X position degiseceginden y ve z leri ilknesne'mize esitliyoruz.
            hitVec.y = ilknesne.transform.position.y;
            hitVec.z = ilknesne.transform.position.z;

            ilknesne.transform.position = Vector3.MoveTowards(ilknesne.transform.position, hitVec, Time.deltaTime * swipeSpeed); //X localposition degistirmek icinse ilknesne'nin localposition degerini vector3 ve hitvec kullanarak time'i swipe degiskenimiz ile carparak sagliyoruz.
        }
    }
}
