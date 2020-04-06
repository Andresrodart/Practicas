import java.rmi.Naming;

public class Cliente_rmi{
	static public int TamMatrix = 4;
	
	public static void main(String args[]) throws Exception{
		String url = "rmi://localhost:5000/prueba";
		// Returns a reference, a stub, for the remote object associated with the specified name
		Interface_rmi r = (Interface_rmi) Naming.lookup(url);
		int[][] m = {{1,2,3,4},{5,6,7,8},{9,10,11,12}};
		System.out.println("checksum=" + r.checksum(m));	
		TamMatrix = Integer.parseInt(args[0]);
		System.out.println("Size of Matrix: " + TamMatrix);

		int[][] A = new int[TamMatrix][TamMatrix];
		int[][] B = new int[TamMatrix][TamMatrix];
		int[][] C = new int[TamMatrix][TamMatrix];
		for (int i = 0; i < TamMatrix; i++)
			for (int j = 0; j < TamMatrix; j++) {
				A[i][j] = 2 * i + j;
				B[i][j] = 2 * i - j;
			}
		
		
	}

	double[][] copia_matriz(double[][] A,int inicio){
		double[][] M = new double[TamMatrix/2][TamMatrix];
		for (int i = 0; i < TamMatrix/2; i++)
			for (int j = 0; j < TamMatrix; j++)
			M[i][j] = A[i + inicio][j];
		return M;
	}

	void acomoda(double[][] C,double[][] A,int renglon,int columna){
		for (int i = 0; i < TamMatrix/2; i++)
			for (int j = 0; j < TamMatrix/2; j++)
				C[i + renglon][j + columna] = A[i][j];
	}
	  
}