using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace trialgame
{
	public class Dijkstra
	{
		public Graph graph;
		
		public Dijkstra(Vector2 startingPoint, int width, int height, float interval) 
		{
			graph = new Graph(startingPoint, width, height, interval);
		}
		
		public List<Vector2> AStar(Vector2 startPosition, Vector2 targetPosition) {
			DNode2 startNode = graph.GetNode(startPosition);
			DNode2 targetNode = graph.GetNode(targetPosition);
            List<Vector2> positions = new List<Vector2>();
			PriorityQueue<DNode2> pq = new PriorityQueue<DNode2>();
			foreach (DNode2 d in graph.adjList.Keys)
			{
                d.Weight = 9999999;
				pq.Add(d);
			}
            startNode.Weight = 0;
			while (!pq.Empty())
			{
				DNode2 n = pq.Remove();
                positions.Add(n.Coords);
                if (n.Coords == targetPosition + new Vector2(80, 80))
                {
                    positions.TrimExcess();
                    return positions;
                }
				foreach (Edge e in graph.adjList[n])
				{
					DNode2 z = e.GetOpposite(n);
					double r = e.Weight + Vector2.Distance(z.Coords, targetPosition);
					if (r < z.Weight)
					{
						z.Weight = r;
                        try
                        {
                            pq.Remove(z);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
						pq.Add(z);
					}
				}
			}
            return positions;
		}
	}
}