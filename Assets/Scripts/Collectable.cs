using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject fuelPrefab;
    [SerializeField] Transform[] allCells;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCollectable();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnCollectable();
        //}
    }

    public void SpawnCollectable()
    {

        float prob = Random.Range(0.0f, 1.0f);
        Debug.Log(prob);
        int whichSpawn = Random.Range(0, allCells.Length);

        for (int i = 0; i < 10; i++)
        {
            if (allCells[whichSpawn].childCount != 0)
            {
                Debug.Log(allCells[whichSpawn].name + "is already full");
                prob = 0.2f;
                SpawnCollectable();
            }


            if (prob <= 0.2f)
            {
                return;
            }
            else if (prob <= 0.8f)
            {
                GameObject tempFill = Instantiate(fuelPrefab, allCells[whichSpawn]);
                Debug.Log("powwre");
            }
            else
            {
                GameObject tempFill = Instantiate(fuelPrefab, allCells[whichSpawn]);
                Debug.Log("item");
            }
        }
    }
}
