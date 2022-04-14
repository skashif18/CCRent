using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    public partial class AddedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SrvCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvCategory_SrvCategory",
                        column: x => x.ParentCategoryId,
                        principalTable: "SrvCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SrvFileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvFileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SrvServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceType_SrvServiceType",
                        column: x => x.ServiceTypeId,
                        principalTable: "SrvServiceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SysCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysGender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysNationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysNationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysReligion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysReligion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SrvClassValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvClassValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvClassValue_SrvClass",
                        column: x => x.ClassId,
                        principalTable: "SrvClass",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableValueId = table.Column<int>(type: "int", nullable: false),
                    FileURLPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvDocument_SrvFileType",
                        column: x => x.FileType,
                        principalTable: "SrvFileType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileURLPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvImage_SrvFileType",
                        column: x => x.FileType,
                        principalTable: "SrvFileType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvService_SrvCategory",
                        column: x => x.CategoryId,
                        principalTable: "SrvCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvService_SrvServiceType",
                        column: x => x.ServiceTypeId,
                        principalTable: "SrvServiceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SysCity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysCity_SysCountry",
                        column: x => x.CountryId,
                        principalTable: "SysCountry",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvAddOn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvAddOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvAddOn_SrvImage",
                        column: x => x.IconId,
                        principalTable: "SrvImage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvServiceClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceClass_SrvClass",
                        column: x => x.ClassId,
                        principalTable: "SrvClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvServiceClass_SrvService",
                        column: x => x.ServiceId,
                        principalTable: "SrvService",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvServiceClassValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    ClassValueId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceClassValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceClassValue_SrvClass",
                        column: x => x.ClassId,
                        principalTable: "SrvClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvServiceClassValue_SrvClassValue",
                        column: x => x.ClassValueId,
                        principalTable: "SrvClassValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvServiceClassValue_SrvService",
                        column: x => x.ServiceId,
                        principalTable: "SrvService",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobileno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvCustomer_SysCity",
                        column: x => x.CityId,
                        principalTable: "SysCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvCustomer_SysGender",
                        column: x => x.GenderId,
                        principalTable: "SysGender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvCustomer_SysLanguage",
                        column: x => x.LanguageId,
                        principalTable: "SysLanguage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvCustomer_SysNationality",
                        column: x => x.NationalityId,
                        principalTable: "SysNationality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvCustomer_SysReligion",
                        column: x => x.ReligionId,
                        principalTable: "SysReligion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobileno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvSupplier_SysCity",
                        column: x => x.CityId,
                        principalTable: "SysCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvSupplier_SysGender",
                        column: x => x.GenderId,
                        principalTable: "SysGender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvSupplier_SysLanguage",
                        column: x => x.LanguageId,
                        principalTable: "SysLanguage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvSupplier_SysNationality",
                        column: x => x.NationalityId,
                        principalTable: "SysNationality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvSupplier_SysReligion",
                        column: x => x.ReligionId,
                        principalTable: "SysReligion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SrvServiceAddOn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    AddOnId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceAddOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceAddOn_SrvAddOn",
                        column: x => x.AddOnId,
                        principalTable: "SrvAddOn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvServiceAddOn_SrvImage",
                        column: x => x.ImageId,
                        principalTable: "SrvImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvServiceAddOn_SrvService",
                        column: x => x.ServiceId,
                        principalTable: "SrvService",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SrvAddOn_IconId",
                table: "SrvAddOn",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvCategory_ParentCategoryId",
                table: "SrvCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvClassValue_ClassId",
                table: "SrvClassValue",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvCustomer_CityId",
                table: "SrvCustomer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvCustomer_GenderId",
                table: "SrvCustomer",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvCustomer_LanguageId",
                table: "SrvCustomer",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvCustomer_NationalityId",
                table: "SrvCustomer",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvCustomer_ReligionId",
                table: "SrvCustomer",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvDocument_FileType",
                table: "SrvDocument",
                column: "FileType");

            migrationBuilder.CreateIndex(
                name: "IX_SrvImage_FileType",
                table: "SrvImage",
                column: "FileType");

            migrationBuilder.CreateIndex(
                name: "IX_SrvService_CategoryId",
                table: "SrvService",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvService_ServiceTypeId",
                table: "SrvService",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceAddOn_AddOnId",
                table: "SrvServiceAddOn",
                column: "AddOnId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceAddOn_ImageId",
                table: "SrvServiceAddOn",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceAddOn_ServiceId",
                table: "SrvServiceAddOn",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceClass_ClassId",
                table: "SrvServiceClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceClass_ServiceId",
                table: "SrvServiceClass",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceClassValue_ClassId",
                table: "SrvServiceClassValue",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceClassValue_ClassValueId",
                table: "SrvServiceClassValue",
                column: "ClassValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceClassValue_ServiceId",
                table: "SrvServiceClassValue",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceType_ServiceTypeId",
                table: "SrvServiceType",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvSupplier_CityId",
                table: "SrvSupplier",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvSupplier_GenderId",
                table: "SrvSupplier",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvSupplier_LanguageId",
                table: "SrvSupplier",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvSupplier_NationalityId",
                table: "SrvSupplier",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvSupplier_ReligionId",
                table: "SrvSupplier",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_SysCity_CountryId",
                table: "SysCity",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SrvCustomer");

            migrationBuilder.DropTable(
                name: "SrvDocument");

            migrationBuilder.DropTable(
                name: "SrvServiceAddOn");

            migrationBuilder.DropTable(
                name: "SrvServiceClass");

            migrationBuilder.DropTable(
                name: "SrvServiceClassValue");

            migrationBuilder.DropTable(
                name: "SrvSupplier");

            migrationBuilder.DropTable(
                name: "SrvAddOn");

            migrationBuilder.DropTable(
                name: "SrvClassValue");

            migrationBuilder.DropTable(
                name: "SrvService");

            migrationBuilder.DropTable(
                name: "SysCity");

            migrationBuilder.DropTable(
                name: "SysGender");

            migrationBuilder.DropTable(
                name: "SysLanguage");

            migrationBuilder.DropTable(
                name: "SysNationality");

            migrationBuilder.DropTable(
                name: "SysReligion");

            migrationBuilder.DropTable(
                name: "SrvImage");

            migrationBuilder.DropTable(
                name: "SrvClass");

            migrationBuilder.DropTable(
                name: "SrvCategory");

            migrationBuilder.DropTable(
                name: "SrvServiceType");

            migrationBuilder.DropTable(
                name: "SysCountry");

            migrationBuilder.DropTable(
                name: "SrvFileType");
        }
    }
}
