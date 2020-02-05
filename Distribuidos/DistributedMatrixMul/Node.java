package DistributedMatrixMul;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.InetAddress;
import java.net.Socket;
// import java.util.Scanner;

public class Node {
	
	private Double A[][], B[][], C[][];
	
	public Node(int TamMatrix) {
		this.A = new Double[TamMatrix/2][TamMatrix];
		this.B = new Double[TamMatrix/2][TamMatrix];
		this.C = new Double[TamMatrix/2][TamMatrix/2];
	}

	public void solve() {
		try{ 
            //Scanner scn = new Scanner(System.in); 
              
            // getting localhost ip 
            InetAddress ip = InetAddress.getByName("localhost"); 
      
            // establish the connection with server port 5056 
            Socket s = new Socket(ip, 5050); 
      
            // obtaining input and out streams 
            DataInputStream dis = new DataInputStream(s.getInputStream()); 
            DataOutputStream dos = new DataOutputStream(s.getOutputStream()); 
      
            // the following loop performs the exchange of 
            // information between client and client handler 

            System.out.println(dis.readUTF()); 
            //String tosend = scn.nextLine(); 
            //dos.writeUTF(tosend); 
            s.close(); 
              
            // closing resources 
            // scn.close(); 
            dis.close(); 
            dos.close(); 
        }catch(Exception e){ 
            e.printStackTrace(); 
        }
	}
}