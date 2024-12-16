using FrontEnd;
HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7018/")
};
SystemGE sistema = new SystemGE(cliente); 

sistema.InitializeSystem();