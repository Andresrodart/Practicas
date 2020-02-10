/*******************************
 * 
 * Autor: Andrés Rodarte López
 * 
 *******************************/
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
			//Asignamos el número de nodo
			node = Integer.parseInt(args[0]);	
		} catch (final NumberFormatException e) {
			System.err.println("One or mores arguments are not an integer or missing.");
			System.exit(1);
		}

		try {
			//Flujo principal: Nodo 0
			if (node == 0) {
				final ServerSocket server = new ServerSocket(5050);
				//Creamos tres Thread con los primeros tres clientes en conectarse
				for (int i = 0; i < 3; i++) {
					final Socket conexion = server.accept();
					//El manejador de conexión se encarga del resto
					final InnerPIWorker w = new InnerPIWorker(conexion);
					w.start();
					System.out.println("Cliente conectado");
				}
				//Calculamos la parte que le toca hacer 
				for (int i = 0; i < 10000000; i++) {
					PIaux += 1.0 / (8 * i + 1);
				}
				//Agregamos la parte de la suma
				synchronized (lock) {
					pi += PIaux;
					n++;
				}
				//Esperamos que los demás nodos terminen
				while (true) {
					synchronized (lock) {
						if (n == 4) {
							break;
						}
						//Para no bloquear el candado
						Thread.sleep(100);
					}
				}
				/*******************
					FINAL
				********************/
				System.out.println(4 * pi);
				server.close();
			} else {
				/*************
				 *  Nodo Cliente
				 *************/
				final Socket conexion = new Socket("localhost", 5050);
				final DataOutputStream salida = new DataOutputStream(conexion.getOutputStream());
				//Como recibimos como parametro el nodo que es
				//Podemos ejecutar directamente la suma que le toca
				for (int i = 0; i < 10000000; i++) {
					PIaux += 1.0 / (8 * i + (node - 1) * 2 + 3);
				}
				// envia un número punto flotante con su parte de la suma
				salida.writeDouble((node % 2 == 0) ? PIaux : -PIaux);
				salida.flush();
	
				salida.close();
				conexion.close();
			}	
		} catch (Exception e) {
			System.err.println(e);
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
				//Una vez recibimos la parte calculada la sumamos y aumentamos el contador
				synchronized (lock) {
					PI.pi += x;
					PI.n++;
				}

				conexion.close();
				in.close();
				out.close();
			} catch (final Exception e) {
                System.err.println(e);
            }
             
         }
        
    }
}