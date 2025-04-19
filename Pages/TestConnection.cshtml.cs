using Microsoft.AspNetCore.Mvc.RazorPages;
using BancoApp.Data;

public class TestConnectionModel : PageModel
{
    private readonly DatabaseHelper _dbHelper;

    public bool IsConnected { get; set; }

    public TestConnectionModel(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void OnGet()
    {
        IsConnected = _dbHelper.TestConnection();
    }
    
}
