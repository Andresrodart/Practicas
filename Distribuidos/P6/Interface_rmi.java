import java.rmi.Remote;
import java.rmi.RemoteException;

public interface Interface_rmi extends Remote{
  public String mayusculas(String name) throws RemoteException;
  public int suma(int a,int b) throws RemoteException;
  public double checksum(int[][] m) throws RemoteException;
  public double[][] multiplica_matrices(double[][] A,double[][] B,int N) throws RemoteException;
}

