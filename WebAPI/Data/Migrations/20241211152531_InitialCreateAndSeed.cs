using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ean = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Slug = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrls = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specifications = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DISFAVIL" },
                    { 2, "ZUUM" },
                    { 3, "ENSURE" },
                    { 4, "ALKOH" },
                    { 5, "VESA" },
                    { 6, "SUPERIOR" },
                    { 7, "SAL ANDREWS" },
                    { 8, "ALKA-SELTZER" },
                    { 9, "HIDRAVIDA" },
                    { 10, "PANADOL" },
                    { 11, "MK" },
                    { 12, "GLUCERNA" },
                    { 13, "CASTILLA" },
                    { 14, "GENESIS" },
                    { 15, "VITAFLENACO" },
                    { 16, "CERAVE" },
                    { 17, "ATLEVIT" },
                    { 18, "HANSAPLAST" },
                    { 19, "ALKA EXTREME" },
                    { 20, "TUMS" },
                    { 21, "SANTA FE NATURA" },
                    { 22, "EUCERIN" },
                    { 23, "EXCELLENT" },
                    { 24, "TYLENOL" },
                    { 25, "PEDIASURE" },
                    { 26, "DEOPIES" },
                    { 27, "TABCIN" },
                    { 28, "AFFECTIVE" },
                    { 29, "ADVIL" },
                    { 30, "GATORADE" },
                    { 31, "DORIVAL" },
                    { 32, "METAMUCIL" },
                    { 33, "ASPIRINA" },
                    { 34, "VIROGRIP" },
                    { 35, "SAVORÂ" },
                    { 36, "VIJOSA" },
                    { 37, "GELA-KIN" },
                    { 38, "PEDEX" },
                    { 39, "INFASA" },
                    { 40, "SIETE MARES" },
                    { 41, "VICK" },
                    { 42, "VICK VAPORUB" },
                    { 43, "LA BONNE VIE" },
                    { 44, "DRIVE MEDICAL" },
                    { 45, "FARMANDINA" },
                    { 46, "MEDIMART" },
                    { 47, "PRUDENCE" },
                    { 48, "QUALIPHARM" },
                    { 49, "ALKA AD" },
                    { 50, "JOHNSON & JOHNSON" },
                    { 51, "PEPTO BISMOL" },
                    { 52, "PASINERVA" },
                    { 53, "VITABIOTICS" },
                    { 54, "BENET" },
                    { 55, "BEPANTHENE" },
                    { 56, "BAYER" },
                    { 57, "CUREBAND" },
                    { 58, "PIEX" },
                    { 59, "CENTRUM" },
                    { 60, "GOOD BRANDS" },
                    { 61, "DEL PILAR" },
                    { 62, "NEXCARE" },
                    { 63, "LA ROCHE-POSAY" },
                    { 64, "ENTEREX" },
                    { 65, "MASCARA" },
                    { 66, "REDOXITOS" },
                    { 67, "OMRON" },
                    { 68, "DUREX" },
                    { 69, "AMBIDERM" },
                    { 70, "DONOVAN" },
                    { 71, "GUTIS" },
                    { 72, "CANESTEN" },
                    { 73, "VIVE" },
                    { 74, "SUKROL" },
                    { 75, "BEBERÂ" },
                    { 76, "NEXT-TABS" },
                    { 77, "ALKA  GASTRIC" },
                    { 78, "ROEMMERS" },
                    { 79, "MEDIHEALTH" },
                    { 80, "MENARINI" },
                    { 81, "REDOXON" },
                    { 82, "CAPLIN POINT LABORAT" },
                    { 83, "UNESIA" },
                    { 84, "CEBION" },
                    { 85, "RENU" },
                    { 86, "MEDIPRODUCTS" },
                    { 87, "NEUMONIL" },
                    { 88, "VISINA" },
                    { 89, "NIPRO" },
                    { 90, "ALDO UNION" },
                    { 91, "FARKOT" },
                    { 92, "ANCALMO" },
                    { 93, "VITAL FUERTE" },
                    { 94, "ALCON" },
                    { 95, "CARDIOASPIRINA" },
                    { 96, "DIQUIVA" },
                    { 97, "ISDIN" },
                    { 98, "NUTRAMEDIX" },
                    { 99, "ALEVE" },
                    { 100, "BALLENA AZUL" },
                    { 101, "FRYCIA" },
                    { 102, "ABL PHARMA" },
                    { 103, "GRIIN" },
                    { 104, "SIN MARCA" },
                    { 105, "COFAL" },
                    { 106, "B&J" },
                    { 107, "VICHY" },
                    { 108, "K-Y GEL" },
                    { 109, "PEDIALYTE" },
                    { 110, "NEUROFORTAN" },
                    { 111, "BABE" },
                    { 112, "CHINOIN" },
                    { 113, "ABBOTT CFR" },
                    { 114, "PIERSAN" },
                    { 115, "MERCK" },
                    { 116, "JALOMA" },
                    { 117, "LEUKOPLAST" },
                    { 118, "FERRER" },
                    { 119, "DOLOKALORUB" },
                    { 120, "BABARIA" },
                    { 121, "GENERIX" },
                    { 122, "ASOFARMA" },
                    { 123, "QUINFICA" },
                    { 124, "LEMON GRASS" },
                    { 125, "BONIN" },
                    { 126, "PROCTER & GAMBLE" },
                    { 127, "SANOFI CHC" },
                    { 128, "COREGA" },
                    { 129, "ISIS PHARMA" },
                    { 130, "UNIPHARM" },
                    { 131, "SCOTT" },
                    { 132, "GMS" },
                    { 133, "VERDE VITA" },
                    { 134, "CHEMILCO" },
                    { 135, "QUIFARMA" },
                    { 136, "VITAMIN SHOPPE" },
                    { 137, "BMA PHARMA" },
                    { 138, "ICN GROSMAN" },
                    { 139, "EXELTIS" },
                    { 140, "MED PHARMA" },
                    { 141, "GEX" },
                    { 142, "GASTRO-BISMOL" },
                    { 143, "CIRUELAX" },
                    { 144, "GNC" },
                    { 145, "BAYKID" },
                    { 146, "ACIERTO" },
                    { 147, "HIMALAYA" },
                    { 148, "LEONFLAX" },
                    { 149, "PHILLIPS" },
                    { 150, "RUSSELL STOVER" },
                    { 151, "ACON" },
                    { 152, "GLAXOSMITHKLINE" },
                    { 153, "PROTEINOL" },
                    { 154, "SANTA FE" },
                    { 155, "CARDIO VITAL" },
                    { 156, "DENK" },
                    { 157, "LANCASCO" },
                    { 158, "BENADRYL" },
                    { 159, "LAXMI PHARMAC." },
                    { 160, "VIZCAINO" },
                    { 161, "LAINEZ" },
                    { 162, "ZEPOL" },
                    { 163, "BUSSIE" },
                    { 164, "BIODERMA" },
                    { 165, "SEBAPHARMA" },
                    { 166, "MEFASA" },
                    { 167, "PROFOOT" },
                    { 168, "GHL INTERNACION" },
                    { 169, "BAYER HEALTHCARE P" },
                    { 170, "SAFEGUARD" },
                    { 171, "JANSSEN" },
                    { 172, "CHOLSAMAJ" },
                    { 173, "PINGUINO" },
                    { 174, "NIKZON" },
                    { 175, "ROCHE" },
                    { 176, "PRUMISA" },
                    { 177, "ABBOTT LAB." },
                    { 178, "GUASURE" },
                    { 179, "GRUPO FARMA" },
                    { 180, "ROWE" },
                    { 181, "BOEHRINGER INGELHEIM" },
                    { 182, "GLOBAL FARMA" },
                    { 183, "ACCU-ANSWER" },
                    { 184, "BIOCLEAN" },
                    { 185, "LAFAGE" },
                    { 186, "DAVIS LAB." },
                    { 187, "ODDENT" },
                    { 188, "CHURCH&DWIGHT" },
                    { 189, "PROCAPS" },
                    { 190, "FERRIDOCE" },
                    { 191, "HEIDELG" },
                    { 192, "ROWA WAGNER" },
                    { 193, "ALFER" },
                    { 194, "PHARMALAT" },
                    { 195, "ASTRA ZENECA" },
                    { 196, "EUROFARMA" },
                    { 197, "PAILL" },
                    { 198, "BIO TRUE" },
                    { 199, "LABORATORIOS MIDI" },
                    { 200, "TERAMED" },
                    { 201, "LUNDBECK" },
                    { 202, "ORGANON" },
                    { 203, "ACINO PHARMA" },
                    { 204, "ESCUDO" },
                    { 205, "NUTRISON" },
                    { 206, "NOVARTIS PHARMA" },
                    { 207, "GLAXO PHARMA" },
                    { 208, "PFIZER" },
                    { 209, "VIU" },
                    { 210, "BENESTAR" },
                    { 211, "BENESSI" },
                    { 212, "CRAYOLA SILLY SCENTS" },
                    { 213, "EXELTIS NOVARTIS" },
                    { 214, "HIDRATOMIC" },
                    { 215, "SERVIER" },
                    { 216, "PHARBEST" },
                    { 217, "VITAGEL" },
                    { 218, "OSHI" },
                    { 219, "MERZ" },
                    { 220, "CHEMINTER" },
                    { 221, "SANOFI" },
                    { 222, "FARMAMEDICA" },
                    { 223, "FUTURO" },
                    { 224, "GARDEN HOUSE" },
                    { 225, "NOVARTIS-COHEN" },
                    { 226, "DRIVE DEVILBISS HEALTHCARE" },
                    { 227, "SAVAL" },
                    { 228, "VIFOR" },
                    { 229, "IPROFASA" },
                    { 230, "BONLIFE" },
                    { 231, "MILAGRO DE LA SELVA" },
                    { 232, "OM" },
                    { 233, "HARRY POTTER" },
                    { 234, "MEDITEMP" },
                    { 235, "PANALAB" },
                    { 236, "CHALVER" },
                    { 237, "KRAL" },
                    { 238, "CHILE" },
                    { 239, "QG5" },
                    { 240, "SESDERMA S.A" },
                    { 241, "GRUNENTHAL" },
                    { 242, "HIDRISAGE" },
                    { 243, "INTECFA" },
                    { 244, "ROHAPHARMA" },
                    { 245, "EISAI" },
                    { 246, "ROTTA" },
                    { 247, "MERCK SHARP & D" },
                    { 248, "QUIMIFAR" },
                    { 249, "ASPEN" },
                    { 250, "ARSAL" },
                    { 251, "BIOTA" },
                    { 252, "PHARMAKON" },
                    { 253, "ANGELINI" },
                    { 254, "OFTISOL" },
                    { 255, "PHISA" },
                    { 256, "BAYER HEALTHCARE P" },
                    { 257, "LEVEN" },
                    { 258, "NOVARTIS" },
                    { 259, "BALIARDA" },
                    { 260, "SILANES" },
                    { 261, "SOPHIA" },
                    { 262, "BIOCODEX" },
                    { 263, "LANSIER" },
                    { 264, "MEGALABS" },
                    { 265, "PROTEC" },
                    { 266, "WELLCO" },
                    { 267, "LUVECK" },
                    { 268, "MICROLIFE" },
                    { 269, "TOP MODEL" },
                    { 270, "ELI LILLY" },
                    { 271, "JR PHARMA" },
                    { 272, "PRODES" },
                    { 273, "ALLERGAN" },
                    { 274, "BAGO" },
                    { 275, "SANAMIEL" },
                    { 276, "BEBES LLORONES" },
                    { 277, "RUBIOS" },
                    { 278, "SANOFI-ETICO" },
                    { 279, "SAN GERMAN" },
                    { 280, "MEMBER'S MARK" },
                    { 281, "ROSCOE" },
                    { 282, "GRISI" },
                    { 283, "GENFAR" },
                    { 284, "CUMLAUDE LAB" },
                    { 285, "EQUATE" },
                    { 286, "BOSTON" },
                    { 287, "NIELSEN BAINBRIDGE" },
                    { 288, "SANDOZ" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sistema digestivo y Antiparasitarios" },
                    { 2, "OTC" },
                    { 3, "Estomacales" },
                    { 4, "Analgésicos" },
                    { 5, "Dolor e inflamación" },
                    { 6, "Multivitamínicos, Suplementos & Sistema Óseo" },
                    { 7, "Respiratorios" },
                    { 8, "Dermatología" },
                    { 9, "Cuidado Personal" },
                    { 10, "Antiviral, gripe y tos" },
                    { 11, "Vitaminas y Suplementos" },
                    { 12, "Asma, alergias y nasal" },
                    { 13, "Bienestar, equipo médico y soluciones hospitalarias" },
                    { 14, "Cuidado de los Pies" },
                    { 15, "Anticonceptivos, hormonal y salud sexual" },
                    { 16, "Cardiovascular & Hipertensivo" },
                    { 17, "Material de Curación" },
                    { 18, "Antimicótico" },
                    { 19, "Sistema Nervioso" },
                    { 20, "Bienestar Sexual" },
                    { 21, "Oftálmicos y Óticos" },
                    { 22, "Salud Bucal, Oftalmológico & Oído" },
                    { 23, "Diabetes" },
                    { 24, "Diabetes y tiroides" },
                    { 25, "Embarazo & lactancia infantil" },
                    { 26, "Medicamentos de Alta Especialidad" },
                    { 27, "Colesterol y Triglicérido" },
                    { 28, "Sistema Urinario" },
                    { 29, "Antibiótico" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Sueros" },
                    { 2, 4, "Dolor" },
                    { 3, 7, "Resfríos" },
                    { 4, 9, "Dermocosméticos" },
                    { 5, 11, "Preventivos" },
                    { 6, 14, "Talcos" },
                    { 7, 11, "Vitaminas" },
                    { 8, 3, "Dolor y Malestar" },
                    { 9, 7, "Congestión Nasal" },
                    { 10, 17, "Otros Materiales" },
                    { 11, 3, "Antiácidos" },
                    { 12, 20, "Condones" },
                    { 13, 21, "Gotas para los ojos" },
                    { 14, 14, "Accesorios cuidado de pies" },
                    { 15, 11, "Suplementos Nutricionales" },
                    { 16, 23, "Equipos y Accesorios" },
                    { 17, 4, "Musculares e Inflamación" },
                    { 18, 11, "Embarazo" },
                    { 19, 9, "Aceites y Cremas" },
                    { 20, 17, "Gasas y Vendas" },
                    { 21, 9, "Para Cuidado Bucal" },
                    { 22, 7, "Tos" },
                    { 23, 7, "Alergias" },
                    { 24, 21, "Oídos" },
                    { 25, 20, "Suplementos" },
                    { 26, 17, "Guantes y Cubrebocas" },
                    { 27, 3, "Antiparasitarios" },
                    { 28, 3, "Antidiarreicos" },
                    { 29, 26, "Alta Especialidad" },
                    { 30, 20, "Anticonceptivos" },
                    { 31, 9, "Antiacné PX" },
                    { 32, 3, "Antiulcerantes" },
                    { 33, 14, "Antimicóticos Pies" },
                    { 34, 11, "Multivitamínicos" },
                    { 35, 3, "Probióticos" },
                    { 36, 17, "Banditas y telas adhesivas" },
                    { 37, 3, "Laxante" },
                    { 38, 23, "Tratamiento Diabetes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Subcategories");
        }
    }
}
