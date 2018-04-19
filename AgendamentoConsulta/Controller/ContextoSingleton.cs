using Model.DAL;

namespace Controller
{

    //Abre e fecha uma única conexão com o banco de dados
    public class ContextoSingleton
    {
        private static Contexto instancia;

        public static Contexto Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Contexto();
                }

                return instancia;
            }
        }

        private ContextoSingleton()
        {
        }
    }
}
