/* 
*
* Node Class
* By: Andrès Rodarte López
* Distributed matrix multiplication
*
*/
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.InetAddress;
import java.net.Socket;

//Client Class
public class Node {
	
	private Matrix A, B;
	private double result[][];

	public Node(final int TamMatrix) {
		this.result = new double[TamMatrix / 2][TamMatrix / 2];
	}

	public void solve() {
		try {
			final InetAddress ip = InetAddress.getByName("localhost");

			// establish the connection with server port 5056
			final Socket s = new Socket(ip, 5050);

			// obtaining input and out streams
			final DataInputStream dis = new DataInputStream(s.getInputStream());
			final ObjectInputStream is = new ObjectInputStream(s.getInputStream());
			final ObjectOutputStream os = new ObjectOutputStream(s.getOutputStream());

			//Recive number of node, Matrix A and Matrix B
			System.out.println(dis.readUTF());
			A = new Matrix((double[][]) is.readObject(), "A");
			B = new Matrix((double[][]) is.readObject(), "B");

			//Perform the multiplication
			for (int i = 0; i < this.A.length; i++) {
				for (int j = 0; j < this.B.length; j++) {
					for (int j2 = 0; j2 < this.B.getValue(i).length; j2++) {
						result[i][j] +=  A.getValue(i, j2) * B.getValue(j, j2);
					}
				}
			}

			//Send result
			os.writeObject(result);
			os.flush();
			
			//Close all conexions
			dis.close();
			is.close();
			os.close();
			s.close();
		} catch (final Exception e) {
            e.printStackTrace(); 
        }
	}
}