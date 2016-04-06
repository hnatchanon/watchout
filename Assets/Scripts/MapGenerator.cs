using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {


    private static Quaternion[] direction = {
                                                new Quaternion(0,0.7f,0,0.7f),
                                                new Quaternion(0,1.0f,0,0),
                                                new Quaternion(0,0.7f,0,-0.7f),
                                                new Quaternion(0,0,0,-1.0f)
                                            };


    public static int[,,] numbers;
    public static int level, stage;

    public Transform player, floor, goal, star, slope, forceWalk, ladder, spring;
    public MovingPlane movingPlane;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < numbers.GetLength(0); i++) {
            for (int j = 0; j < numbers.GetLength(1); j++) {
                for (int k = 0; k < numbers.GetLength(2); k++) {
                    //way

                    // floor
                    if ((numbers[i, j, k] / 10) % 100 == 1) {
                        Transform tf = (Transform)Instantiate(floor, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    }
                    // goal
                    if ((numbers[i, j, k] / 10) % 100 == 2) {
                        Transform tf = (Transform)Instantiate(goal, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    }
                    // moving plane ---
                    if ((numbers[i, j, k] / 10) % 10 == 3) {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);

                        int length = (numbers[i, j, k] / 10) % 100 / 10;
                        Debug.Log("val: " + numbers[i, j, k]);
                        Debug.Log("length: " + length);

                        if (numbers[i, j, k] % 10 == 1) {
                            mp.direction = new Vector3(1f, 0f, 0f) * length;
                        }
                        else if (numbers[i, j, k] % 10 == 2) {
                            mp.direction = new Vector3(0f, 0f, 1f) * length;
                        }
                        else if (numbers[i, j, k] % 10 == 3) {
                            mp.direction = new Vector3(-1f, 0f, 0f) * length;
                        }
                        else if (numbers[i, j, k] % 10 == 0) {
                            mp.direction = new Vector3(0f, 0f, -1f) * length;
                        }
                    }
                    // moving plane |
                    if ((numbers[i, j, k] / 10) % 10 == 4) {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                        int length = (numbers[i, j, k] / 10) % 100 / 10;
                        mp.direction = new Vector3(0f, 1f, 0f) * length;
                    }
                    // slope
                    if ((numbers[i, j, k] / 10) % 100 == 5) {
                        Instantiate(slope, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    }

                    // force walk
                    if ((numbers[i, j, k] / 10) % 100 == 6) {
                        Instantiate(forceWalk, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    }

                    // ladder
                    if ((numbers[i, j, k] / 10) % 100 == 7) {
                        Instantiate(ladder, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                    }

                    // spring
                    if ((numbers[i, j, k] / 10) % 100 == 8) {
                        Instantiate(spring, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
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

    public static void nextLevel()
    {

        stage++;
        numbers = MapDataArray.getData()[level - 1][stage - 1];
        if(numbers == null)
        {
            level++;
            stage = 0;
            numbers = MapDataArray.getData()[level - 1][stage - 1];
        }
    }
}
