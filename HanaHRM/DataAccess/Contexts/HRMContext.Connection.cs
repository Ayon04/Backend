using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

public partial class HRMContext : DbContext
{
    public HRMContext() { }

    public HRMContext(DbContextOptions<HRMContext> options)
        : base(options)
    {
    }

}
