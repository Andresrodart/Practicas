public class Matrix {
	int TamMatrices = 0;
	double A[][];

	Matrix(final int TamMatrices) {
		this.TamMatrices = TamMatrices;
		this.A = new double[TamMatrices][TamMatrices]; 
	}

	public void setValue(int i, int j, double value){
		this.A[i][j] = value;
	}

	public void printMatrix(){
		System.out.print("Matrix is \n"); 
        for (int i = 0; i < TamMatrices; i++)
            for (int j = 0; j < TamMatrices; j++) 
            	System.out.print(this.A[i][j] + " \n");  
	}

	public void transpose(){ 
        for (int i = 0; i < this.TamMatrices; i++) 
            for (int j = i + 1; j < this.TamMatrices; j++){ 
                 int temp = A[i][j]; 
                 A[i][j] = A[j][i]; 
                 A[j][i] = temp; 
            } 
    }

	static void transpose(Matrix A[][]){ 
        for (int i = 0; i < A.TamMatrices; i++) 
            for (int j = i + 1; j < A.TamMatrices; j++){ 
                 int temp = A[i][j]; 
                 A[i][j] = A[j][i]; 
                 A[j][i] = temp; 
            } 
    }
}