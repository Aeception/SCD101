using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject trianglePrefab;
    public GameObject squarePrefab;
    public Transform startingPosition;
    public float defaultWaitTime = 0.75f;
    List<string> R1 = new List<string> {"c1", "w2", "4c1", "w1", "s1", "c1", "w1", "2c1", "w1", "2c1"};
    List<string> R2 = new List<string> {"c3", "t2", "w2", "s4", "2c1", "5c3", "w1", "2c3", "w1", "c5", "w1"};
    List<string> R3 = new List<string> {"5c1", "w5", "5c1", "w3"};
    List<string> R4 = new List<string> {"3c1", "w1", "2c2", "2c3", "w1", "1c6"};
    List<string> R5 = new List<string> {"2c3", "4c1", "1c6", "w3", "1c3", "1c6"};
    // 4c1 , 4 is amount spawned, c1 is type, w2 wait how much seconds t "2" = the STRENGTH (color)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnlevel(R5));
    }
    IEnumerator spawnlevel(List <string> round)
    {
        foreach(string code in round)
        {
            int amount = 1;
            string opptype = "c";
            int level = 1;
            //extract spawn info from code, opps info got leaked
            if(code.Length == 2)
            {
                opptype = code.Substring(0, 1);
                level = int.Parse (code.Substring(1, 1));
            }
            else
            {
                amount = int.Parse(code.Substring(0, 1));
                opptype = code.Substring(1, 1);
                level = int.Parse(code.Substring(2, 1));
            }
            //SPAWNING THE OPPS
            if(opptype == "w")
            {
                yield return new WaitForSeconds(level);
            }
            else
            {
                for(int i = 1; i<= amount; i++)
                {
                    GameObject newopp;
                    if(opptype == "c")
                    {
                        newopp = Instantiate(circlePrefab);
                    }

                    else if(opptype == "s")
                    {
                        newopp = Instantiate(squarePrefab);
                    }
                    else if(opptype == "t")
                    {
                        newopp = Instantiate(trianglePrefab);
                    } 
                    else{
                        newopp = Instantiate(circlePrefab);
                    }
                    newopp.transform.position = startingPosition.position;
                    newopp.GetComponent<Enemy>().popcount = level;
                    newopp.GetComponent<Enemy>().speed = level;
                    yield return new WaitForSeconds(defaultWaitTime);
                }
            }
        }
    }
}
