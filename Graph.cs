using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Xna.Framework;

namespace trialgame {

	public class Graph
	{
		public Dictionary<DNode2, List<Edge>> adjList;
	
		public Graph (Vector2 startingPoint, int width, int height, float interval)
		{
			adjList = new Dictionary<DNode2, List<Edge>>();
			float minX = startingPoint.X;
			float minY = startingPoint.Y;
			float maxX = startingPoint.X + (width * interval);
			float maxY = startingPoint.Y + (height * interval);
			Vector2 testVec = new Vector2(minX, minY);
            DNode2 newNode = new DNode2(testVec);
            adjList.Add(newNode, new List<Edge>());
			Vector2 between = Vector2.Zero;
			for (float x = minX; x <= maxX; x += interval) {
				for (float y = minY; y <= maxY; y += interval) {
					newNode = new DNode2(x, y);
					if (y != minY) {
						testVec.X = x;
						testVec.Y = y - interval;
						CheckAndConnect(testVec, newNode);
					}
					if (x != minX) {
						testVec.X = x - interval;
						testVec.Y = y;
						CheckAndConnect (testVec, newNode);
					}
				}
			}
		}
	
		public void AddToMap (DNode2 n, Edge e) 
		{
			List<Edge> edges = null;
			if (adjList.ContainsKey(n)) {
				edges = adjList[n];
                edges.Add(e);
                adjList[n] = edges;
			} else {
				edges = new List<Edge>();
                edges.Add(e);
                adjList.Add(n, edges);
			}
		}

        public bool isObstructed(Vector2 start, Vector2 end)
        {
            return false;
        }

		public void CheckAndConnect (Vector2 vec, DNode2 node)
		{
			if (!isObstructed(vec, node.Coords)) { //condition for connectivity here
				DNode2 n = GetNode (vec);
				Edge newEdge = new Edge(node, n);
				AddToMap(node, newEdge);
				AddToMap(n, newEdge);
			}
		}
	
		public DNode2 GetNode(Vector2 coord) 
		{
			foreach (DNode2 n in adjList.Keys) 
			{
				if (n.Coords == coord) {
					return n;
				}
			}
			return null;
		}
	}

}