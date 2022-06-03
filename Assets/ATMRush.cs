using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ATMRush : MonoBehaviour
{
    public static ATMRush instance;
    public float movementDelay = 0.25f;
    public List<GameObject> siseler = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

    // Update is called once per frame
    public void StackSise(GameObject other, int index)
    {
        other.transform.parent = transform; // Bütün siseler belirledigim parentin altinda siralanmasini sagliyorum.
        Vector3 newPos = siseler[index].transform.localPosition; // Toplanan nesnelerin ileri atilmasi icin. index dedigimiz deger son sisemizin position'unu alacak.
        newPos.x += -1;
        other.transform.localPosition = newPos;
        siseler.Add(other);
        StartCoroutine(MakeObjectsBigger()); // Fonksiyonu burada cagiriyoruz.
    }

    private IEnumerator MakeObjectsBigger() // Toplanan nesneler buyudugu icin. IEnumerator vermekteki amac delay saglamak.
    {
        for (int i=siseler.Count-1; i > 0; i--) // Siselerin yukaridan asagiya gelmesini istiyorum, son siseden baslayacak ve 0'dan buyuk veriyorum ilk sise buyuk olmayacak.
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 0.5f;

            siseler[index].transform.DOScale(scale, 0.5f).OnComplete(() =>
             siseler[index].transform.DOScale(new Vector3(0.13f, 0.13f, 0.13f), 0.5f)); // Siselerin buyuyup kuculmesini saglayan Do Scale fonksiyonumu belirtiyorum.
            yield return new WaitForSeconds(0.05f); // Verdigim delay suresi. Nesnelerin buyumesi ve kuculmesi arasindaki gecikme suresi.
        }
    }

    private void MoveListElements()
    {
        for (int i = 1; i < siseler.Count; i++) // Siselerin count'i kadar donecek. 1'den baslatiyoruz cunku ilk toplayacagimiz nesneden itibaren donsun istiyoruz.
        {
            Vector3 pos = siseler[i].transform.localPosition;
            pos.y = siseler[i - 1].transform.localPosition.y;
            siseler[i].transform.DOLocalMove(pos, movementDelay); // Her bir nesnenin position'larini 0.25f'de degistirecek.
        }
    }

    private void MoveOrigin() // Karakter sabit ilerlerken tum nesneler duz bir hizada olsun istiyorum.
    {
        for (int i = 1; i < siseler.Count; i++)
        {
            Vector3 pos = siseler[i].transform.localPosition;
            pos.z = siseler[0].transform.localPosition.z;
            siseler[i].transform.DOLocalMove(pos, 0.5f);
        }
    }
}
