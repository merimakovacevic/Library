using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Library.dal;

namespace Library.Test
{//ovdje ćemo samo da overrideamo onconfig
    public class TestContext :LibContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql(
                "User ID=postgres;Password=meri2a;" +
                "Server=localhost;Port=5432;Database=LibTest;" +
                "Integrated Security=true;Pooling=true;");
        }
    }
}
