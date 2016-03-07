using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {


    private static Quaternion[] direction = {
                                                new Quaternion(0,0,0,0),
                                                new Quaternion(0,90,0,0),
                                                new Quaternion(0,180,0,0),
                                                new Quaternion(0,270,0,0)
                                            };
    private int[, ,] numbers = {
                                       {//floor 1
                                           {10,   10, 10, 0,  2010,    0,  0,  0},
                                           {10, 1010, 10, 10,   10,   10, 10,  0},
                                           {10,   10, 10,  0,    0,    0, 10,  0},
                                           { 0,    0,  0,  0,    0,    0, 10,  0},
                                           { 0,    0,  0,  0,    0,    0,  0, 33},
                                           { 0,    0,  0,  0,    0,   31,  0,  0},
                                           { 0,    0,  0,  0,    0,    0, 10,  0},
                                           { 0,    0,  0,  0,    0, 2010, 10,  0},
                                           { 0,    0,  0,  0,    0,    0, 10,  0},
                                           { 0,    0,  0,  0,    0,    0, 40,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0}
                                       },
                                       {//floor 2
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0,    0,  0,  0,    0,    0,  0,  0},
                                           { 0, 2010, 10, 10,   10,   10, 10,  0},
                                       }
                                 };

    public Transform player, floor, goal, star;
    public MovingPlane movingPlane;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < numbers.GetLength(0); i++) {
            for (int j = 0; j < numbers.GetLength(1); j++) {
                for (int k = 0; k < numbers.GetLength(2); k++) {
                    //way
                    if ((numbers[i, j, k] / 10) % 100 == 1) {
                        Instantiate(floor, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                        Debug.Log(direction[numbers[i, j, k] % 10]);
                    }
                    if ((numbers[i, j, k] / 10) % 100 == 2)
                        Instantiate(goal, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    if ((numbers[i, j, k] / 10) % 100 == 3) {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                        if (numbers[i, j, k] % 10 == 0) {
                            mp.direction = new Vector3(1f, 0f, 0f);
                        }
                        else if (numbers[i, j, k] % 10 == 1) {
                            mp.direction = new Vector3(0f, 0f, 1f);
                        }
                        else if (numbers[i, j, k] % 10 == 2) {
                            mp.direction = new Vector3(-1f, 0f, 0f);
                        }
                        else if (numbers[i, j, k] % 10 == 3) {
                            mp.direction = new Vector3(0f, 0f, -1f);
                        }
                        mp.movingLength = 2;
                    }
                    if ((numbers[i, j, k] / 10) % 100 == 4) {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                        mp.direction = new Vector3(0f, 1f, 0f);
                        mp.movingLength = 1;
                    }

                    //player & star
                    if ((numbers[i, j, k] / 1000) % 100 == 1)
                        Instantiate(player, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    if ((numbers[i, j, k] / 1000) % 100 == 2)
                        Instantiate(star, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);

                }
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
