﻿using Entidades;
using Entidades.DTO.EmpresaDTO;
using Entidades.DTO.UsuarioDTO;
using FrontEnd.UseCases;

namespace FrontEnd.Extensions;

public class Methods
{
    private readonly CargoUC _cargoUC;
    private readonly DateBalanceUC _dateBalanceUC;
    private readonly EconomiaUC _economiaUC;
    private readonly EmpresaUC _empresaUC;
    private readonly FuncionarioUC _funcionarioUC;
    private readonly TipoUsuarioUC _tipoUsuarioUC;
    private readonly UsuarioUC _usuarioUC;

    public Methods(HttpClient cliente)
    {
        _cargoUC = new CargoUC(cliente);
        _dateBalanceUC = new DateBalanceUC(cliente);
        _economiaUC = new EconomiaUC(cliente);
        _empresaUC = new EmpresaUC(cliente);
        _funcionarioUC = new FuncionarioUC(cliente);
        _tipoUsuarioUC = new TipoUsuarioUC(cliente);
        _usuarioUC = new UsuarioUC(cliente);
    }

    public Usuario CadastroOuLogin()
    {
        int action = -1;

        while (action != 1 &&  action != 2)
        {
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Cadastrar Usuário");
            Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");
            action = int.Parse(Console.ReadLine());

            if(action != 1 && action != 2)
            {
                Console.WriteLine("<------------ Digite o número válido ------------->");
            }
        }
        if (action == 1)
        {
            Console.WriteLine("<--------------------- LOGIN --------------------->");
            Console.WriteLine("Digite o Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Digite a Password: ");
            string password = Console.ReadLine();
            if (_usuarioUC.Login(username, password) == null)
            {
                Console.WriteLine("<-------------------- CADASTRO ------------------->");
                CreateUsuarioDTO usuarioDTO = new CreateUsuarioDTO();
                while (action != 1 && action != 2)
                {
                    Console.WriteLine("Digite o número do Tipo de Usuário: ");
                    Console.WriteLine("1 - Proprieário da Empresa");
                    Console.WriteLine("2 - Funcionário");
                    action = int.Parse(Console.ReadLine());

                    if (action != 1 && action != 2)
                    {
                        Console.WriteLine("<------------ Digite o número válido ------------->");
                    }
                }
                if (action == 1)
                {
                    usuarioDTO.TipoUsuarioId = 2;
                }
                else if (action == 2)
                {
                    usuarioDTO.TipoUsuarioId = 3;
                }
                Console.WriteLine("Digite o Username: ");
                usuarioDTO.Username = Console.ReadLine();
                Console.WriteLine("Digite a Password: ");
                usuarioDTO.Password = Console.ReadLine();

                _usuarioUC.Create(usuarioDTO);
                if (_usuarioUC.Login(usuarioDTO.Username, usuarioDTO.Password) != null)
                {
                    Console.WriteLine("<---- Usuário Cadastrado e Logado com Sucesso ---->");
                    return _usuarioUC.Login(usuarioDTO.Username, usuarioDTO.Password);
                }
            }
            else if (_usuarioUC.Login(username, password) != null)
            {
                Console.WriteLine("<---------- Usuário Logado com Sucesso ----------->");
                return _usuarioUC.Login(username, password);
            }
        }
        else if (action == 2)
        {
            Console.WriteLine("<-------------------- CADASTRO ------------------->");
            CreateUsuarioDTO usuarioDTO = new CreateUsuarioDTO();
            while (action != 1 && action != 2)
            {
                Console.WriteLine("Digite o número do Tipo de Usuário: ");
                Console.WriteLine("1 - Proprieário da Empresa");
                Console.WriteLine("2 - Funcionário");
                action = int.Parse(Console.ReadLine());

                if (action != 1 && action != 2)
                {
                    Console.WriteLine("<------------ Digite o número válido ------------->");
                }
            }
            if (action == 1)
            {
                usuarioDTO.TipoUsuarioId = 2;
            }
            else if (action == 2)
            {
                usuarioDTO.TipoUsuarioId = 3;
            }
            Console.WriteLine("Digite o Username: ");
            usuarioDTO.Username = Console.ReadLine();
            Console.WriteLine("Digite a Password: ");
            usuarioDTO.Password = Console.ReadLine();

            _usuarioUC.Create(usuarioDTO);
            if (_usuarioUC.Login(usuarioDTO.Username, usuarioDTO.Password) != null)
            {
                Console.WriteLine("<---- Usuário Cadastrado e Logado com Sucesso ---->");
                return _usuarioUC.Login(usuarioDTO.Username, usuarioDTO.Password);
            }
        }
        return null;
    }

    public void MenuPrincipal1()
    {
        int action = -1;

        while (action < 1 || action > 4)
        {
            Console.WriteLine("<------------------ MENU ADMIN ------------------->");
            Console.WriteLine("1 - Cadastrar Empresa");
            Console.WriteLine("2 - Vizualizar Empresas");
            Console.WriteLine("3 - Editar Empresa");
            Console.WriteLine("4 - Remover Empresa");
            Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");

            if(action < 1 || action > 4)
            {
                Console.WriteLine("<------------ Digite o número válido ------------->");
            }
        }

        switch (action)
        {
            case 1:
                Console.WriteLine("<---------------- CADASTRO EMPRESA --------------->");
                CreateEmpresaDTO empresaDTO = new CreateEmpresaDTO();
                Console.WriteLine("Digite o Nome da Empresa: ");
                empresaDTO.Nome = Console.ReadLine();
                Console.WriteLine("Digite o CNPJ: ");
                empresaDTO.CNPJ = Console.ReadLine();
                Console.WriteLine("Digite o CEP: ");
                empresaDTO.CEP = Console.ReadLine();
                Console.WriteLine("Digite o Id do Usuário Proprietário: "); // APLICAR UMA LÓGICA MELHOR
                empresaDTO.UsuarioId = int.Parse(Console.ReadLine());
                _empresaUC.Create(empresaDTO);
                Console.WriteLine("<-------- Empresa Cadastrada com Sucesso --------->");
                break;
            case 2:

                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    public void MenuPrincipal2()
    {
        int action = -1;

        Console.WriteLine("<--------------- MENU PROPRIETÁRIO --------------->");
        Console.WriteLine("1 - Cadastrar Funcionário");
        Console.WriteLine("2 - Vizualizar Funcionários");
        Console.WriteLine("3 - Editar Dados de Funcionário");
        Console.WriteLine("4 - Demitir Funcionário");
        Console.WriteLine("5 - Promover Funcionário");
        Console.WriteLine("6 - Anotar Balanço Mensal");
        Console.WriteLine("7 - Vizualizar Balanços");
        Console.WriteLine("8 - Editar Balanço");
        Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");
    }

    public void MenuPrincipal3()
    {
        int action = -1;

        Console.WriteLine("<--------------- MENU FUNCIONÁRIO ---------------->");
        Console.WriteLine("1 - Vizualizar Dados");
        Console.WriteLine("2 - Conferir Remuneração");
        Console.WriteLine("3 - Solicitar Demição");
        Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");
    }
}