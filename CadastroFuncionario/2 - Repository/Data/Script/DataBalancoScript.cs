namespace GestaoEmpresarial.Repository.Data.Script
{
    public static class DataBalancoScript
    {
        public static string SelectCountAllDatasBalanco()
        {
            string commandSELECTCOUNTDatas = "SELECT COUNT(*) FROM DatasBalanco;"; // Comando para contar quantos itens existem na tabela {Cargos}

            return commandSELECTCOUNTDatas;
        }
    }
}
