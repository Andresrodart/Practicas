/**
 * TokenRing
 */
public class TokenRing {

	public static void main(String[] args) {
		int node = 4;
		if (args.length > 0) {
			try {
				node = Integer.parseInt(args[0]);
			} catch (NumberFormatException e) {
				System.exit(1);
			}
		//Else we execute the client code
		}
		Node n = new Node(node);
		n.__start();
    }
}