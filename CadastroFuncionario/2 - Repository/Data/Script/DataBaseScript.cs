namespace GestaoEmpresarial.Repository.Data.Script
{
    public static class DataBaseScript
    {
        public static string CreateTables()
        {
            string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Cargos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ocupacao TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS RelatoriosFinanceiros(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataBalancoId INTEGER NOT NULL,
                    TotalBruto REAL NOT NULL,
                    TotalInvestimentos REAL NOT NULL,
                    TotalCapital REAL NOT NULL,
                    DespesasImovel REAL NOT NULL,
                    DespesasFuncionarios REAL NOT NULL,
                    DespesasServicos REAL NOT NULL,
                    TotalDespesas REAL NOT NULL,
                    CapitalResultado REAL NOT NULL
                );

                CREATE TABLE IF NOT EXISTS DatasBalanco(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date DATE NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Acoes(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Ticker TEXT NOT NULL,
                    Codigo INTEGER NOT NULL,
                    Valor REAL NOT NULL,
                    Dividendo REAL NOT NULL,
                );

                CREATE TABLE IF NOT EXISTS Funcionarios(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Idade INTEGER NOT NULL,
                    Peso REAL NOT NULL,
                    Salario REAL NOT NULL,
                    CargoId INTEGER NOT NULL,
                    FOREIGN KEY (CargoId) REFERENCES Cargos(Id)
                );"; // Comando para criar as tabelas no banco

            return commandCREATE;
        }
    }
}
