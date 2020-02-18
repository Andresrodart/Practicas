import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * Node
 */
public class Node {
	private Object lock = new Object();
	private boolean send = false;
	private TokenServer TS;
	private TokenClient TC;
	private long token = 0;
	private int node;

	Node(final int node) {
		this.node = node;
		send = (node == 0)? true:false;
		this.TS = new TokenServer(this.node);
		this.TC = new TokenClient(this.node);
	}

	public void __start(){
		TS.start();
		TC.start();
	}

	/**
	 * InnerNode
	 */
	public class TokenServer extends Thread {
		private DataInputStream is;
		private int node;
		private Socket nodeClient;
		public TokenServer(final int node) {
			this.node = node;
		}

		@Override
		public void run() {
			super.run();
			try (ServerSocket serverSocket = new ServerSocket(50000 + this.node)) {
				System.out.println("Starting node: " + this.node);
				nodeClient = serverSocket.accept();
				is = new DataInputStream(nodeClient.getInputStream());

				while (true) {
					try {
						token = is.readLong();
						System.out.println("Recibed token: " + token);
						synchronized (lock) {
							send = true;
							try {
								sleep(500);
							} catch (final InterruptedException e) {
								e.printStackTrace();
							}
						}
					} catch (Exception e) {
						System.err.println(e);
					}
				}
			} catch (final Exception e) {
				System.out.println(e);
			}
		}
	}

	public class TokenClient extends Thread {
		private Socket conexion2server = null;
		private DataOutputStream os;
		private int node;

		public TokenClient(final int node){
			this.node = node;
		}

		@Override
		public void run() {
			super.run();
			while (true){
				try {
					this.conexion2server = new Socket("localhost", 50000 + (this.node + 1) % 4);
					this.os = new DataOutputStream(this.conexion2server.getOutputStream());
					System.out.println("Conected to server:" + (50000 + (this.node + 1) % 4));
					break;
				} catch (final Exception e) {
					try {
						sleep(100);
					} catch (InterruptedException e1) {
						e1.printStackTrace();
					}
				}
			}
			

			while(true){
				try {
					synchronized (lock) {
						if(send){
							//System.out.println("Sending token: " + ++token);
							os.writeLong(++token);
							send = false;
						}
						try {
							sleep(10);
						} catch (final InterruptedException e) {
							e.printStackTrace();
						}	
					}
				} catch (Exception e) {
					System.err.println(e);
				}
			}
		}
	}
	
}