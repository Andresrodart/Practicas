package DistributedMatrixMul;

import java.net.ServerSocket;
import java.net.Socket;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;

public class NodeZero {
	private static int n = 0;
	private static Matrix A, B, C;
	private int TamMatrix = 4, nodes = 4;
	private static Object lock = new Object();

	public NodeZero(int TamMatrix, int nodes) {
		this.TamMatrix = TamMatrix;
		this.nodes = nodes;
		A = new Matrix(this.TamMatrix);
		B = new Matrix(this.TamMatrix);
		// C = new Matrix(this.TamMatrix);
		for (int i = 0; i < this.TamMatrix; i++)
			for (int j = 0; j < this.TamMatrix; j++) {
				A.setValue(i, j, 2.0 * i + j);
				B.setValue(i, j, 2.0 * i - j);
			}

		B.transpose();

		A.printMatrix();
		B.printMatrix();
	}

	public void solve() {
		try (ServerSocket serverSocket = new ServerSocket(5050)) {
			System.out.println("Server is listening on port " + 5050);
			for (int i = 0; i < this.nodes; i++) {

				Socket nodeClient = serverSocket.accept();
				System.out.println("A new client is connected : " + nodeClient);

				// obtaining input and out streams
				DataInputStream dis = new DataInputStream(nodeClient.getInputStream());
				DataOutputStream dos = new DataOutputStream(nodeClient.getOutputStream());

				System.out.println("Assigning new thread for this client");

				// create a new thread object
				Thread t = new ConexionHandler(nodeClient, dis, dos, i);

				// Invoking the start() method
				t.start();
			}
			Matrix aux = new Matrix(this.TamMatrix / 2);
			for (int i = 0; i < this.TamMatrix / 2 - 1; i++) {
				for (int j = 0; j < this.TamMatrix / 2 - 1; j++) {
					for (int j2 = 0; j2 < this.TamMatrix / 2 - 1; j2++) {
						aux.sumValue(i, j, A.getValue(i, j2) * B.getValue(j, j2));
					}
				}
			}
			synchronized (lock) {
				for (int i = 0; i < aux.length; i++) {
					for (int j = 0; j < aux.length; j++) {
						C.setValue(i, j, aux.getValue(i, j));
					}
				}
				n++;
			}
			while (true) {
				synchronized (lock) {
					if (n == 4) {
						break;
					}
					try {
						Thread.sleep(100);
					} catch (InterruptedException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				}
			}
			C.printMatrix();
		} catch (IOException ex) {
            System.out.println("Server exception: " + ex.getMessage());
            ex.printStackTrace();
		}
	}

	public class ConexionHandler extends Thread{
		private int n = 0;
		private Socket conexion;
		private final DataInputStream dis; 
		private final DataOutputStream dos; 
		
		public ConexionHandler(Socket conexion, DataInputStream dis, DataOutputStream dos, int n) {
			super();
			this.n = n;
			this.dis = dis; 
			this.dos = dos; 
			this.conexion = conexion;
			System.out.println("Starting node: " + this.n);
		}  
	
		public void run(){
			//String received; 
        	//String toreturn; 
			try { 
  
                // Ask user what he wants 
                dos.writeUTF(this.n + " ");
                // receive the answer from client 
                // received = dis.readUTF(); 
                conexion.close();

            } catch (IOException e) { 
                e.printStackTrace(); 
			}

			try{ 
				// closing resources 
				this.dis.close(); 
				this.dos.close(); 
				
			}catch(IOException e){ 
				e.printStackTrace(); 
			} 
        } 

	}
}