import java.io.DataOutputStream;
import java.net.Socket;

/**
 * TokenClient
 */
public class _TokenClient extends Thread {
	private Socket conexion2server = null;
	private DataOutputStream os;
	private int node;

	public _TokenClient(int node){
		this.node = node;
		while (true)
			try{
				conexion2server = new Socket("localhost",50000 + (this.node + 1) % 4);
				break;
			}
			catch (Exception e){
				System.err.println(e);
			}
		try {	
			this.os = new DataOutputStream(this.conexion2server.getOutputStream());
		} catch (Exception e) {
			System.err.println(e);
		}
	}	
}