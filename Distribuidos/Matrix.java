public class Matrix {
	private int TamMatrix = 0;
	private double A[][];

	public Matrix(final int TamMatrix) {
		this.TamMatrix = TamMatrix;
		this.A = new double[TamMatrix][TamMatrix]; 
	}

	public void setValue(int i, int j, double value){
		this.A[i][j] = value;
	}

	public double getValue(int i, int j){
		return this.A[i][j];
	}

	public void printMatrix(){
		System.out.print("Matrix is \n"); 
        for (int i = 0; i < TamMatrix; i++)
            for (int j = 0; j < TamMatrix; j++) 
            	System.out.print(this.A[i][j] + " \n");  
	}

	public void transpose(){ 
        for (int i = 0; i < this.TamMatrix; i++) 
            for (int j = i + 1; j < this.TamMatrix; j++){ 
                double temp = A[i][j]; 
                A[i][j] = A[j][i]; 
                A[j][i] = temp; 
            } 
    }

	static void transpose(double A[][], int tam){ 
        for (int i = 0; i < tam; i++) 
            for (int j = i + 1; j < tam; j++){ 
				double temp = A[i][j]; 
                A[i][j] = A[j][i]; 
                A[j][i] = temp; 
            } 
    }
}