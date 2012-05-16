using System;

namespace trialgame {

	public class Edge
	{
	    private DNode2 n1;
	    private DNode2 n2;

	    public double Weight { get; set; }

		public Edge(DNode2 node1, DNode2 node2)
		{
	        n1 = node1;
	        n2 = node2;
	        Weight = n1.CalculateWeight(n2);
		}

	    public DNode2 GetOpposite(DNode2 node)
	    {
	        if (n1 == node)
	        {
	            return n2;
	        }
	        if (n2 != node)
	        {
	            throw new ArgumentException();
	        }
	        return n1;
	    }
	}
}
