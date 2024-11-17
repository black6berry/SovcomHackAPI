using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SovcomHackAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryAccident",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Название категории"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Описание категории"),
                    Effects = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Какие угрозы жизни"),
                    RangeFrom = table.Column<decimal>(type: "decimal(5,5)", nullable: false, comment: "Диапазон ОТ"),
                    RangeTo = table.Column<decimal>(type: "decimal(5,5)", nullable: false, comment: "Диапазон ДО")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAccident", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckMoneyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckMoneyData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Название роли"),
                    NameFS = table.Column<string>(name: "Name_FS", type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false, comment: "Первая буква в названии роли")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCard",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Тип карты")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Имя"),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Фамилия"),
                    Patronomic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Отчество"),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Телефон"),
                    LastConnect = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Последнее подключение"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД роли пользователя"),
                    Verified = table.Column<bool>(type: "bit", nullable: false, comment: "Подтверждение аккаунта пользователя"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Статус пользователя"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Логин пользователя"),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Пароль пользователя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCardId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД типа карты (зарплатная, кредитная)"),
                    Number = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false, comment: "Номер карты"),
                    Day = table.Column<long>(type: "bigint", nullable: false, comment: "День действителен ДО"),
                    Year = table.Column<long>(type: "bigint", nullable: false, comment: "Год действителен ДО"),
                    CVV = table.Column<long>(type: "bigint", nullable: false, comment: "Код CVV"),
                    DateOfReceiving = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Дата, до которой нужно карту обновить"),
                    ValueMoney = table.Column<decimal>(type: "decimal(10,2)", nullable: false, comment: "Объем денег на карте (Мы понимаем, что должен быть счет и должен быть привязана карта к нему, а деньги на счету, но чтобы сэкономить время - вы сразу деньги храним на карте)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_TypeCard",
                        column: x => x.TypeCardId,
                        principalTable: "TypeCard",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActiveBag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastDateUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveBag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveBag_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankAccountClient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД Клиента"),
                    ValueMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CheckMoneyDataId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountClient_CheckMoneyData",
                        column: x => x.CheckMoneyDataId,
                        principalTable: "CheckMoneyData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConnectedUserServices_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionUserBidding",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД Пользователя"),
                    TimeSpanActive = table.Column<long>(type: "bigint", nullable: false, comment: "Время начала (момент, когда тумблер true)"),
                    TimeSpanFinish = table.Column<long>(type: "bigint", nullable: false, comment: "Время конца (момент, когда тумблер false)"),
                    Get = table.Column<long>(type: "bigint", nullable: false, comment: "ИД Продукта компании")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionUser_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankAccAvailable",
                columns: table => new
                {
                    BankAccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreditCardId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccAvailable", x => new { x.BankAccountId, x.CreditCardId });
                    table.ForeignKey(
                        name: "FK_BankAccAvailable_BankAccountClient",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccountClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccAvailable_CreditCard",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogHistoryOperation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BankAccountClientId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    IsLoad = table.Column<bool>(type: "bit", nullable: false),
                    ValueMoney = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogHistoryOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogHistoryOperation_BankAccountClient",
                        column: x => x.BankAccountClientId,
                        principalTable: "BankAccountClient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogHistoryOperation_Operation",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogHistoryOperation_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accident",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ИД")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД Пользователя"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД Категория травмоопасности"),
                    ValueGet = table.Column<decimal>(type: "decimal(10,2)", nullable: false, comment: "Получаемое значение"),
                    DateAccident = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Дата происшествия"),
                    GeoposionX = table.Column<decimal>(type: "decimal(5,5)", nullable: false, comment: "Координата по Ox"),
                    GeoposionY = table.Column<decimal>(type: "decimal(5,5)", nullable: false, comment: "Координата по OY"),
                    SessionId = table.Column<long>(type: "bigint", nullable: false, comment: "ИД сессии, когда произошло происшествие")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accident_CategoryAccident",
                        column: x => x.CategoryId,
                        principalTable: "CategoryAccident",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accident_SessionUser",
                        column: x => x.SessionId,
                        principalTable: "SessionUserBidding",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accident_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accident_CategoryId",
                table: "Accident",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accident_SessionId",
                table: "Accident",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accident_UserId",
                table: "Accident",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveBag_UserId",
                table: "ActiveBag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccAvailable_CreditCardId",
                table: "BankAccAvailable",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountClient_CheckMoneyDataId",
                table: "BankAccountClient",
                column: "CheckMoneyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountClient_UserId",
                table: "BankAccountClient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_TypeCardId",
                table: "CreditCard",
                column: "TypeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LogHistoryOperation_BankAccountClientId",
                table: "LogHistoryOperation",
                column: "BankAccountClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LogHistoryOperation_OperationId",
                table: "LogHistoryOperation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_LogHistoryOperation_UserId",
                table: "LogHistoryOperation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionUserBidding_UserId",
                table: "SessionUserBidding",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accident");

            migrationBuilder.DropTable(
                name: "ActiveBag");

            migrationBuilder.DropTable(
                name: "BankAccAvailable");

            migrationBuilder.DropTable(
                name: "LogHistoryOperation");

            migrationBuilder.DropTable(
                name: "CategoryAccident");

            migrationBuilder.DropTable(
                name: "SessionUserBidding");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "BankAccountClient");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "TypeCard");

            migrationBuilder.DropTable(
                name: "CheckMoneyData");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
