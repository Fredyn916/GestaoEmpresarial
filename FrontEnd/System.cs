using Entidades;
using FrontEnd.Extensions;

namespace FrontEnd;

public class SystemGE
{
    private Methods _methods {  get; set; }
    private Usuario _usuarioLogado { get; set; }

    public SystemGE(HttpClient cliente)
    {
        _methods = new Methods(cliente);
    }

    public void InitializeSystem()
    {
        int action = -1;

        Console.WriteLine("<-------------- GESTÃO EMPRESARIAL --------------->");

        do
        {
            _methods.InitializeAll();

            if(_usuarioLogado == null)
            {
                _usuarioLogado = _methods.CadastroOuLogin();
            }
            else
            {
                switch (_usuarioLogado.TipoUsuarioId)
                {
                    case 1:
                        _methods.MenuPrincipal1();
                        break;
                    case 2:
                        _methods.MenuPrincipal2(_usuarioLogado);
                        break;
                    case 3:
                        _methods.MenuPrincipal3();
                        break;
                }
            }
        } while (action != 0);
    }
}