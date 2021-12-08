using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    //The object the water will follow
    public GameObject boatObj;
    //One water square
    public GameObject waterSqrObj;

    //Water square data
    private float squareWidth = 100f;
    private float innerSquareResolution = 5f;
    private float outerSquareResolution = 5f;

    //The list with all water mesh squares == the entire ocean we can see
    List<WaterObj> waterSquares = new List<WaterObj>();

    // Start is called before the first frame update
    void Start()
    {
        CreateEndlessSea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEndlessSea()
    {
        //The center piece
        //Already exist
        AddWaterPlane(0f, 0f, 0f, squareWidth, innerSquareResolution);

        //The 8 squares around the center square
        for (int x = -1; x <= 1; x += 1)
        {
            for (int z = -1; z <= 1; z += 1)
            {
                //Ignore the center pos
                if (x == 0 && z == 0)
                {
                    continue;
                }

                //The y-Pos should be lower than the square with high resolution to avoid an ugly seam
                float yPos = -0.5f;
                AddWaterPlane(x * squareWidth, z * squareWidth, yPos, squareWidth, outerSquareResolution);
            }
        }
    }

    //Add one water plane
    void AddWaterPlane(float xCoord, float zCoord, float yPos, float squareWidth, float spacing)
    {
        GameObject waterPlane = Instantiate(waterSqrObj, transform.position, transform.rotation) as GameObject;

        waterPlane.SetActive(true);

        //Change its position
        Vector3 centerPos = transform.position;

        centerPos.x += xCoord;
        centerPos.y = yPos;
        centerPos.z += zCoord;

        waterPlane.transform.position = centerPos;

        //Parent it
        waterPlane.transform.parent = transform;

        //Give it moving water properties and set its width and resolution to generate the water mesh
        WaterObj newWaterSquare = new WaterObj(waterPlane, squareWidth, spacing);

        waterSquares.Add(newWaterSquare);
    }

}
