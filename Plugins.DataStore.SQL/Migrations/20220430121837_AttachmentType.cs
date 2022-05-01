using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    public partial class AttachmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SrvServiceSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    FromDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceSchedules_SrvService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "SrvService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SrvServiceTypeAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceTypeAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceTypeAttachments_SrvServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "SrvServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SrvServiceAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeAttachmentId = table.Column<int>(type: "int", nullable: false),
                    FileUrlpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefined4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypeNavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrvServiceAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SrvServiceAttachments_SrvFileType_FileTypeNavigationId",
                        column: x => x.FileTypeNavigationId,
                        principalTable: "SrvFileType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SrvServiceAttachments_SrvService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "SrvService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SrvServiceAttachments_SrvServiceTypeAttachments_ServiceTypeAttachmentId",
                        column: x => x.ServiceTypeAttachmentId,
                        principalTable: "SrvServiceTypeAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceAttachments_FileTypeNavigationId",
                table: "SrvServiceAttachments",
                column: "FileTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceAttachments_ServiceId",
                table: "SrvServiceAttachments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceAttachments_ServiceTypeAttachmentId",
                table: "SrvServiceAttachments",
                column: "ServiceTypeAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceSchedules_ServiceId",
                table: "SrvServiceSchedules",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SrvServiceTypeAttachments_ServiceTypeId",
                table: "SrvServiceTypeAttachments",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SrvServiceAttachments");

            migrationBuilder.DropTable(
                name: "SrvServiceSchedules");

            migrationBuilder.DropTable(
                name: "SrvServiceTypeAttachments");
        }
    }
}
