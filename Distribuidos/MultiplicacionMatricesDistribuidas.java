public class MultiplicacionMatricesDistribuidas {

	static int TamMatrices = 4, n = 0;
	static Matrix A, B, C;
	Object lock = new Object();
 
    public static void main (String[] args) {
        int node = 0;
		if (args.length > 0) {
			try {
				node = Integer.parseInt(args[0]);
				System.out.println(node);
			} catch (NumberFormatException e) {
				System.err.println("Argument " + args[0] + " must be an integer.");
				System.exit(1);
			}
		}

		switch(node){
			case 0:
				A = new Matrix(TamMatrices);
				B = new Matrix(TamMatrices);
				C = new Matrix(TamMatrices);
				for (int i = 0; i < TamMatrices; i++) 
					for (int j = 0; j < TamMatrices; j++) {
						A.setValue(i, j, 2.0 * i + j);
						B.setValue(i, j, 2.0 * i - j);
					}
				
				B.transpose(); 
				
				break;
			case 1:
				break;
			default:
				break;
		}
    }
}