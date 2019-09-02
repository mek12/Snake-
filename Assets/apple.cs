using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class apple : MonoBehaviour {

    public Text skor_txt;
    int skor = 0;


    movement generate_tile;
    private void Start()
    {
        generate_tile = GameObject.Find("bas").GetComponent<movement>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="bas")
        {
            skor = +10;
            skor_txt.text = "SKOR" + skor;

            replace_coordinate();

            generate_tile.extra_tile();

        }
        if (other.gameObject.tag == "tile")
        {
           

            replace_coordinate();

        }
    }
    void replace_coordinate()
    {
        float x_value = Random.Range(-20.0f, 17.0f);
        float z_value = Random.Range(0f, +20.0f);
        transform.position = new Vector3(x_value, 0, z_value);
    }
  
}
