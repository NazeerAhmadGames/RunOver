﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralPrimitivesUtil
{
    public class Triangle : PPBase
    {
        public float width = 2;
        public float length = 2;
        public float offset = 0;
        public int widthSegs = 10;
        public int lengthSegs = 10;
        public bool uniformTriangle = true;
        public bool generateMappingCoords = true;
        public bool realWorldMapSize = false;
        public bool flipNormals = false;

        private void Start()
        {
            m_mesh.name = "Triangle";
        }

        protected override void CreateMesh()
        {
            width = Mathf.Clamp(width, 0.00001f, 10000.0f);
            length = Mathf.Clamp(length, 0.00001f, 10000.0f);
            offset = Mathf.Clamp(offset, -10000.0f, 10000.0f);
            if (uniformTriangle)
            {
                lengthSegs = widthSegs = Mathf.Clamp(widthSegs, 1, 100);
            }
            else
            {
                lengthSegs = Mathf.Clamp(lengthSegs, 1, 100);
                widthSegs = Mathf.Clamp(widthSegs, 1, 100);
            }

            if (uniformTriangle) CreateTriangle(Vector3.zero, Vector3.forward, Vector3.right, width, length, offset, lengthSegs, generateMappingCoords, realWorldMapSize, flipNormals);
            else CreateTriangle(Vector3.zero, Vector3.forward, Vector3.right, width, length, offset, widthSegs, lengthSegs, generateMappingCoords, realWorldMapSize, flipNormals);
        }
    }
}