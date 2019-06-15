using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    //input requirements
    public string DesignType;
    public int Iterations = 0;
    public string ObjectType;
    public int arraySize=1024; //must be divisble by 2

    private int midPoint;
    private int[,] Pattern;
    private int[,] Rotated;
    private int[,] PixelPositions = new int[800000, 3];

    private int PixelCount = 0;
    private Vector2Int StartPos=new Vector2Int(0,0), EndPos = new Vector2Int(0, 0);
    private int minX = 0, maxX = 0, minY = 0, maxY = 0;
    private int RminX = 0, RmaxX = 0, RminY = 0, RmaxY = 0;



    void Start()
    {
        Pattern = new int[arraySize, arraySize];
        Rotated = new int[arraySize, arraySize];
        midPoint = (arraySize / 2) - 1;
    }


    void Update()
    {
        
    }

    void ClearFractals()
    {
        //reset Arrays & Vars
        
    }

    void Levy(int Steps)
    {
        for (int i = 0; i < Steps; i++)
        {
            if (i == 0) //setup starting pattern
            {
                Pattern[0, 0] = 2; //to indicate the Start Position
                Pattern[0, 1] = 1;
                Pattern[0, 2] = 3; //to indicate the End Position
                PixelCount += 3;
                minX = 0;
                maxX = 2;
                minY = 0;
                maxY = 0;
                StartPos= new Vector2Int(0, 0);
                EndPos = new Vector2Int(0, 3);
                
            }
            else
            {

            }


            Rotate();
            Reposition();
            CombineArrays();

        }
    }



    private void Rotate()
    {
        RmaxX = maxY;
        RmaxY = maxX;

        for (int j = minY; j < maxY; j++)
        {
            for (int i = minX; i <= maxX; i++)
            {
                Rotated[maxX-j, i] = Pattern[i, j];
                if (Pattern[i, j] == 2)
                {
                    StartPos= new Vector2Int(maxX-j,i);
                }
                
            }
        }

    }

    private void Reposition()
    {

    }

    private void CombineArrays()
    {
        int NewMaxX = maxX + RmaxX;
        int NewMaxY = 0;




        Debug.Log(NewMaxX + NewMaxY);

    }
}
