/* 
*
* Node Zero Class
* By: Andrès Rodarte López
* Distributed matrix multiplication
*
*/
import java.net.ServerSocket;
import java.net.Socket;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class NodeZero {
	private static int n = 0;
	private static Matrix A, B, C;
	private int TamMatrix = 4, nodes = 4;
	private static Object lock = new Object();

	public NodeZero(final int TamMatrix, final int nodes) {
		this.TamMatrix = TamMatrix;
		this.nodes = nodes;
		A = new Matrix(this.TamMatrix, "A");
		B = new Matrix(this.TamMatrix, "B");
		C = new Matrix(this.TamMatrix, "C");
		for (int i = 0; i < this.TamMatrix; i++)
			for (int j = 0; j < this.TamMatrix; j++) {
				A.setValue(i, j, 2.0 * i + j);
				B.setValue(i, j, 2.0 * i - j);
			}

		B.transpose();
		if(A.length < 10) A.printMatrix();
		if(B.length < 10)B.printMatrix();
	}

	public void solve() {
		//Opne server Socket
		try (ServerSocket serverSocket = new ServerSocket(5050)) {
			System.out.println("Server is listening on port " + 5050);
			for (int i = 0; i < this.nodes - 1; i++) {

				final Socket nodeClient = serverSocket.accept();
				System.out.println("A new client is connected : " + nodeClient);

				// obtaining input and out streams
				final DataInputStream dis = new DataInputStream(nodeClient.getInputStream());
				final DataOutputStream dos = new DataOutputStream(nodeClient.getOutputStream());

				System.out.println("Assigning new thread for this client");

				// create a new thread object to handle the conexion, we are giving the client number
				final Thread t = new ConexionHandler(nodeClient, dis, dos, i + 1);

				// Invoking the start() method
				t.start();
			}
			//Calculate our first part of the matrix
			final Matrix aux = new Matrix(this.TamMatrix / 2);
			for (int i = 0; i < this.TamMatrix / 2; i++) {
				for (int j = 0; j < this.TamMatrix / 2; j++) {
					for (int j2 = 0; j2 < this.TamMatrix; j2++) {
						aux.sumValue(i, j, A.getValue(i, j2) * B.getValue(j, j2));
					}
				}
			}
			//Save the partial result
			synchronized (lock) {
				for (int i = 0; i < aux.length; i++) {
					for (int j = 0; j < aux.length; j++) {
						C.setValue(i, j, aux.getValue(i, j));
					}
				}
				NodeZero.n++;
			}
			//Wait till all nodes ends calculations
			while (true) {
				synchronized (lock) {
					if (n == 4) {
						break;
					}
					try {
						Thread.sleep(100);
					} catch (final InterruptedException e) {
						e.printStackTrace();
					}
				}
			}
			//Print result if posible and print the checksum
			if(C.length < 10) C.printMatrix();
			System.out.println(C.checkSum());
		} catch (final IOException ex) {
			System.out.println("Server exception: " + ex.getMessage());
			ex.printStackTrace();
		}
	}
	/***************************************************
	 * 
	 * Conexion Handler Class
	 * Its inside so it can see NodeZero Static varaibles
	 * 
	 ***************************************************/
	public class ConexionHandler extends Thread{
		private int n = 0;
		private ObjectInputStream is;
		private ObjectOutputStream os;
		private final Socket conexion;
		private final DataInputStream dis;
		private final DataOutputStream dos;

		public ConexionHandler(final Socket conexion, final DataInputStream dis, final DataOutputStream dos, final int n) {
			super();
			this.n = n;
			this.dis = dis;
			this.dos = dos;
			this.conexion = conexion;
			System.out.println("Starting node: " + this.n);
		}

		public void run() {
			try {
				/**Always create fisrt the objectOutputStream */
				this.os = new ObjectOutputStream(conexion.getOutputStream());
				this.is = new ObjectInputStream(conexion.getInputStream());
				int rowB = (this.n == 2)? 0 : NodeZero.A.length / 2;
				int rowA = (this.n == 1)? 0 : NodeZero.A.length / 2;
				double[][] aux = new double[NodeZero.A.length / 2][NodeZero.B.length];
				//Send the number of node to the client just for reference in output
				dos.writeUTF(this.n + " ");
				for (int i = 0; i < aux.length; i++) {
					aux[i] = A.getValue(rowA + i);
				}
				
				//Send the part of Matrix A
				os.writeObject(aux);
				os.flush();
				aux = new double[NodeZero.A.length / 2][NodeZero.B.length];
				
				//Send the part of Matrix B
				for (int i = 0; i < aux.length; i++) {
					aux[i] = B.getValue(rowB + i);
				}
				os.writeObject(aux);
				os.flush();
				double[][] result = new double[NodeZero.A.length / 2][NodeZero.B.length / 2];
				
				//Recive the partial result
				try {
					result = (double[][]) is.readObject();
				} catch (Exception e) {
					System.err.println(e);
				}

				//Save the partial result
				synchronized (lock) {
					for (int i = 0; i < NodeZero.A.length / 2; i++) {
					 	for (int j = 0; j < NodeZero.A.length / 2; j++) {
					 		NodeZero.C.setValue(i + rowA, j + rowB, result[i][j]);
					 	}
					}
					NodeZero.n++;
				}
				os.close();
				conexion.close();

			} catch (final IOException e) {
				e.printStackTrace();
			}

			try {
				// closing resources
				this.dis.close();
				this.dos.close();

			} catch (final IOException e) {
				e.printStackTrace(); 
			} 
        } 

	}
}