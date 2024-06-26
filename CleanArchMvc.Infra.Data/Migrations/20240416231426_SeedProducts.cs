﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId ) VALUES('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId ) VALUES('Estojo escolar', 'Estojo escolar cinza', 5.65, 70, 'estojo.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId ) VALUES('Borracha escolar', 'Borracha branca pequena', 3.45, 80, 'borracha.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId ) VALUES('Calculadora escolar', 'Calculadora simples', 15.39, 20, 'calculadora.jpg', 2)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
