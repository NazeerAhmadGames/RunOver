﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralPrimitivesUtil
{
    public class RectTube : PPBase
    {
        public float width1 = 1.0f;
        public float width2 = 0.6f;
        public float length1 = 1.0f;
        public float length2 = 0.6f;
        public float height = 1.0f;
        public bool cap1 = false;
        public float capThickness1 = 0.2f;
        public bool cap2 = false;
        public float capThickness2 = 0.2f;
        public int widthSegs = 2;
        public int lengthSegs = 2;
        public int heightSegs = 2;
        public int capSegs = 2;
        public bool generateMappingCoords = true;
        public bool realWorldMapSize = false;
        public bool flipNormals = false;

        private void Start()
        {
            m_mesh.name = "RectTube";
        }

        protected override void CreateMesh()
        {
            length1 = Mathf.Clamp(length1, 0.00001f, 10000.0f);
            width1 = Mathf.Clamp(width1, 0.00001f, 10000.0f);
            length2 = Mathf.Clamp(length2, 0.00001f, length1);
            width2 = Mathf.Clamp(width2, 0.00001f, width1);
            height = Mathf.Clamp(height, 0.00001f, 10000.0f);
            if (cap1)
            {
                capThickness1 = Mathf.Clamp(capThickness1, 0.00001f, height);
                capThickness2 = Mathf.Clamp(capThickness2, 0.00001f, height - capThickness1);
            }
            else
            {
                capThickness1 = Mathf.Clamp(capThickness1, 0.00001f, height);
                capThickness2 = Mathf.Clamp(capThickness2, 0.00001f, height);
            }
            lengthSegs = Mathf.Clamp(lengthSegs, 1, 100);
            widthSegs = Mathf.Clamp(widthSegs, 1, 100);
            heightSegs = Mathf.Clamp(heightSegs, 1, 100);
            capSegs = Mathf.Clamp(capSegs, 1, 100);

            float hDown = cap1 ? capThickness1 : 0.0f;
            float hUp = cap2 ? capThickness2 : 0.0f;
            float lengthHalf1 = length1 * 0.5f;
            float widthHalf1 = width1 * 0.5f;
            float lengthHalf2 = length2 * 0.5f;
            float widthHalf2 = width2 * 0.5f;
            float heightHalf = height * 0.5f;

            CreatePlane(new Vector3(0.0f, 0.0f, -lengthHalf1), Vector3.up, Vector3.right, width1, height, widthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, flipNormals);
            CreatePlane(new Vector3(0.0f, 0.0f, lengthHalf1), Vector3.up, Vector3.left, width1, height, widthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, flipNormals);
            CreatePlane(new Vector3(-widthHalf1, 0.0f, 0.0f), Vector3.up, Vector3.back, length1, height, lengthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, flipNormals);
            CreatePlane(new Vector3(widthHalf1, 0.0f, 0.0f), Vector3.up, Vector3.forward, length1, height, lengthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, flipNormals);

            float h = height - hUp - hDown;
            float ch = (hDown - hUp) * 0.5f;
            CreatePlane(new Vector3(0.0f, ch, -lengthHalf2), Vector3.up, Vector3.right, width2, h, widthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, !flipNormals);
            CreatePlane(new Vector3(0.0f, ch, lengthHalf2), Vector3.up, Vector3.left, width2, h, widthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, !flipNormals);
            CreatePlane(new Vector3(-widthHalf2, ch, 0.0f), Vector3.up, Vector3.back, length2, h, lengthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, !flipNormals);
            CreatePlane(new Vector3(widthHalf2, ch, 0.0f), Vector3.up, Vector3.forward, length2, h, lengthSegs, heightSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, !flipNormals);

            float w = (widthHalf1 + widthHalf2) * 0.5f;
            float l = (lengthHalf1 + lengthHalf2) * 0.5f;
            float wdif = widthHalf1 - widthHalf2;
            float ldif = lengthHalf1 - lengthHalf2;
            if (cap1)
            {
                CreatePlane(new Vector3(0.0f, -heightHalf, 0.0f), Vector3.forward, Vector3.left, width1, length1, widthSegs, lengthSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, flipNormals);
                CreatePlane(new Vector3(0.0f, -heightHalf + hDown, 0.0f), Vector3.forward, Vector3.left, width2, length2, widthSegs, lengthSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, !flipNormals);
            }
            else
            {
                CreateTrapezoid(new Vector3(0.0f, -heightHalf, -l), Vector3.forward, Vector3.right, width1, width2, ldif, 0.0f, widthSegs, 1, generateMappingCoords, realWorldMapSize, !flipNormals);
                CreateTrapezoid(new Vector3(0.0f, -heightHalf, l), Vector3.back, Vector3.left, width1, width2, ldif, 0.0f, widthSegs, 1, generateMappingCoords, realWorldMapSize, !flipNormals);
                CreateTrapezoid(new Vector3(-w, -heightHalf, 0.0f), Vector3.right, Vector3.back, length1, length2, wdif, 0.0f, lengthSegs, 1, generateMappingCoords, realWorldMapSize, !flipNormals);
                CreateTrapezoid(new Vector3(w, -heightHalf, 0.0f), Vector3.left, Vector3.forward, length1, length2, wdif, 0.0f, lengthSegs, 1, generateMappingCoords, realWorldMapSize, !flipNormals);
            }
            if (cap2)
            {
                CreatePlane(new Vector3(0.0f, heightHalf, 0.0f), Vector3.forward, Vector3.right, width1, length1, widthSegs, lengthSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, flipNormals);
                CreatePlane(new Vector3(0.0f, heightHalf - hUp, 0.0f), Vector3.forward, Vector3.right, width2, length2, widthSegs, lengthSegs, generateMappingCoords, realWorldMapSize, Vector2.zero, Vector2.one, !flipNormals);
            }
            else
            {
                CreateTrapezoid(new Vector3(0.0f, heightHalf, -l), Vector3.forward, Vector3.right, width1, width2, ldif, 0.0f, widthSegs, 1, generateMappingCoords, realWorldMapSize, flipNormals);
                CreateTrapezoid(new Vector3(0.0f, heightHalf, l), Vector3.back, Vector3.left, width1, width2, ldif, 0.0f, widthSegs, 1, generateMappingCoords, realWorldMapSize, flipNormals);
                CreateTrapezoid(new Vector3(-w, heightHalf, 0.0f), Vector3.right, Vector3.back, length1, length2, wdif, 0.0f, lengthSegs, 1, generateMappingCoords, realWorldMapSize, flipNormals);
                CreateTrapezoid(new Vector3(w, heightHalf, 0.0f), Vector3.left, Vector3.forward, length1, length2, wdif, 0.0f, lengthSegs, 1, generateMappingCoords, realWorldMapSize, flipNormals);
            }
        }
    }
}