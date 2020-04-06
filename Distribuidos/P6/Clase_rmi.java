import java.rmi.server.UnicastRemoteObject;
import java.rmi.RemoteException;

public class Clase_rmi extends UnicastRemoteObject implements Interface_rmi{
  // el constructor default requiere reportar que puede producirse RemoteException
  public Clase_rmi() throws RemoteException{
    super( );
  }

  public String mayusculas(String s) throws RemoteException{
    return s.toUpperCase();
  }

  public int suma(int a,int b){
    return a + b;
  }

  public double[][] multiplica_matrices(double[][] A,double[][] B,int N)
  {
    double[][] C = new double[N/2][N/2];
    for (int i = 0; i < N/2; i++)
      for (int j = 0; j < N/2; j++)
		for (int k = 0; k < N; k++)
          C[i][j] += A[i][k] * B[j][k];
    return C;
  }

  public double checksum(int[][] m) throws RemoteException
  {
    double s = 0;
    for (int i = 0; i < m.length; i++)
      for (int j = 0; j < m[0].length; j++)
        s += m[i][j];
    return s;
  }
}
