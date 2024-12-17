using Entidades;
using Entidades.DTO.EconomiaDTO;
using Entidades.DTO.EmpresaDTO;
using Entidades.DTO.FuncionarioDTO;
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

    public void InitializeAll()
    {
        _dateBalanceUC.Initialize();
        _tipoUsuarioUC.Initialize();
        _usuarioUC.Initialize();
        _cargoUC.Initialize();
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
                Console.WriteLine("<------------ Digite um número válido ------------>");
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
                        Console.WriteLine("<------------ Digite um número válido ------------>");
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
            action = -1;
            while (action != 1 && action != 2)
            {
                Console.WriteLine("Digite o número do Tipo de Usuário: ");
                Console.WriteLine("1 - Proprieário da Empresa");
                Console.WriteLine("2 - Funcionário");
                action = int.Parse(Console.ReadLine());

                if (action != 1 && action != 2)
                {
                    Console.WriteLine("<------------ Digite um número válido ------------>");
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

    public int MenuPrincipal1()
    {
        int action = -1;

        while (action < 0 || action > 4)
        {
            Console.WriteLine("<------------------ MENU ADMIN ------------------->");
            Console.WriteLine("1 - Cadastrar Empresa");
            Console.WriteLine("2 - Vizualizar Empresas");
            Console.WriteLine("3 - Editar Empresa");
            Console.WriteLine("4 - Remover Empresa");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");
            action = int.Parse(Console.ReadLine());

            if (action < 0 || action > 4)
            {
                Console.WriteLine("<------------ Digite um número válido ------------>");
            }
        }

        if(action == 0)
        {
            return action;
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
                Console.WriteLine("<------------- USUÁRIOS CADASTRADOS -------------->");
                List<Usuario> usuarios = _usuarioUC.GetAll();
                foreach (var u in usuarios)
                {
                    Console.WriteLine(u.ExibirDetalhes(_tipoUsuarioUC.GetById(u.TipoUsuarioId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id do Usuário Proprietário: ");
                empresaDTO.UsuarioId = int.Parse(Console.ReadLine());
                _empresaUC.Create(empresaDTO);
                Console.WriteLine("<-------- Empresa Cadastrada com Sucesso --------->");
                break;
            case 2:
                Console.WriteLine("<-------------- VIZUALIZAR EMPRESAS -------------->");
                List<Empresa> empresas = _empresaUC.GetAll();
                foreach (var e in empresas)
                {
                    Console.WriteLine(e.ExibirDetalhes(_usuarioUC.GetById(e.UsuarioId)));
                }
                break;
            case 3:
                Console.WriteLine("<------------- EMPRESAS CADASTRADAS -------------->");
                List<Empresa> possiveisEmpresas = _empresaUC.GetAll();
                foreach (var e in possiveisEmpresas)
                {
                    Console.WriteLine(e.ExibirDetalhes(_usuarioUC.GetById(e.UsuarioId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id da Empresa que deseja editar: ");
                int empresaEditId = int.Parse(Console.ReadLine());
                Empresa empresaEdit = _empresaUC.GetById(empresaEditId);
                Console.WriteLine($"Se necessário, digite o novo Nome da Empresa: (Atual Nome: {empresaEdit.Nome})");
                empresaEdit.Nome = Console.ReadLine();
                Console.WriteLine($"Se necessário, digite o novo CNPJ: (Atual CNPJ: {empresaEdit.CNPJ})");
                empresaEdit.CNPJ = Console.ReadLine();
                Console.WriteLine($"Se necessário, digite o novo CEP: (Atual CNPJ: {empresaEdit.CEP})");
                empresaEdit.CEP = Console.ReadLine();
                Console.WriteLine("<------------- USUÁRIOS CADASTRADOS -------------->");
                List<Usuario> usuariosCadastrados = _usuarioUC.GetAll();
                foreach (var u in usuariosCadastrados)
                {
                    Console.WriteLine(u.ExibirDetalhes(_tipoUsuarioUC.GetById(u.TipoUsuarioId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine($"Se necessário, digite o novo Id do Usuário Proprietário: (Atual Id do Proprietário: {empresaEdit.UsuarioId})");
                empresaEdit.UsuarioId = int.Parse(Console.ReadLine());
                _empresaUC.Update(empresaEdit);
                Console.WriteLine("<--------- Empresa Editada com Sucesso ----------->");
                break;
            case 4:
                Console.WriteLine("<------------- EMPRESAS CADASTRADAS -------------->");
                List<Empresa> empresasCadastradas = _empresaUC.GetAll();
                foreach (var e in empresasCadastradas)
                {
                    Console.WriteLine(e.ExibirDetalhes(_usuarioUC.GetById(e.UsuarioId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id da Empresa que deseja remover: ");
                int empresaId = int.Parse(Console.ReadLine());
                _empresaUC.Remove(empresaId);
                Console.WriteLine("<--------- Empresa Removida com Sucesso ---------->");
                break;
        }

        return action;
    }

    public int MenuPrincipal2(Usuario _usuarioLogado)
    {
        int action = -1;

        while (action < 0 || action > 8)
        {
            Console.WriteLine("<--------------- MENU PROPRIETÁRIO --------------->");
            Console.WriteLine("1 - Cadastrar Funcionário");
            Console.WriteLine("2 - Vizualizar Funcionários");
            Console.WriteLine("3 - Editar Dados de Funcionário");
            Console.WriteLine("4 - Demitir Funcionário");
            Console.WriteLine("5 - Promover Funcionário");
            Console.WriteLine("6 - Anotar Balanço Mensal");
            Console.WriteLine("7 - Vizualizar Balanços");
            Console.WriteLine("8 - Editar Balanço");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");
            action = int.Parse(Console.ReadLine());

            if(action < 0 || action > 8)
            {
                Console.WriteLine("<------------ Digite um número válido ------------>");
            }
        }

        if (action == 0)
        {
            return action;
        }

        switch (action)
        {
            case 1:
                Console.WriteLine("<-------------- CADASTRO FUNCIONÁRIO ------------->");
                CreateFuncionarioDTO funcionarioDTO = new CreateFuncionarioDTO();
                Console.WriteLine("Digite o Nome do Funcionário: ");
                funcionarioDTO.Nome = Console.ReadLine();
                Console.WriteLine("Digite o CPF do Funcionário: ");
                funcionarioDTO.CPF = Console.ReadLine();
                Console.WriteLine("Digite a Idade do Funcionário: ");
                funcionarioDTO.Idade = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Peso do Funcionário: ");
                funcionarioDTO.Peso = double.Parse(Console.ReadLine());
                Console.WriteLine("<------------- CARGOS CADASTRADOS -------------->");
                List<Cargo> cargos = _cargoUC.GetAll();
                foreach (var c in cargos)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id do Cargo que deseja atribuir ao Funcionário: ");
                funcionarioDTO.CargoId = int.Parse(Console.ReadLine());
                funcionarioDTO.Salario = _cargoUC.GetById(funcionarioDTO.CargoId).Remuneracao;
                funcionarioDTO.EmpresaId = _empresaUC.GetEmpresaIdByUsuarioId(_usuarioLogado.Id);
                _funcionarioUC.Create(funcionarioDTO);
                Console.WriteLine("<------ Funcionário Cadastrado com Sucesso ------->");
                break;
            case 2:
                Console.WriteLine("<----------- VIZUALIZAR FUNCIONÁRIOS ------------->");
                List<Funcionario> funcionarios = _funcionarioUC.GetAll();
                foreach (var f in funcionarios)
                {
                    Console.WriteLine(f.ExibirDetalhes(_cargoUC.GetById(f.CargoId), _empresaUC.GetById(f.EmpresaId)));
                }
                break;
            case 3:
                Console.WriteLine("<----------- FUNCIONÁRIOS CADASTRADOS ------------>");
                List<Funcionario> funcionariosCadastrados = _funcionarioUC.GetAll();
                foreach (var f in funcionariosCadastrados)
                {
                    Console.WriteLine(f.ExibirDetalhes(_cargoUC.GetById(f.CargoId), _empresaUC.GetById(f.EmpresaId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id do Funcionário que deseja editar: ");
                int funcionarioEditId = int.Parse(Console.ReadLine());
                Funcionario funcionarioEdit = _funcionarioUC.GetById(funcionarioEditId);
                Console.WriteLine($"Se necessário, digite o novo Nome do Funcionário: (Atual Nome: {funcionarioEdit.Nome})");
                funcionarioEdit.Nome = Console.ReadLine();
                Console.WriteLine($"Se necessário, digite o novo CPF: (Atual CPF: {funcionarioEdit.CPF})");
                funcionarioEdit.CPF = Console.ReadLine();
                Console.WriteLine($"Se necessário, digite a nova Idade: (Atual Idade: {funcionarioEdit.Idade})");
                funcionarioEdit.Idade = int.Parse(Console.ReadLine());
                Console.WriteLine($"Se necessário, digite o novo Peso: (Atual Peso: {funcionarioEdit.Peso})");
                funcionarioEdit.Peso = double.Parse(Console.ReadLine());
                Console.WriteLine("<------------- CARGOS CADASTRADOS -------------->");
                List<Cargo> cargosCadastrados = _cargoUC.GetAll();
                foreach (var c in cargosCadastrados)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine($"Se necessário, digite o novo Cargo Id: (Atual Cargo Id: {funcionarioEdit.CargoId})");
                funcionarioEdit.CargoId = int.Parse(Console.ReadLine());
                funcionarioEdit.Salario = _cargoUC.GetById(funcionarioEdit.CargoId).Remuneracao;
                funcionarioEdit.EmpresaId = _empresaUC.GetEmpresaIdByUsuarioId(_usuarioLogado.Id);
                _funcionarioUC.Update(funcionarioEdit);
                Console.WriteLine("<--------- Empresa Editada com Sucesso ----------->");
                break;
            case 4:
                Console.WriteLine("<----------- FUNCIONÁRIOS CADASTRADOS ------------>");
                List<Funcionario> funcionariosParaDemicao = _funcionarioUC.GetAll();
                foreach (var f in funcionariosParaDemicao)
                {
                    Console.WriteLine(f.ExibirDetalhes(_cargoUC.GetById(f.CargoId), _empresaUC.GetById(f.EmpresaId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id do Funcionário que deseja demitir: ");
                int funcionarioId = int.Parse(Console.ReadLine());
                _funcionarioUC.Remove(funcionarioId);
                Console.WriteLine("<------- Funcionário Demitido com Sucesso -------->");
                break;
            case 5:
                Console.WriteLine("<----------- FUNCIONÁRIOS CADASTRADOS ------------>");
                List<Funcionario> funcionariosParaPromocao = _funcionarioUC.GetAll();
                foreach (var f in funcionariosParaPromocao)
                {
                    Console.WriteLine(f.ExibirDetalhes(_cargoUC.GetById(f.CargoId), _empresaUC.GetById(f.EmpresaId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id do Funcionário que deseja promover: ");
                int funcionarioPromocaoId = int.Parse(Console.ReadLine());
                Funcionario funcionaroPromocao = _funcionarioUC.GetById(funcionarioPromocaoId);
                Cargo cargoFuncionario = _cargoUC.GetById(funcionaroPromocao.CargoId);
                if (cargoFuncionario.Step == 1)
                {
                    funcionaroPromocao.CargoId += 1;
                    _funcionarioUC.Update(funcionaroPromocao);
                    Console.WriteLine("<------ Funcionário Promovido para o Step 2 ------>");
                }
                else if (cargoFuncionario.Step == 2)
                {
                    funcionaroPromocao.CargoId += 1;
                    _funcionarioUC.Update(funcionaroPromocao);
                    Console.WriteLine("<------ Funcionário Promovido para o Step 3 ------>");
                }
                else if (cargoFuncionario.Step == 3)
                {
                    Console.WriteLine("<--- O Funcionário já possui o cargo mais alto --->");
                }
                break;
            case 6:
                Console.WriteLine("<------------ ANOTAR BALANÇO MENSAL -------------->");
                CreateEconomiaDTO economiaDTO = new CreateEconomiaDTO();
                Console.WriteLine("<-------- DATAS DISPONÍVEIS PARA BALANÇO --------->");
                List<DateBalance> datas = _dateBalanceUC.GetAll();
                foreach (var d in datas)
                {
                    Console.WriteLine(d.ExibirDetalhes());
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id da Data que deseja slecionar para realizar o balanço mensal: ");
                economiaDTO.DateBalanceId = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Total Bruto da Empresa: ");
                economiaDTO.TotalBruto = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Total de Despesas com Imóvel(eis): ");
                economiaDTO.DespesasImovel = double.Parse(Console.ReadLine());
                List<Funcionario> funcionariosEmpresa = _funcionarioUC.GetAll();
                List<Empresa> empresas = _empresaUC.GetAll();
                double valor = 0.0;
                foreach (var f in funcionariosEmpresa)
                {
                    foreach (var e in empresas)
                    {
                        if (e.UsuarioId == _usuarioLogado.Id)
                        {
                            if(f.EmpresaId == e.Id)
                            {
                                valor += f.Salario;
                            }
                        }
                    }
                }
                economiaDTO.DespesasFuncionarios = valor;
                Console.WriteLine($"Total de Despesas com Funcionários: R$ {economiaDTO.DespesasFuncionarios}");
                Console.WriteLine("Digite o Total de Despesas com Serviços: ");
                economiaDTO.DespesasServicos = double.Parse(Console.ReadLine());
                economiaDTO.TotalDespesas = (economiaDTO.DespesasImovel + economiaDTO.DespesasFuncionarios) + economiaDTO.DespesasServicos;
                Console.WriteLine($"Total de Despesas: R$ {economiaDTO.TotalDespesas}");
                economiaDTO.TotalLucro = economiaDTO.TotalBruto - economiaDTO.TotalDespesas;
                Console.WriteLine($"Total Lucro: R$ {economiaDTO.TotalLucro}");
                economiaDTO.EmpresaId = _usuarioLogado.Id;
                _economiaUC.Create(economiaDTO);
                _dateBalanceUC.Remove(economiaDTO.DateBalanceId);
                Console.WriteLine("<----- BALANÇO MENSAL REALIZADO COM SUCESSO ------>");
                break;
            case 7:
                Console.WriteLine("<-------- VIZUALIZAR BALANÇOS REALIZADOS --------->");
                List<Economia> economias = _economiaUC.GetAll();
                foreach (var e in economias)
                {
                    Console.WriteLine(e.ExibirDetalhes(_dateBalanceUC.GetById(e.DateBalanceId), _empresaUC.GetById(e.EmpresaId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                break;
            case 8:
                Console.WriteLine("<-------- VIZUALIZAR BALANÇOS REALIZADOS --------->");
                List<Economia> economiasRealizadas = _economiaUC.GetAll();
                foreach (var e in economiasRealizadas)
                {
                    Console.WriteLine(e.ExibirDetalhes(_dateBalanceUC.GetById(e.DateBalanceId), _empresaUC.GetById(e.EmpresaId)));
                }
                Console.WriteLine("<------------------------------------------------->");
                Console.WriteLine("Digite o Id do Balanço que deseja editar: ");
                int economiaId = int.Parse(Console.ReadLine());
                Economia economiaEdit = _economiaUC.GetById(economiaId);
                Console.WriteLine($"Se necessário, digite o novo Total Bruto da Empresa: (Atual Total Bruto: R$ {economiaEdit.TotalBruto})");
                economiaEdit.TotalBruto = double.Parse(Console.ReadLine());
                Console.WriteLine($"Se necessário, digite o novo Total de Despesas com Imóvel(eis): (Atual Total de Despesas com Imóvel(eis): R$ {economiaEdit.DespesasImovel})");
                economiaEdit.DespesasImovel = double.Parse(Console.ReadLine());
                List<Funcionario> funcionariosCadastradosParaEdit = _funcionarioUC.GetAll();
                List<Empresa> empresasCadastradasParaEdit = _empresaUC.GetAll();
                double valorTotal = 0.0;
                foreach (var f in funcionariosCadastradosParaEdit)
                {
                    foreach (var e in empresasCadastradasParaEdit)
                    {
                        if (e.UsuarioId == _usuarioLogado.Id)
                        {
                            if (f.EmpresaId == e.Id)
                            {
                                valorTotal += f.Salario;
                            }
                        }
                    }
                }
                economiaEdit.DespesasFuncionarios = valorTotal;
                Console.WriteLine($"Total de Despesas com Funcionários: R$ {economiaEdit.DespesasFuncionarios}");
                Console.WriteLine($"Se necessário, digite o novo Total de Despesas com Serviços: (Atual Total de Despesas com Serviços: R$ {economiaEdit.DespesasServicos})");
                economiaEdit.DespesasServicos = double.Parse(Console.ReadLine());
                economiaEdit.TotalDespesas = (economiaEdit.DespesasImovel + economiaEdit.DespesasFuncionarios) + economiaEdit.DespesasServicos;
                Console.WriteLine($"Total de Despesas: R$ {economiaEdit.TotalDespesas}");
                economiaEdit.TotalLucro = economiaEdit.TotalBruto - economiaEdit.TotalDespesas;
                Console.WriteLine($"Total Lucro: R$ {economiaEdit.TotalLucro}");
                _economiaUC.Update(economiaEdit);
                Console.WriteLine("<--------- Balanço Editado com Sucesso ----------->");
                break;
        }

        return action;
    }

    public int MenuPrincipal3()
    {
        int action = -1;

        while (action < 0 || action > 3)
        {
            Console.WriteLine("<--------------- MENU FUNCIONÁRIO ---------------->");
            Console.WriteLine("1 - Vizualizar Dados");
            Console.WriteLine("2 - Conferir Remuneração");
            Console.WriteLine("3 - Solicitar Demição");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("<-- Digite o número respectivo à ação desejada: -->");
            action = int.Parse(Console.ReadLine());

            if (action < 0 || action > 3)
            {
                Console.WriteLine("<------------ Digite um número válido ------------>");
            }
        }

        if(action == 0)
        {
            return action;
        }

        switch (action)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }

        return action;
    }
}