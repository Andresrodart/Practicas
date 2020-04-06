import java.rmi.Naming;

public class Servidor_rmi
{
  public static void main(String[] args) throws Exception
  {
    String url = "rmi://localhost:500"+ args[0] +"/prueba";
    Clase_rmi obj = new Clase_rmi();

    // Rebinds the specified name to a new remote object
    Naming.rebind(url,obj);
  }
}
