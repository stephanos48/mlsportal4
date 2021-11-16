using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    public partial class addcontainerinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterPartId",
                table: "Photos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContainerNoFF = table.Column<string>(type: "text", nullable: true),
                    ContainerNoInt = table.Column<string>(type: "text", nullable: true),
                    EtdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EtpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PortDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EtaDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BOL = table.Column<string>(type: "text", nullable: true),
                    AMS = table.Column<string>(type: "text", nullable: true),
                    Invoice = table.Column<string>(type: "text", nullable: true),
                    FreightForwarder = table.Column<string>(type: "text", nullable: true),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    DeparturePort = table.Column<string>(type: "text", nullable: true),
                    ArrivalPort = table.Column<string>(type: "text", nullable: true),
                    ContainerStatusId = table.Column<int>(type: "integer", nullable: false),
                    ContainerStatusName = table.Column<string>(type: "text", nullable: true),
                    ShipModeId = table.Column<int>(type: "integer", nullable: false),
                    ShipModeName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.ContainerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDivisions",
                columns: table => new
                {
                    CustomerDivisionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerDivisionName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDivisions", x => x.CustomerDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "MasterParts",
                columns: table => new
                {
                    MasterPartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartNumber = table.Column<string>(type: "text", nullable: true),
                    MlsPn = table.Column<string>(type: "text", nullable: true),
                    PartDescription = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    CustomerDivisionId = table.Column<int>(type: "integer", nullable: false),
                    CustomerDivisionName = table.Column<string>(type: "text", nullable: true),
                    MlsDivisionId = table.Column<int>(type: "integer", nullable: false),
                    MlsDivisionName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PartTypeId = table.Column<int>(type: "integer", nullable: false),
                    PartTypeName = table.Column<string>(type: "text", nullable: true),
                    Qoh = table.Column<int>(type: "integer", nullable: false),
                    HtsCode = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterParts", x => x.MasterPartId);
                });

            migrationBuilder.CreateTable(
                name: "MlsDivisions",
                columns: table => new
                {
                    MlsDivisionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MlsDivisionName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MlsDivisions", x => x.MlsDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "PartTypes",
                columns: table => new
                {
                    PartTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTypes", x => x.PartTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseOrderNumber = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    CustomerDivisionId = table.Column<int>(type: "integer", nullable: false),
                    CustomerDivisionName = table.Column<string>(type: "text", nullable: true),
                    MlsDivisionId = table.Column<int>(type: "integer", nullable: false),
                    MlsDivisionName = table.Column<string>(type: "text", nullable: true),
                    SalesOrderId = table.Column<int>(type: "integer", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "text", nullable: true),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    SupplierName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    PoStatusId = table.Column<int>(type: "integer", nullable: false),
                    PoStatusName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                });

            migrationBuilder.CreateTable(
                name: "ContainerDetails",
                columns: table => new
                {
                    ContainerDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContainerId = table.Column<int>(type: "integer", nullable: false),
                    MasterPartId = table.Column<int>(type: "integer", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: true),
                    ContainerQty = table.Column<int>(type: "integer", nullable: false),
                    ContainerPalletNo = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerDetails", x => x.ContainerDetailId);
                    table.ForeignKey(
                        name: "FK_ContainerDetails_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "ContainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipModes",
                columns: table => new
                {
                    ShipModeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShipModeName = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ContainerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipModes", x => x.ShipModeId);
                    table.ForeignKey(
                        name: "FK_ShipModes_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "ContainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationMasterPart",
                columns: table => new
                {
                    LocationsLocationId = table.Column<int>(type: "integer", nullable: false),
                    MasterPartsMasterPartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMasterPart", x => new { x.LocationsLocationId, x.MasterPartsMasterPartId });
                    table.ForeignKey(
                        name: "FK_LocationMasterPart_Locations_LocationsLocationId",
                        column: x => x.LocationsLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMasterPart_MasterParts_MasterPartsMasterPartId",
                        column: x => x.MasterPartsMasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLines",
                columns: table => new
                {
                    PurchaseOrderLineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseOrderId = table.Column<int>(type: "integer", nullable: false),
                    MasterPartId = table.Column<int>(type: "integer", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: true),
                    PurchaseOrderLineNo = table.Column<string>(type: "text", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PromiseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OrderQty = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ContainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLines", x => x.PurchaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "ContainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContainerDetailPurchaseOrderLine",
                columns: table => new
                {
                    ContainerDetailsContainerDetailId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseOrderLinesPurchaseOrderLineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerDetailPurchaseOrderLine", x => new { x.ContainerDetailsContainerDetailId, x.PurchaseOrderLinesPurchaseOrderLineId });
                    table.ForeignKey(
                        name: "FK_ContainerDetailPurchaseOrderLine_ContainerDetails_Container~",
                        column: x => x.ContainerDetailsContainerDetailId,
                        principalTable: "ContainerDetails",
                        principalColumn: "ContainerDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainerDetailPurchaseOrderLine_PurchaseOrderLines_Purchas~",
                        column: x => x.PurchaseOrderLinesPurchaseOrderLineId,
                        principalTable: "PurchaseOrderLines",
                        principalColumn: "PurchaseOrderLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MasterPartId",
                table: "Photos",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDetailPurchaseOrderLine_PurchaseOrderLinesPurchase~",
                table: "ContainerDetailPurchaseOrderLine",
                column: "PurchaseOrderLinesPurchaseOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDetails_ContainerId",
                table: "ContainerDetails",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMasterPart_MasterPartsMasterPartId",
                table: "LocationMasterPart",
                column: "MasterPartsMasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_ContainerId",
                table: "PurchaseOrderLines",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_PurchaseOrderId",
                table: "PurchaseOrderLines",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipModes_ContainerId",
                table: "ShipModes",
                column: "ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_MasterParts_MasterPartId",
                table: "Photos",
                column: "MasterPartId",
                principalTable: "MasterParts",
                principalColumn: "MasterPartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_MasterParts_MasterPartId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "ContainerDetailPurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "CustomerDivisions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LocationMasterPart");

            migrationBuilder.DropTable(
                name: "MlsDivisions");

            migrationBuilder.DropTable(
                name: "PartTypes");

            migrationBuilder.DropTable(
                name: "ShipModes");

            migrationBuilder.DropTable(
                name: "ContainerDetails");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLines");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MasterParts");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_Photos_MasterPartId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MasterPartId",
                table: "Photos");
        }
    }
}
