package PI;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * PI
 */
public class PI {
    static int n = 0;
    static double pi = 0;
    final static Object lock = new Object();
	
	public static void main(final String[] args) {
		int node = 0;
		double PIaux = 0;
		
		try {
			node = Integer.parseInt(args[0]);
		} catch (final NumberFormatException e) {
			System.err.println("One or mores arguments are not an integer or missing.");
			System.exit(1);
		}

		try {
			if (node == 0) {
				final ServerSocket server = new ServerSocket(5050);
				for (int i = 0; i < 3; i++) {
					final Socket conexion = server.accept();
					final InnerPIWorker w = new InnerPIWorker(conexion);
					w.start();
					System.out.println("Cliente conectado");
				}
				for (int i = 0; i < 10000000; i++) {
					PIaux += 1.0 / (8 * i + 1);
				}
				synchronized (lock) {
					pi += PIaux;
					n++;
				}
				while (true) {
					synchronized (lock) {
						if (n == 4) {
							break;
						}
						Thread.sleep(100);
					}
				}
				System.out.println(4 * pi);
				server.close();
			} else {
				final Socket conexion = new Socket("localhost", 5050);
				final DataOutputStream salida = new DataOutputStream(conexion.getOutputStream());
				final DataInputStream entrada = new DataInputStream(conexion.getInputStream());
	
				for (int i = 0; i < 10000000; i++) {
					PIaux += 1.0 / (8 * i + (node - 1) * 2 + 3);
				}
				// envia un n�mero punto flotante
				salida.writeDouble((node % 2 == 0) ? PIaux : -PIaux);
	
				salida.flush();
	
				salida.close();
				entrada.close();
				conexion.close();
			}	
		} catch (Exception e) {
			//TODO: handle exception
		}
		
	}

	/**
	 * InnerPI
	 */
	static public class InnerPIWorker extends Thread {
		Socket conexion;

		public InnerPIWorker(final Socket s) {
			this.conexion = s;
		}

		@Override
		public void run() {
			super.run();
			try {
				final DataInputStream in = new DataInputStream(this.conexion.getInputStream());
				final DataOutputStream out = new DataOutputStream(this.conexion.getOutputStream());
				final double x = in.readDouble();
				System.out.println("Recibed: " + x);
				synchronized (lock) {
					pi += x;
					n++;
				}

				conexion.close();
				in.close();
				out.close();
			} catch (final Exception e) {
                 //TODO: handle exception
             }
             
         }
        
    }
}