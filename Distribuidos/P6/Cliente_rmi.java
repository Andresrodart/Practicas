import java.rmi.Naming;

public class Cliente_rmi{
	static public int TamMatrix = 4;
	
	public static void main(String args[]) throws Exception{
		String url0 = "rmi://192.168.1.70:5000/prueba";
		String url1 = "rmi://192.168.1.81:5001/prueba";
		String url2 = "rmi://192.168.1.82:5002/prueba";
		// Returns a reference, a stub, for the remote object associated with the specified name
		Interface_rmi r0 = (Interface_rmi) Naming.lookup(url0);
		Interface_rmi r1 = (Interface_rmi) Naming.lookup(url1);
		Interface_rmi r2 = (Interface_rmi) Naming.lookup(url2);
		
		TamMatrix = Integer.parseInt(args[0]);
		System.out.println("Size of Matrix: " + TamMatrix);

		double[][] A = new double[TamMatrix][TamMatrix];
		double[][] B = new double[TamMatrix][TamMatrix];
		double[][] C = new double[TamMatrix][TamMatrix];
		for (int i = 0; i < TamMatrix; i++)
			for (int j = 0; j < TamMatrix; j++) {
				A[i][j] = 2.0 * i + j;
				B[i][j] = 2.0 * i - j;
			}
		B = transpose(B);
		acomoda(C, r0.multiplica_matrices(copia_matriz(A, 0), copia_matriz(B, 0), TamMatrix), 0, 0);
		acomoda(C, r1.multiplica_matrices(copia_matriz(A, 0), copia_matriz(B, TamMatrix/2), TamMatrix), 0, TamMatrix/2);
		acomoda(C, r2.multiplica_matrices(copia_matriz(A, TamMatrix/2), copia_matriz(B, 0), TamMatrix), TamMatrix/2, 0);
		acomoda(C, multiplica_matrices(copia_matriz(A, TamMatrix/2), copia_matriz(B, TamMatrix/2), TamMatrix), TamMatrix/2, TamMatrix/2);
		
		if(TamMatrix == 4)printMatrix(transpose(C));
		System.out.println((int) checksum(C));
	}

	static public double[][] copia_matriz(double[][] A,int inicio){
		double[][] M = new double[TamMatrix/2][TamMatrix];
		for (int i = 0; i < TamMatrix/2; i++)
			for (int j = 0; j < TamMatrix; j++)
			M[i][j] = A[i + inicio][j];
		return M;
	}

	static public void acomoda(double[][] C,double[][] A,int renglon,int columna){
		for (int i = 0; i < TamMatrix/2; i++)
			for (int j = 0; j < TamMatrix/2; j++)
				C[i + renglon][j + columna] = A[i][j];
	}

	static public double[][] multiplica_matrices(double[][] A,double[][] B,int N){
		double[][] C = new double[N/2][N/2];
		for (int i = 0; i < N/2; i++)
		for (int j = 0; j < N/2; j++)
			for (int k = 0; k < N; k++)
			C[i][j] += A[i][k] * B[j][k];
		return C;
	}

	static public double[][] transpose (double[][] A){ 
		for (int i = 0; i < TamMatrix; i++) 
            for (int j = i + 1; j < TamMatrix; j++){ 
                double temp = A[i][j]; 
                A[i][j] = A[j][i]; 
                A[j][i] = temp; 
			}
		return A;
    }
	
	static public void printMatrix(double[][] A){
		System.out.println("\nMatrix C is"); 
		for (int i = 0; i < A.length; i++) {
			System.out.print("-- --\t");
		}
		System.out.print("\n");
		for (int i = 0; i < TamMatrix; i++){
            for (int j = 0; j < A[i].length; j++){
				System.out.print(A[i][j] + " \t ");
			} 
			System.out.print("\n");
		}
		for (int i = 0; i < A.length; i++) {
			System.out.print("-- --\t");
		}
		System.out.print("\n");
	}
	public static double checksum(double[][] m){
	  double s = 0;
	  for (int i = 0; i < m.length; i++)
		for (int j = 0; j < m[0].length; j++)
		  s += m[i][j];
	  return s;
	}

}