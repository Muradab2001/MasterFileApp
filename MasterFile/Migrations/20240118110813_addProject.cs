using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterFile.Migrations
{
    public partial class addProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TSno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressOpticalCable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionPointElectricalCable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BCGroupNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AVİCOMNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTZCameraCount = table.Column<int>(type: "int", nullable: false),
                    FİXCameraCount = table.Column<int>(type: "int", nullable: false),
                    CapturedCameraCount = table.Column<int>(type: "int", nullable: false),
                    CapturedNotCameraCount = table.Column<int>(type: "int", nullable: false),
                    ActualInstalledCameraCount = table.Column<int>(type: "int", nullable: false),
                    SwitchModel = table.Column<bool>(type: "bit", nullable: false),
                    ViewHistory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExploitationHistory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFirstImage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoleType = table.Column<int>(type: "int", nullable: false),
                    ImageAcceptance = table.Column<int>(type: "int", nullable: false),
                    CommissioningAddingToGenetek = table.Column<int>(type: "int", nullable: false),
                    Foundation = table.Column<int>(type: "int", nullable: false),
                    ConnectionType = table.Column<int>(type: "int", nullable: false),
                    PoleInstallation = table.Column<int>(type: "int", nullable: false),
                    OpticalShooting = table.Column<int>(type: "int", nullable: false),
                    OpticalFinish = table.Column<int>(type: "int", nullable: false),
                    ElectricalWiring = table.Column<int>(type: "int", nullable: false),
                    FinalStatusBCGOperations = table.Column<int>(type: "int", nullable: false),
                    HandedOverAvicom = table.Column<int>(type: "int", nullable: false),
                    AntennaInstallation = table.Column<int>(type: "int", nullable: false),
                    BoxInstallation = table.Column<int>(type: "int", nullable: false),
                    InstallationCamera = table.Column<int>(type: "int", nullable: false),
                    FirstImageAcquisition = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
