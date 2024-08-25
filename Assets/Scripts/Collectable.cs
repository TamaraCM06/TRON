using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject stellaPrefab;
    [SerializeField] GameObject fuelPrefab;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject hypervelPrefab;
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] Transform[] allCells;

    void Start()
    {
        SpawnCollectable(10);
    }

    public void SpawnCollectable(int maxAttempts)
    {
        int collectablesSpawned = 0;
        int stellaSpawned = 0;
        int fuelSpawned = 0;
        int bombSpawned = 0;
        int shieldSpawned = 0;
        int hypervelSpawned = 0;


        for (int i = 0; i < maxAttempts; i++)
        {
            int probability = Random.Range(0, 10);
            int whichSpawn = Random.Range(0, allCells.Length);
            Debug.Log(probability);


            if (allCells[whichSpawn].childCount != 0)  
            {
                Debug.Log(allCells[whichSpawn].name + " is full");
                continue; 
            }


            //Generador de items en mapa


            if (probability <= 2)
            {
                if (stellaSpawned >= 3 && probability == 0) //Se asegura de que no se generen muchas instancias de stellas en el mapa
                {
                    Instantiate(stellaPrefab, allCells[whichSpawn]); // Genera item stella en mapa
                    Debug.Log("stellaItem spawned in " + allCells[whichSpawn].name);
                    stellaSpawned++;
                }
                else if (stellaSpawned < 3)
                {
                    Instantiate(stellaPrefab, allCells[whichSpawn]); 
                    Debug.Log("stellaItem spawned in " + allCells[whichSpawn].name);
                    stellaSpawned++;
                }
            }
            else if (2 < probability && probability <= 4)
            {
                if (fuelSpawned >= 3 && probability == 3) //Se asegura de que no se generen muchas instancias de fuel en el mapa
                {
                    Instantiate(fuelPrefab, allCells[whichSpawn]); // Genera item fuel en mapa
                    Debug.Log("fuelItem spawned in " + allCells[whichSpawn].name);
                    fuelSpawned++;
                }
                else if (fuelSpawned < 3)
                {
                    Instantiate(fuelPrefab, allCells[whichSpawn]);
                    Debug.Log("fuelItem spawned in " + allCells[whichSpawn].name);
                    fuelSpawned++;
                }
            }
            else if (4 < probability && probability <= 6)
            {
                if (bombSpawned >= 2 && probability == 5) //Se asegura de que no se generen muchas instancias de bomb en el mapa
                {
                    Instantiate(bombPrefab, allCells[whichSpawn]); // Genera item bomb en mapa
                    Debug.Log("bombItem spawned in " + allCells[whichSpawn].name);
                    bombSpawned++;
                }
                else if (bombSpawned < 2)
                {
                    Instantiate(bombPrefab, allCells[whichSpawn]);
                    Debug.Log("bombItem spawned in " + allCells[whichSpawn].name);
                    bombSpawned++;
                }
            }


            //Generador de poderes en mapa


            else if (6 < probability && probability <= 8)
            {
                if (hypervelSpawned >= 2 && probability == 7) //Se asegura de que no se generen muchas instancias de hypervelocidad en el mapa
                {
                    Instantiate(hypervelPrefab, allCells[whichSpawn]); // Genera poder hypervel en mapa
                    Debug.Log("hypervelPower spawned in " + allCells[whichSpawn].name);
                    hypervelSpawned++;
                }
                else if (stellaSpawned < 2)
                {
                    Instantiate(stellaPrefab, allCells[whichSpawn]);
                    Debug.Log("hypervelPower spawned in " + allCells[whichSpawn].name);
                    hypervelSpawned++;
                }
            }
            else
            {
                if (shieldSpawned >= 2 && probability == 9) //Se asegura de que no se generen muchas instancias de shield en el mapa
                {
                    Instantiate(shieldPrefab, allCells[whichSpawn]); // Genera poder shield en mapa
                    Debug.Log("shieldPower spawned in " + allCells[whichSpawn].name);
                    shieldSpawned++;
                }
                else if (shieldSpawned < 2)
                {
                    Instantiate(shieldPrefab, allCells[whichSpawn]);
                    Debug.Log("shieldPower spawned in " + allCells[whichSpawn].name);
                    shieldSpawned++;
                }
            }

            collectablesSpawned++;



            if (collectablesSpawned >= maxAttempts)
            {
                break;
            }
        }
    }


}
