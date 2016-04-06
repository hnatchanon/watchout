﻿using UnityEngine;
using System.Collections.Generic;
using System;
public class MapDataArray : MonoBehaviour
{

    private static int[][,,] level1 = new int[][,,] {
        new int[,,] { // 1-1
	        {//floor 1
		        { 10,   10, 10,    0, 10,  0,  0,    0,  0,  0,    0,  0,  0},
		        { 10, 1010, 10, 2010, 10, 10, 10, 2010, 10, 10,   10, 10, 20},
		        { 10,   10, 10,    0, 10,  0,  0,    0,  0,  0,   10,  0,  0},
		        {  0,    0,  0,    0, 00,  0,  0,    0,  0,  0, 2010,  0,  0}
	        }
        },

        new int[,,] { // 1-2
            {//floor 1
		        { 10,    0,  0,   10, 10,  10, 0, 0,   10, 10, 10,  0,  0,  0,    0},
		        { 10, 1010, 10,   10, 10, 232, 0, 0, 2010, 10, 10, 62, 62, 10, 2231},
		        { 10,    0,  0, 2010, 10,  10, 0, 0,   10, 10, 10,  0,  0,  0,    0},
		        {  0,    0,  0,    0,  0,   0, 0, 0,    0,  0,  0,  0,  0,  0,    0},
		        {  0,    0,  0,    0,  0,   0, 0, 0,    0,  0,  0,  0,  0,  0,   20}
	        }
        },

        new int[,,] { // 1-3
	        {//floor 1
		        {  0,    0, 10, 10,  0,  0,   10,  0,  0,  0,    0,  0},
		        { 10, 1010, 10, 10, 10, 10,   10, 62, 62, 10,    0,  0},
		        {  0,    0, 10, 10,  0,  0, 2010,  0,  0, 10,    0,  0},
		        {  0,    0,  0,  0,  0,  0,    0,  0,  0, 10,   10, 10},
		        {  0,    0,  0,  0,  0,  0,    0,  0,  0, 10, 2070, 10},
		        {  0,    0,  0,  0,  0,  0,    0,  0,  0, 10,   10, 10}
	        },
	        {//floor 2
		        {  0,  0,  0,    0,  0,  0,   0,  0,  0,  0,  0, 0},
		        {  0,  0,  0, 2000,  0,  0, 330,  0,  0,  0,  0, 0},
		        {  0,  0,  0,    0,  0,  0,  10,  0,  0,  0,  0, 0},
		        { 10,  0,  0,    0,  0,  0,  10,  0,  0, 10, 10,10},
		        { 20, 10, 60,   60, 60, 10,  10, 60, 60, 10,  0,10},
		        { 10,  0,  0,    0,  0,  0,   0,  0,  0, 10, 10,10}
	        }
        },

        new int[,,] { // 1-4
            {//floor 1
		        {   20,    0,  0,    0,  0,  0,    0,  0,  0,  0,   0,   0},
		        {   10,   52,  0,    0,  0,  0,    0,  0,  0,  0,   0,   0},
		        {    0,    0,  0,    0,  0,  0,    0,  0,  0,  0,   0,   0},
		        {   10,    0,  0,    0,  0, 10,   10, 10,  0,  0,   0,   0},
		        { 1010,  132,  0, 2010, 10, 72,    0, 10, 10, 10,  10,  10},
		        {   10,    0,  0,    0,  0, 10,   10, 10,  0,  0,   0,  10},
		        {    0,    0,  0,    0,  0,  0,    0,  0,  0,  0,   0,  10},
		        {    0,    0,  0,    0,  0,  0,    0,  0,  0,  0,   0, 140},
		        {    0,    0,  0,    0,  0,  0,    0,  0,  0,  0,   0,   0}
	        },
	        {//floor 2
		        {    0,    0,  0,    0,   0,    0,    0,  0,  0,   0,   0,   0},
		        {    0,    0, 10,    0, 130,   10, 2010,  0,  0,   0,   0,   0},
		        {    0,    0,  0,    0,   0,    0,   10,  0,  0,   0,   0,   0},
		        {    0,    0,  0,    0,   0,    0,   10,  0,  0,   0,   0,   0},
		        {    0,    0,  0,    0,   0,    0,   10,  0,  0,   0,   0,   0},
		        {    0,    0,  0,    0,   0,    0,    0,  0,  0,   0,   0,   0},
		        {    0,    0,  0,    0,  10,   10,   10,  0,  0,   0,   0,   0},
		        {    0,    0,  0,    0,  10, 2010,   10, 10,  0, 130,  10,   0},
		        {    0,    0,  0,    0,  10,   10,   10,  0,  0,   0,   0,   0},
	        }
        }
    };

    private static int[,,] S01_L01 = {
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

    private static int[,,] S01_L02 ={
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



    private static int[][][,,]Data = new int[3][][,,];


    public static int[][][,,] getData()
    {
        Data[0] = level1;
        Data[1] = new int[10][,,];


        Data[1][0] = S01_L01;
        Data[1][1] = S01_L02;
        return Data;
    }


}
