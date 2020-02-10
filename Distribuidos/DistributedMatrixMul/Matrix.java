/* 
*
* Matrix Class
* By: Andrès Rodarte López
* Distributed matrix multiplication
*
* Here is only auxiliar code for maneging 2-D matrix
*	
*
*/
public class Matrix {
	private int TamMatrix = 0;
	private double A[][];
	private String name = this.toString();
	final public int length;

	public Matrix(final int TamMatrix) {
		this.TamMatrix = TamMatrix;
		this.length = this.TamMatrix;
		this.A = new double[TamMatrix][TamMatrix]; 
	}
	
	public Matrix(final double[][] arr){
		this.TamMatrix = arr.length;
		this.length = this.TamMatrix;
		this.A = arr.clone();
	}
	
	public Matrix(final double[][] arr, String name){
		this.name = name; 
		this.A = arr.clone();
		this.TamMatrix = arr.length;
		this.length = this.TamMatrix;
	}

	public Matrix(final int row, final int col) {
		this.TamMatrix = row * col;
		this.length = this.TamMatrix;
		this.A = new double[row][col]; 
	}

	public Matrix(final int TamMatrix, String name) {
		this.name = name; 
		this.TamMatrix = TamMatrix;
		this.length = this.TamMatrix;
		this.A = new double[TamMatrix][TamMatrix];
	}

	public void setValue(int i, int j, double value){
		this.A[i][j] = value;
	}
	
	public void sumValue(int i, int j, double value){
		this.A[i][j] += value;
	}
	
	public double[] getValue(int i){
		return this.A[i];
	}

	public double getValue(int i, int j){
		return this.A[i][j];
	}
	

	public void printMatrix(){
		System.out.println("\nMatrix " + this.name + " is"); 
        for (int i = 0; i < TamMatrix; i++){
            for (int j = 0; j < this.A[i].length; j++){
				System.out.print(this.A[i][j] + " \t ");
			} 
			System.out.print("\n");
		}
		for (int i = 0; i < A.length; i++) {
			System.out.print("-- --\t");
		}
		System.out.print("\n");
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

	public int checkSum() {
		int res = 0;
		for (double[] row : A) {
			for (double value : row) {
				res += value;
			}
		}
		return res;
	}
}