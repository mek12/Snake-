using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {

    public GameObject Tile;
    List<GameObject> Tiles;
    Vector3 old_coordinate;
    GameObject old_tile;
    float speed = 15.0f;

    public GameObject finish_pnl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="engel")
        {
            finish_pnl.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void try_again()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("lvl1");
    }


    void Start ()
    {
        Tiles = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject new_tile = Instantiate(Tile, transform.position, Quaternion.identity);
            Tiles.Add(new_tile);
            
        }
        InvokeRepeating("run", 0.0f, 0.1f);

    }
 
    void run()
    {
        old_coordinate = transform.position;
        transform.Translate(0, 0, speed * Time.deltaTime);
        tail_tracking();
    }

    void tail_tracking()
    {
        Tiles[0].transform.position = old_coordinate;
        old_tile = Tiles[0];
        Tiles.RemoveAt(0);
        Tiles.Add(old_tile);

    }
    public void turn(float angle)
    {
        transform.Rotate(0, angle, 0);
    }

    public void extra_tile()
    {
        GameObject new_tile = Instantiate(Tile, transform.position, Quaternion.identity);
        Tiles.Add(new_tile);
    }
}
