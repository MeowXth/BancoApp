namespace BancoApp.Models 
{
    public class Cliente
    {
        public int Id {get; set;}
        public string Nombre {get; set;} = string.Empty;
        public string Correo {get; set;} = string.Empty;
        public decimal Saldo {get; set;}
    }

}