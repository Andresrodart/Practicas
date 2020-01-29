import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.lang.Thread;
import java.net.Socket;

public class ConexionHandler extends Thread{
	private Matrix C;
	private int n = 0;
	private Socket conexion;
	private Object lock = new Object();
	private final DataInputStream dis; 
	private final DataOutputStream dos; 
	
	public ConexionHandler(Socket conexion, DataInputStream dis, DataOutputStream dos, int n) {
		super();
		this.n = n;
		this.dis = dis; 
        this.dos = dos; 
		this.conexion = conexion;
	}  

    public void run(){
		
    }
}