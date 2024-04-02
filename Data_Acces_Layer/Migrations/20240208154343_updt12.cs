using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Acces_Layer.Migrations
{
    /// <inheritdoc />
    public partial class updt12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    CoinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoinIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoinBoild = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.CoinID);
                });

            migrationBuilder.CreateTable(
                name: "User_Logins",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Words = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Logins", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Wallets",
                columns: table => new
                {
                    WalletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CoinID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Wallets", x => x.WalletID);
                    table.ForeignKey(
                        name: "FK_User_Wallets_Coins_CoinID",
                        column: x => x.CoinID,
                        principalTable: "Coins",
                        principalColumn: "CoinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Wallets_User_Logins_UserID",
                        column: x => x.UserID,
                        principalTable: "User_Logins",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Wallets_CoinID",
                table: "User_Wallets",
                column: "CoinID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Wallets_UserID",
                table: "User_Wallets",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Wallets");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "User_Logins");
        }
    }
}
