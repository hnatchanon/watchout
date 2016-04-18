using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{


    private static Quaternion[] direction = {
                                                new Quaternion(0,0.7f,0,0.7f),
                                                new Quaternion(0,1.0f,0,0),
                                                new Quaternion(0,0.7f,0,-0.7f),
                                                new Quaternion(0,0,0,-1.0f)
                                            };


    public static int[,,] numbers;
    public static int level, stage;

    public Transform player, floor, goal, star, slope, forceWalk, ladder, spring, wall1, wall2, wall3, rotatingFloor, narrowFloor;
    public MovingPlane movingPlane;
    public Warp warp;

    // Use this for initialization
    void Start()
    {
        Transform[] stars = new Transform[3];
        int tmpCnt = 0;

        Minimap minimap = new Minimap();

        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            for (int j = 0; j < numbers.GetLength(1); j++)
            {
                for (int k = 0; k < numbers.GetLength(2); k++)
                {
                    //way

                    // floor
                    if ((numbers[i, j, k] / 10) % 100 == 1)
                    {
                        Transform tf = (Transform)Instantiate(floor, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }
                    // wall1
                    if ((numbers[i, j, k] / 10) % 100 == 11)
                    {
                        Transform tf = (Transform)Instantiate(wall1, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }
                    // wall2
                    if ((numbers[i, j, k] / 10) % 100 == 21)
                    {
                        Transform tf = (Transform)Instantiate(wall2, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }
                    // wall3
                    if ((numbers[i, j, k] / 10) % 100 == 31)
                    {
                        Transform tf = (Transform)Instantiate(wall3, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }
                    // goal
                    if ((numbers[i, j, k] / 10) % 100 == 2)
                    {
                        Transform tf = (Transform)Instantiate(goal, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }
                    // moving plane ---
                    if ((numbers[i, j, k] / 10) % 10 == 3)
                    {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);

                        int length = (numbers[i, j, k] / 10) % 100 / 10;
                        Debug.Log("val: " + numbers[i, j, k]);
                        Debug.Log("length: " + length);

                        if (numbers[i, j, k] % 10 == 1)
                        {
                            mp.direction = new Vector3(1f, 0f, 0f) * length;
                        }
                        else if (numbers[i, j, k] % 10 == 2)
                        {
                            mp.direction = new Vector3(0f, 0f, 1f) * length;
                        }
                        else if (numbers[i, j, k] % 10 == 3)
                        {
                            mp.direction = new Vector3(-1f, 0f, 0f) * length;
                        }
                        else if (numbers[i, j, k] % 10 == 0)
                        {
                            mp.direction = new Vector3(0f, 0f, -1f) * length;
                        }
                    }
                    // moving plane |
                    if ((numbers[i, j, k] / 10) % 10 == 4)
                    {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                        int length = (numbers[i, j, k] / 10) % 100 / 10;
                        mp.direction = new Vector3(0f, 1f, 0f) * length;
                    }
                    // slope
                    if ((numbers[i, j, k] / 10) % 100 == 5)
                    {
                        Instantiate(slope, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }

                    // force walk
                    if ((numbers[i, j, k] / 10) % 100 == 6)
                    {
                        Instantiate(forceWalk, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }

                    // ladder
                    if ((numbers[i, j, k] / 10) % 100 == 7)
                    {
                        Instantiate(ladder, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }

                    // spring
                    if ((numbers[i, j, k] / 10) % 100 == 8)
                    {
                        Instantiate(spring, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }

                    // warp
                    if ((numbers[i, j, k] / 10) % 10 == 9)
                    {
                        int tmp = numbers[i, j, k] / 100;
                        int t_z = tmp % 100;
                        tmp /= 100;
                        int t_y = tmp % 100;
                        tmp /= 100;
                        int t_x = tmp;
                        Warp wp = (Warp)Instantiate(warp, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                        wp.DestinationPosition = new Vector3(t_x, t_y, t_z) * 4;
                    }

                    // rotating floor
                    if ((numbers[i, j, k] / 10) % 100 == 12)
                    {
                        Instantiate(rotatingFloor, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }

                    // narrow floor
                    if ((numbers[i, j, k] / 10) % 100 == 15)
                    {
                        Instantiate(narrowFloor, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                    }

                    //player & star
                    if ((numbers[i, j, k] / 1000) % 10000000 == 1)
                    {
                        Transform tmpPlayer = (Transform)Instantiate(player, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                        minimap = tmpPlayer.GetComponentInChildren<Minimap>();
                        Debug.Log(minimap);

                    }
                    if ((numbers[i, j, k] / 1000) % 10000000 == 2)
                    {
                        Transform tmpStar = (Transform)Instantiate(star, new Vector3(j, i, k) * 4, direction[numbers[i, j, k] % 10]);
                        stars[tmpCnt++] = tmpStar;
                    }

                }
            }
        }


        for (int i = 0; i < 3; i++)
        {
            Debug.Log(minimap);
            minimap.GenerateBlip(stars[i].gameObject);
        }
    }

    public static void nextLevel()
    {

        stage++;
        numbers = MapDataArray.getData()[level - 1][stage - 1];
        if (numbers == null)
        {
            level++;
            stage = 0;
            numbers = MapDataArray.getData()[level - 1][stage - 1];
        }
    }
}
