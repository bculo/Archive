using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelArchive.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "Dbo");

            migrationBuilder.CreateTable(
                name: "ArchiveUser",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DefaultLanguage = table.Column<string>(maxLength: 30, nullable: false, defaultValue: "en-US")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelFolder",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelFolder_ArchiveUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Dbo",
                        principalTable: "ArchiveUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Printer",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Model = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Printer_ArchiveUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Dbo",
                        principalTable: "ArchiveUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    UserId1 = table.Column<Guid>(nullable: true),
                    RoleId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model3D",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 100, nullable: false),
                    ModelType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    FolderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model3D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model3D_ModelFolder_FolderId",
                        column: x => x.FolderId,
                        principalSchema: "Dbo",
                        principalTable: "ModelFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrinterImage",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    FolderName = table.Column<string>(maxLength: 100, nullable: false),
                    PrinterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrinterImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrinterImage_Printer_PrinterId",
                        column: x => x.PrinterId,
                        principalSchema: "Dbo",
                        principalTable: "Printer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelImage",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    FolderName = table.Column<string>(maxLength: 100, nullable: false),
                    ModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelImage_Model3D_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "Dbo",
                        principalTable: "Model3D",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e76b37a7-8e06-4df2-8961-f78ab2ef2472"), "01755524-7dc7-4ccf-97d4-48364c8f4a07", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7aae4732-fb79-435a-97cf-3764de5a3dfa"), "c055e366-466f-4b20-ba70-e6a75ed6fea8", "user", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveUser_IdentityId",
                schema: "Dbo",
                table: "ArchiveUser",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveUser_UserName",
                schema: "Dbo",
                table: "ArchiveUser",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Model3D_FolderId",
                schema: "Dbo",
                table: "Model3D",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFolder_UserId",
                schema: "Dbo",
                table: "ModelFolder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelImage_ModelId",
                schema: "Dbo",
                table: "ModelImage",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_UserId",
                schema: "Dbo",
                table: "Printer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrinterImage_PrinterId",
                schema: "Dbo",
                table: "PrinterImage",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Security",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Security",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Security",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelImage",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "PrinterImage",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Model3D",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "Printer",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ModelFolder",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "ArchiveUser",
                schema: "Dbo");
        }
    }
}
