using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroper : MonoBehaviour
{
    [Range(1, 100)] [SerializeField] float dropRate;
    [SerializeField] GameObject[] items;
    //float time = 0;
    float halfRate;
    // Start is called before the first frame update
    void Start()
    {
        halfRate = dropRate/2;
        //DropItem();
    }

    private void Update() {
        /*
        time += Time.deltaTime;
        if(time >= 2){
            DropItem();
            time = 0;
        }
        */
    }

    public void DropItem(){
        float randNum = Random.Range(1f, 100f + 1);
        print(randNum + " : " + dropRate);
        if(randNum >= 50 - halfRate && randNum <= 50 + halfRate){
            int randNumInt = Random.Range(0, items.Length);
            GameObject insItem = Instantiate(items[randNumInt], transform.position, transform.rotation);
            //print("ok");
        }else{
            //print("salt");
        }
    }
}
