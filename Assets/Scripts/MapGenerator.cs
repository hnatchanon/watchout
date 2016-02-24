using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {


    private static Quaternion[] direction = {
                                                new Quaternion(0,0,0,0),
                                                new Quaternion(0,90,0,0),
                                                new Quaternion(0,180,0,0),
                                                new Quaternion(0,270,0,0)
                                            };
    private int[, , ,] numbers = {
                                       {//floor 1
                                           {{1,0}, {1,0}, {1,0}, {1,0}, {1,0}, {1,0}},
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {1,0}},
                                           {{2,2}, {0,0}, {0,0}, {0,0}, {0,0}, {1,0}},
                                           {{1,0}, {0,0}, {0,0}, {0,0}, {0,0}, {1,0}},
                                           {{1,0}, {0,0}, {0,0}, {0,0}, {0,0}, {1,0}},
                                           {{1,0}, {1,0}, {1,0}, {1,0}, {1,0}, {1,0}}
                                       },
                                       {//floor 2
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}},
                                           {{1,0}, {1,0}, {1,0}, {1,0}, {1,0}, {0,0}},
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {1,0}, {0,0}},
                                           {{0,0}, {2,2}, {0,0}, {0,0}, {1,0}, {0,0}},
                                           {{0,0}, {1,0}, {1,0}, {1,0}, {1,0}, {0,0}},
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}}
                                       },
                                       {//floor 2
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}},
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}},
                                           {{0,0}, {1,0}, {1,0}, {1,0}, {0,0}, {0,0}},
                                           {{0,0}, {0,0}, {1,0}, {3,0}, {0,0}, {0,0}},
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}},
                                           {{0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}}
                                       }
                                 };

    public Transform player, floor, slope;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < numbers.GetLength(0); i++) {
            for (int j = 0; j < numbers.GetLength(1); j++) {
                for (int k = 0; k < numbers.GetLength(2); k++) {
                    if (numbers[i, j, k, 0] == 1)
                        Instantiate(floor, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k, 1]]);
                    if (numbers[i, j, k, 0] == 2)
                        Instantiate(slope, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k, 1]]);
                    if (numbers[i, j, k, 0] == 3) {
                        Instantiate(floor, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k, 1]]);
                        Instantiate(player, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k, 1]]);
                    }
                        
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
