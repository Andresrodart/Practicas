import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * TokenServer
 */
public class _TokenServer extends Thread{
	private DataInputStream is;
	private boolean firstTime;
	private long token;
	private int node;
	
	public _TokenServer(int node){
		this.node = node;
	}

	@Override
	public void run() {
		super.run();
		try (ServerSocket serverSocket = new ServerSocket(5050 + node)) {
			final Socket nodeClient = serverSocket.accept();
			is = new DataInputStream(nodeClient.getInputStream());
			
		}catch (Exception e) {
			System.out.println(e);
		}
	}
}