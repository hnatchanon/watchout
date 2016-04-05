using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {


    private static Quaternion[] direction = {
                                                new Quaternion(0,0.7f,0,0.7f),
                                                new Quaternion(0,1.0f,0,0),
                                                new Quaternion(0,0.7f,0,-0.7f),
                                                new Quaternion(0,0,0,-1.0f)
                                            };


    public static int[,,] numbers1 = {
    {//floor 1
		{ 0,  0,  0,  0,    0,  0,  0,  0, 0},
        { 0,  0,  0,  0,    0,  0,  0,  0, 0},
        { 0,  0,  0,  0,    0,  0,  0,  0, 0},
        { 0,  0,  0, 10,   10, 10,  0,  0, 0},
        { 0, 50, 10, 10, 1011, 10, 10, 52, 0},
        { 0,  0,  0, 10,   10, 10,  0,  0, 0},
        { 0,  0,  0,  0,   10,  0,  0,  0, 0},
        { 0,  0,  0,  0,   20,  0,  0,  0, 0},
        { 0,  0,  0,  0,    0,  0,  0,  0, 0}
    },
    {//floor 2
		{   10,  31, 0, 0, 2010,  31, 0, 0,   10},
        {    0,   0, 0, 0,    0,   0, 0, 0,   30},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {   32,   0, 0, 0,    0,   0, 0, 0,    0},
        { 2010,   0, 0, 0,    0,   0, 0, 0, 2010},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0}
    }
};

    public static int[,,] numbers2 = {
    {//floor 1
		{ 0,  0,  0,  0,    0,  0,  0,  0, 0},
        { 0,  0,  0,  0,    0,  0,  0,  0, 0},
        { 0,  0,  0,  0,    0,  0,  0,  0, 0},
        { 0,  0,  0, 10,   10, 10,  0,  0, 0},
        { 0, 50, 10, 10,   11, 10, 10, 52, 0},
        { 0,  0,  0, 10,   10, 10,  0,  0, 0},
        { 0,  0,  0,  0,   10,  0,  0,  0, 0},
        { 0,  0,  0,  0,   20,  0,  0,  0, 0},
        { 0,  0,  0,  0,    0,  0,  0,  0, 0}
    },
    {//floor 2
		{ 1010,  31, 0, 0, 2010,  31, 0, 0,   10},
        {    0,   0, 0, 0,    0,   0, 0, 0,   30},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {   32,   0, 0, 0,    0,   0, 0, 0,    0},
        { 2010,   0, 0, 0,    0,   0, 0, 0, 2010},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0},
        {    0,   0, 0, 0,    0,   0, 0, 0,    0}
    }
};

    public static int[,,] numbers;

    public Transform player, floor, goal, star, slope;
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
                    if ((numbers[i, j, k] / 10) % 100 == 3) {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                        if (numbers[i, j, k] % 10 == 0) {
                            mp.direction = new Vector3(2f, 0f, 0f);
                        }
                        else if (numbers[i, j, k] % 10 == 1) {
                            mp.direction = new Vector3(0f, 0f, 2f);
                        }
                        else if (numbers[i, j, k] % 10 == 2) {
                            mp.direction = new Vector3(-2f, 0f, 0f);
                        }
                        else if (numbers[i, j, k] % 10 == 3) {
                            mp.direction = new Vector3(0f, 0f, -2f);
                        }
                    }
                    // moving plane |
                    if ((numbers[i, j, k] / 10) % 100 == 4) {
                        MovingPlane mp = (MovingPlane)Instantiate(movingPlane, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
                        mp.direction = new Vector3(0f, 1f, 0f);
                    }
                    // slope
                    if ((numbers[i, j, k] / 10) % 100 == 5) {
                        Instantiate(slope, new Vector3(j * 4, i * 4, k * 4), direction[numbers[i, j, k] % 10]);
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
