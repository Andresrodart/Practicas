import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.ObjectInputStream;
import java.net.InetAddress;
import java.net.Socket;
// import java.util.Scanner;

public class Node {
	
	private final Double A[][], B[][], C[][];

	public Node(final int TamMatrix) {
		this.A = new Double[TamMatrix / 2][TamMatrix];
		this.B = new Double[TamMatrix / 2][TamMatrix];
		this.C = new Double[TamMatrix / 2][TamMatrix / 2];
	}

	public void solve() {
		try {
			// Scanner scn = new Scanner(System.in);

			// getting localhost ip
			final InetAddress ip = InetAddress.getByName("localhost");

			// establish the connection with server port 5056
			final Socket s = new Socket(ip, 5050);

			// obtaining input and out streams
			final DataInputStream dis = new DataInputStream(s.getInputStream());
			final DataOutputStream dos = new DataOutputStream(s.getOutputStream());
			final ObjectInputStream is = new ObjectInputStream(s.getInputStream());

			// the following loop performs the exchange of
			// information between client and client handler

			System.out.println(dis.readUTF());
			Matrix A = new Matrix((double[][]) is.readObject(), "A");
			Matrix B = new Matrix((double[][]) is.readObject(), "B");
			A.printMatrix();
			B.printMatrix();
			// String tosend = scn.nextLine();
			// dos.writeUTF(tosend);
			s.close();

			// closing resources
			// scn.close();
			dis.close();
			dos.close();
		} catch (final Exception e) {
            e.printStackTrace(); 
        }
	}
}