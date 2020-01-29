public class DistributedMatrixMul {
	
    public static void main (String[] args) {
		int TamMatrix = 4, nodes = 4;
		/*	If we recive a parameter this indicates it will be the server
			and he will initialice and send the chunks of the matrix
			all the other will be clients, and they will recibe teh chunks 
			to perfom the multiplication
		*/
		if (args.length > 0) {
			try {
				nodes = Integer.parseInt(args[1]);
				TamMatrix = Integer.parseInt(args[0]);
				System.out.println("Size of Matrix: " + TamMatrix + " with : " + nodes + " nodes");
			} catch (NumberFormatException e) {
				System.err.println("One or mores arguments are not an integer or missing.");
				System.exit(1);
			}

			NodeZero n0 = new NodeZero(TamMatrix, nodes);
		}else{
			//Node node = new Node();
		}
    }
}